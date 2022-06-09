using Geolocation.Api.Models;

namespace Geolocation.Api
{
    public class GeolocationDataStore
    {
        public List<GeolocationDto> Geolocation { get; set; }
        public static GeolocationDataStore Current { get; } = new GeolocationDataStore();

        public GeolocationDataStore()
        {
            Geolocation = new List<GeolocationDto>()
            {
                new GeolocationDto() { Id = 1, Address = "url", GeoDetails = new GeolocationDetailsDto{Id = 5} },
                new GeolocationDto() { Id = 2, Address = "ip", GeoDetails = new GeolocationDetailsDto{Id = 6}},
                new GeolocationDto() { Id = 3, Address = "url2", GeoDetails = new GeolocationDetailsDto{Id = 7}}
            };
        }
    }
}
