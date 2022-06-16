namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the connection information
    /// </summary>
    public class ConnectionDto
    {
        /// <summary>
        /// An id of the connection
        /// </summary>
        public int Id { get; set; }
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