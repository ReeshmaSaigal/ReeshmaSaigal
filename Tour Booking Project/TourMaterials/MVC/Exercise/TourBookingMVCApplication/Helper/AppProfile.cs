using AutoMapper;
using Microsoft.AspNetCore.Identity.Data;
using TourBookingMVCApplication.DTO;
using TourBookingMVCApplication.Models;

namespace TourBookingMVCApplication.Helper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<TourBookingDto, TourBookingForm>().ReverseMap();
            CreateMap<CreateBookingDto, TourBookingForm>().ReverseMap();

            CreateMap<AuthUser,AuthUserDto>().ReverseMap();
            CreateMap<Tour,TourDto>().ReverseMap();
        }
    }
}
