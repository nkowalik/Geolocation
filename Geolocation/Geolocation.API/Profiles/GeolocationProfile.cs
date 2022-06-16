using AutoMapper;

namespace Geolocation.Api.Profiles
{
    public class GeolocationProfile : Profile
    {
        public GeolocationProfile()
        {
            CreateMap<Entities.Geolocation, Models.GeolocationDto>();
            CreateMap<Models.GeolocationDto, Entities.Geolocation>();
        }
    }
}
