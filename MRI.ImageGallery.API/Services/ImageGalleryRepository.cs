
using Microsoft.EntityFrameworkCore;
using MRI.ImageGallery.API.DbContexts;
using MRI.ImageGallery.API.Entities;
using MRI.ImageGallery.API.Services;

namespace ImageGallery.API.Services
{
    public class ImageGalleryRepository : IImageGalleryRepository 
    {
        private readonly ImageGalleryContext _context;

        public ImageGalleryRepository(ImageGalleryContext galleryContext)
        {
            _context = galleryContext ?? 
                throw new ArgumentNullException(nameof(galleryContext));
        }

        public async Task<IEnumerable<Image>> GetImagesAsync(string ownerId)
        {
            return await _context.Images.Where(s=>s.OwnerId==ownerId)
                .OrderBy(i => i.Title).ToListAsync();
        }

        public void AddImage(Image image)
        {
            _context.Images.Add(image);
        }



        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() >= 0);
        }


    }
}
