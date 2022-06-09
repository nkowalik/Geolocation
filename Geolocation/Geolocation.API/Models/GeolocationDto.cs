namespace Geolocation.Api.Models
{
    public class GeolocationDto
    {
        public int Id { get; set; }
        public string Address { get; set; } = string.Empty;
        public GeolocationDetailsDto GeoDetails { get; set; } = new GeolocationDetailsDto();
    }
}
