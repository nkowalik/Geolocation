using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class TimeZone
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TimeZoneId { get; set; }
        public string? Id { get; set; }
        public string? CurrentTime { get; set; }
        public int Gmt_offset { get; set; }
        public string? Code { get; set; }
        public bool Is_daylight_saving { get; set; } = true;

        [ForeignKey("GeolocationDetailsId")]
        public int GeolocationDetailsId { get; set; }
    }
}