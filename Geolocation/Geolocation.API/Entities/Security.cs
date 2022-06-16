using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class Security
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public bool Is_proxy { get; set; } = false;
        public string? Proxy_type { get; set; }
        public bool Is_crawler { get; set; } = false;
        public string? Crawler_name { get; set; }
        public string? Crawler_type { get; set; }
        public bool Is_tor { get; set; } = false;
        public string? Threat_level { get; set; }
        public string? Threat_types { get; set; }

        [ForeignKey("GeolocationDetailsId")]
        public int GeolocationDetailsId { get; set; }
    }
}