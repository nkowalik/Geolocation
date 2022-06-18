using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class Location
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Geoname_id { get; set; }
        public string? Capital { get; set; }
        public string? Country_flag { get; set; }
        public string? Country_flag_emoji { get; set; }
        public string? Country_flag_emoji_unicode { get; set; }
        public string? Calling_code { get; set; }
        public bool Is_eu { get; set; } = false;
        public IEnumerable<Language> Languages { get; set; } = new List<Language>();

        [ForeignKey("GeolocationDetailsId")]
        public int GeolocationDetailsId { get; set; }
    }
}
