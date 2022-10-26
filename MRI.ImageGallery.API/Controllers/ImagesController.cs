using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting.Internal;
using MRI.ImageGallery.API.Services;
using MRI.ImageGallery.Models.Dtos;
using MRI.ImageGallery.Models.ViewModel;

namespace MRI.ImageGallery.API.Controllers
{
    [Route("api/images")]
    [Authorize]
    public class ImagesController : ControllerBase
    {
        private readonly IImageGalleryRepository _imageGalleryRepository;
        private readonly IMapper _mapper;
        private readonly IWebHostEnvironment _hostingEnvironment;
        public ImagesController(IImageGalleryRepository imageGalleryRepository,IMapper mapper,
            IWebHostEnvironment hostingEnvironment) {
        _imageGalleryRepository = imageGalleryRepository;
            _mapper = mapper;
            _hostingEnvironment = hostingEnvironment;
            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageVm>>> GetImages()
        {
            var ownerId = User.Claims
               .FirstOrDefault(c => c.Type == "sub")?.Value;
            if (ownerId == null)
            {
                throw new Exception("User identifier is missing from token.");
            }
            var images=await _imageGalleryRepository.GetImagesAsync(ownerId).ConfigureAwait(false);
            var imagesVm=_mapper.Map<IEnumerable<ImageVm>>(images);
            return Ok(imagesVm); 
            


        }
        [HttpPost()]
        [Authorize(Roles = "PayingUser")]
        public async Task<ActionResult<ImageVm>> CreateImage([FromBody] AddImageDto addImageDto)
        {
          
            var imageEntity = _mapper.Map<Entities.Image>(addImageDto);
            // get this environment's web root path (the path
            // from which static content, like an image, is served)
            var webRootPath = _hostingEnvironment.WebRootPath;
            // create the filename
            string fileName = Guid.NewGuid().ToString() + ".jpg";
            // the full file path
            var filePath = Path.Combine($"{webRootPath}/images/{fileName}");

            // write bytes and auto-close stream
            await System.IO.File.WriteAllBytesAsync(filePath, addImageDto.Bytes);

            // fill out the filename
            imageEntity.FileName = fileName;

            
            // set the ownerId on the imageEntity
            var ownerId = User.Claims
                .FirstOrDefault(c => c.Type == "sub")?.Value;
            if (ownerId == null)
            {
                throw new Exception("User identifier is missing from token.");
            }
            imageEntity.OwnerId = ownerId;


            // add and save.  
            _imageGalleryRepository.AddImage(imageEntity);

            await _imageGalleryRepository.SaveChangesAsync();

            var imageToReturn = _mapper.Map<ImageVm>(imageEntity);

            return CreatedAtRoute("GetImage",
                new { id = imageToReturn.Id },
                imageToReturn);
        }
    }
}
