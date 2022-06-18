namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the connection information
    /// </summary>
    public class ConnectionDto
    {
        /// <summary>
        /// Autonomous System Number
        /// </summary>
        public int Asn { get; set; }
        /// <summary>
        /// Internet Service Provider
        /// </summary>
        public string? Isp { get; set; }
    }
}