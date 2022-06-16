using AutoMapper;

namespace Geolocation.Api.Profiles
{
    public class LocationProfile : Profile
    {
        public LocationProfile()
        {
            CreateMap<Entities.Location, Models.LocationDto>();
            CreateMap<Models.LocationDto, Entities.Location>();
        }
    }
}
