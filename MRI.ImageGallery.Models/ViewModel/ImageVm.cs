using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRI.ImageGallery.Models.ViewModel
{
    public class ImageVm
    {
        public Guid Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public string FileName { get; set; } = string.Empty;
    }
}
