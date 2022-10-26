using AutoMapper;
using MRI.ImageGallery.API.Entities;
using MRI.ImageGallery.Models.Dtos;
using MRI.ImageGallery.Models.ViewModel;

namespace MRI.ImageGallery.API.Profiles
{
    public class ImageProfile:Profile
    {
        public ImageProfile() {
            CreateMap<Image, ImageVm>();
            CreateMap<AddImageDto, Image>();
        }
    }
}
