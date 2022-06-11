using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class Geolocation
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [MaxLength(200)]
        public string Address { get; set; }

        public GeolocationDetails GeoDetails { get; set; } = new GeolocationDetails();

        public Geolocation(string address)
        {
            Address = address;
        }
    }
}
