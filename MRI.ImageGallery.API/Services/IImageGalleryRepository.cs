

using MRI.ImageGallery.API.Entities;

namespace MRI.ImageGallery.API.Services
{
    public interface IImageGalleryRepository
    {
        Task<IEnumerable<Image>> GetImagesAsync(string ownerId);
        void AddImage(Image image);
        Task<bool> SaveChangesAsync();

    }
}
