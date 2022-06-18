namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the geolocation information
    /// </summary>
    public class GeolocationDto
    {
        /// <summary>
        /// An IP address
        /// </summary>
        public string Address { get; set; } = string.Empty;
        /// <summary>
        /// Geolocation details
        /// </summary>
        public GeolocationDetailsDto GeoDetails { get; set; } = new GeolocationDetailsDto();
    }
}
