using AutoMapper;
using PlatformServicesApi.Dtos;
using PlatformServicesApi.Models;

namespace PlatformServicesApi.Profiles
{
    public class PlatformsProfile : Profile
    {
        public PlatformsProfile()
        {
            CreateMap<Platform, PlatformReadDto>();
            CreateMap<PlatformCreateDto, Platform>();
        }
    }
}
