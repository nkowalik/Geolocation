namespace Geolocation.Api.Models
{
    public class GeolocationDetailsDto
    {
        public int Id { get; set; }
        public string? Ip { get; set; }
        public string? Type { get; set; }
        public string? ContinentCode { get; set; }
        public string? Continent { get; set; }
        public string? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? RegionCode { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LocationDto? Location { get; set; }
    }
}
