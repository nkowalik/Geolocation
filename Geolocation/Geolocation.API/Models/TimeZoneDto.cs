namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the time zone information
    /// </summary>
    public class TimeZoneDto
    {
        /// <summary>
        /// An id of the time zone
        /// </summary>
        public int TimeZoneId { get; set; }
        /// <summary>
        /// An identity(name) of the time zone
        /// </summary>
        public string? Id { get; set; }
        /// <summary>
        /// A current time
        /// </summary>
        public string? CurrentTime { get; set; }
        /// <summary>
        /// A GMT offcet
        /// </summary>
        public int Gmt_offset { get; set; }
        /// <summary>
        /// A code of the time zone
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// Is Daylight Saving Time
        /// </summary>
        public bool Is_daylight_saving { get; set; } = true;
    }
}