namespace Geolocation.Api.Models
{
    public class GeolocationDetailsDto
    {
        public int Id { get; set; }
        public string? Ip { get; set; }
        public string? Hostname { get; set; }
        public string? Type { get; set; }
        public string? Continent_code { get; set; }
        public string? Continent_name { get; set; }
        public string? Country_code { get; set; }
        public string? Country_name { get; set; }
        public string? Region_code { get; set; }
        public string? Region_name { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LocationDto? Location { get; set; }
        public TimeZoneDto? Time_zone { get; set; }
        public CurrencyDto? Currency { get; set; }
        public ConnectionDto? Connection { get; set; }
        public SecurityDto? Security { get; set; }
    }
}
