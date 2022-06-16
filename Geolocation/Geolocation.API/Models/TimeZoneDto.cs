namespace Geolocation.Api.Models
{
    public class TimeZoneDto
    {
        public int TimeZoneId { get; set; }
        public string? Id { get; set; }
        public string? CurrentTime { get; set; }
        public int Gmt_offset { get; set; }
        public string? Code { get; set; }
        public bool Is_daylight_saving { get; set; } = true;
    }
}