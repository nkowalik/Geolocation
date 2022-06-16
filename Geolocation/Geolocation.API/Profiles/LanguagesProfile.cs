using AutoMapper;

namespace Geolocation.Api.Profiles
{
    public class LanguageProfile : Profile
    {
        public LanguageProfile()
        {
            CreateMap<Entities.Language, Models.LanguageDto>();
            CreateMap<Models.LanguageDto, Entities.Language>();
        }
    }
}
