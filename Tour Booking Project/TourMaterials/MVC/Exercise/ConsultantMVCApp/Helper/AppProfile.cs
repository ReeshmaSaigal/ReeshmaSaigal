using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using ConsultantMVCApp.DTO;
using ConsultantMVCApp.Models;

namespace ConsultantMVCApp.Helper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<User,CreateConsultantDto>().ReverseMap();
            CreateMap<User, AuthUserDto>().ReverseMap();
            CreateMap<User, ConsultantListDto>()
            .ForMember(dest => dest.FullName,
                       opt => opt.MapFrom(src => src.FirstName + " " + src.LastName)).ReverseMap();
            CreateMap<User,ConsultantDetailsDto>().ReverseMap();
        }
    }
}
