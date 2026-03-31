using AutoMapper;
using TourDestinationMVCApp.DTO;
using TourDestinationMVCApp.Models;

namespace TourDestinationMVCApp.Helper
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<Destination, DestinationResponseDto>().ReverseMap();
            CreateMap<DestinationDto, Destination>().ReverseMap();
            CreateMap<DestinationPatchDto, Destination>().ReverseMap();
            CreateMap<AuthUser,AuthUserDto>().ReverseMap();
            CreateMap<DestinationDto,DestinationResponseDto>().ReverseMap();
        }
    }
}
