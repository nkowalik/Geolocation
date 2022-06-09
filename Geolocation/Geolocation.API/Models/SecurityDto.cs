namespace Geolocation.Api.Models
{
    public class SecurityDto
    {
        public bool IsProxy { get; set; }
        public string? ProxyType { get; set; }
        public bool IsCrawler { get; set; }
        public string? CrawlerName { get; set; }
        public string? CrawlerType { get; set; }
        public bool IsTor { get; set; }
        public string ThreatLevel { get; set; } = string.Empty;
        public string? ThreatTypes { get; set;}
    }
}
