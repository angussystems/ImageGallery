using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MRI.ImageGallery.Models.Dtos
{
    public class AddImageDto
    {

        [Required]
        [MaxLength(150)]
        public string Title { get; set; }

        [Required]
        public byte[] Bytes { get; set; }

        public AddImageDto(string title, byte[] bytes)
        {
            Title = title;
            Bytes = bytes;
        }
    }
}
