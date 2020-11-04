
using AutoMapper;
using CanteenSystemForAITU.Domain.Models;
using ProjectForAITUCanteen.DataTransfer.DTO;
using ProjectForAITUCanteen.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProjectForAITUCanteen.Domain.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Item, ProductDTO>();

            //CreateMap<User, UserForListDTO>()
            //    .ForMember(dest => dest.PhotoUrl, opt =>
            //        opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain).Url))
            //    .ForMember(dest => dest.Age, opt =>
            //        opt.MapFrom(src => src.Birthday.CalculateAge()));
            //CreateMap<Photo, PhotoInfoDTO>();
        }
    }
}
