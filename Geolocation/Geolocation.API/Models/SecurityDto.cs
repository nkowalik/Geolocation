namespace Geolocation.Api.Models
{
    public class SecurityDto
    {
        public int Id { get; set; }
        public bool Is_proxy { get; set; } = false;
        public string? Proxy_type { get; set; }
        public bool Is_crawler { get; set; } = false;
        public string? Crawler_name { get; set; }
        public string? Crawler_type { get; set; }
        public bool Is_tor { get; set; } = false;
        public string? Threat_level { get; set; }
        public string? Threat_types { get; set; }
    }
}