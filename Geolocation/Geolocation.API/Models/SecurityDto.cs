namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the security information
    /// </summary>
    public class SecurityDto
    {
        /// <summary>
        /// An id of the security
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Is proxy used
        /// </summary>
        public bool Is_proxy { get; set; } = false;
        /// <summary>
        /// A type of the proxy
        /// </summary>
        public string? Proxy_type { get; set; }
        /// <summary>
        /// Is crawler used
        /// </summary>
        public bool Is_crawler { get; set; } = false;
        /// <summary>
        /// A crawler name
        /// </summary>
        public string? Crawler_name { get; set; }
        /// <summary>
        /// A type of the crawler
        /// </summary>
        public string? Crawler_type { get; set; }
        /// <summary>
        /// Is tor used
        /// </summary>
        public bool Is_tor { get; set; } = false;
        /// <summary>
        /// A level of the threat
        /// </summary>
        public string? Threat_level { get; set; }
        /// <summary>
        /// Types of the threat
        /// </summary>
        public string? Threat_types { get; set; }
    }
}