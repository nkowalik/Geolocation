namespace Geolocation.Api.Models
{
    public class LocationDto
    {
        public int Id { get; set; }
        public int Geoname_id { get; set; }
        public string? Capital { get; set; }
        public string? Country_flag { get; set; }
        public bool Is_eu { get; set; } = false;
        public IEnumerable<LanguagesDto> Languages = new List<LanguagesDto>();
    }
}
