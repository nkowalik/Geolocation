namespace Geolocation.Api.Models
{
    public class LocationDto
    {
        public int GeonameId { get; set; }
        public string? Capital { get; set; }
        public string? CountryFlag { get; set; }
        public bool IsEu { get; set; }
        public IEnumerable<LanguagesDto> Languages = new List<LanguagesDto>();
    }
}
