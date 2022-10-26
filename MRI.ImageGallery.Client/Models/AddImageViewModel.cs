using System.ComponentModel.DataAnnotations;

namespace MRI.ImageGallery.Client.Models
{ 
    public class AddImageViewModel
    {
        public List<IFormFile> Files { get; set; } = new List<IFormFile>();

        [Required]
        public string Title { get; set; }

        public AddImageViewModel(string title, List<IFormFile> files)
        {
            Title = title;
            Files = files;
        }

        public AddImageViewModel()
        {

        }
    }
}
