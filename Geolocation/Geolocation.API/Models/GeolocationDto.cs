namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the geolocation information
    /// </summary>
    public class GeolocationDto
    {
        /// <summary>
        /// An id of the geolocation
        /// </summary>
        public int Id { get; set; }
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
