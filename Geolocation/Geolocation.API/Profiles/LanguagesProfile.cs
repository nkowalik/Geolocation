using AutoMapper;

namespace Geolocation.Api.Profiles
{
    public class LanguagesProfile : Profile
    {
        public LanguagesProfile()
        {
            CreateMap<Entities.Languages, Models.LanguagesDto>();
            CreateMap<Models.LanguagesDto, Entities.Languages>();
        }
    }
}
