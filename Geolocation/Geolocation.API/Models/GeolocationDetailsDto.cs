namespace Geolocation.Api.Models
{
    public class GeolocationDetailsDto
    {
        public int Id { get; set; }
        public string Ip { get; set; } = string.Empty;
        public string ContinentCode { get; set; } = string.Empty;
        public string Continent { get; set; } = string.Empty;
        public string CountryCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string RegionCode { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Zip { get; set; } = string.Empty;

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public LocationDto Location { get; set; }
        public CurrencyDto Currency { get; set; }
        public ConnectionDto Connection { get; set; }
        public SecurityDto Security { get; set; }
    }
}
