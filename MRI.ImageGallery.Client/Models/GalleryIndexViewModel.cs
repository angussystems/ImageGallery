using MRI.ImageGallery.Models.ViewModel;
using System.Collections.Generic;

namespace MRI.ImageGallery.Client.Models
{
    public class GalleryIndexViewModel
    {
        public IEnumerable<ImageVm> Images { get; private set; }
            = new List<ImageVm>();

        public GalleryIndexViewModel(IEnumerable<ImageVm> images)
        {
           Images = images;
        }
    }
}
