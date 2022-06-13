using AutoMapper;

namespace Geolocation.Api.Profiles
{
    public class GeolocationDetailsProfile : Profile
    {
        public GeolocationDetailsProfile()
        {
            CreateMap<Entities.GeolocationDetails, Models.GeolocationDetailsDto>();
            CreateMap<Models.GeolocationDetailsDto, Entities.GeolocationDetails>();
        }
    }
}
