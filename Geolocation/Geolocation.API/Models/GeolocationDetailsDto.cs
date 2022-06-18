namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the geolocation details
    /// </summary>
    public class GeolocationDetailsDto
    {
        /// <summary>
        /// An IP address
        /// </summary>
        public string? Ip { get; set; }
        /// <summary>
        /// A hostname to IP address
        /// </summary>
        public string? Hostname { get; set; }
        /// <summary>
        /// A type of IP address
        /// </summary>
        public string? Type { get; set; }
        /// <summary>
        /// A code of the continent
        /// </summary>
        public string? Continent_code { get; set; }
        /// <summary>
        /// A continent name
        /// </summary>
        public string? Continent_name { get; set; }
        /// <summary>
        /// A code of the country
        /// </summary>
        public string? Country_code { get; set; }
        /// <summary>
        /// A country name
        /// </summary>
        public string? Country_name { get; set; }
        /// <summary>
        /// A code of the region
        /// </summary>
        public string? Region_code { get; set; }
        /// <summary>
        /// A region name
        /// </summary>
        public string? Region_name { get; set; }
        /// <summary>
        /// A city name
        /// </summary>
        public string? City { get; set; }
        /// <summary>
        /// A zip
        /// </summary>
        public string? Zip { get; set; }

        /// <summary>
        /// A latitude
        /// </summary>
        public double Latitude { get; set; }
        /// <summary>
        /// A longitude
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// Location information
        /// </summary>
        public LocationDto? Location { get; set; }
        /// <summary>
        /// Time zone information
        /// </summary>
        public TimeZoneDto? Time_zone { get; set; }
        /// <summary>
        /// Currency information
        /// </summary>
        public CurrencyDto? Currency { get; set; }
        /// <summary>
        /// Connection information
        /// </summary>
        public ConnectionDto? Connection { get; set; }
        /// <summary>
        /// Security information
        /// </summary>
        public SecurityDto? Security { get; set; }
    }
}
