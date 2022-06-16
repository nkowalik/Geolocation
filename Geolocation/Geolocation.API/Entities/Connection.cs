using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class Connection
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int Asn { get; set; }
        public string? Isp { get; set; }

        [ForeignKey("GeolocationDetailsId")]
        public int GeolocationDetailsId { get; set; }
    }
}