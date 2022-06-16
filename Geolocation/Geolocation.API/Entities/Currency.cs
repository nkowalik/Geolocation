using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Geolocation.Api.Entities
{
    public class Currency
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? Plural { get; set; }
        public string? Symbol { get; set; }
        public string? Symbol_native { get; set; }

        [ForeignKey("GeolocationDetailsId")]
        public int GeolocationDetailsId { get; set; }
    }
}