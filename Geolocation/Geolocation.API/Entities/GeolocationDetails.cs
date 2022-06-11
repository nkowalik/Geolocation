using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class GeolocationDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Ip { get; set; }
        public string? Type { get; set; }
        public string? ContinentCode { get; set; }
        public string? Continent { get; set; }
        public string? CountryCode { get; set; }
        public string? Country { get; set; }
        public string? RegionCode { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public string? Zip { get; set; }

        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string? Location { get; set; }

        [ForeignKey("GeolocationId")]
        public Geolocation? Geolocation { get; set; }
        public int GeolocationId { get; set; }
    }
}
