using Geolocation.Api.Models;

namespace Geolocation.Api
{
    public class GeolocationDataStore
    {
        public List<GeolocationDto> Geolocation { get; set; }
        public static GeolocationDataStore Current { get; } = new GeolocationDataStore();

        public GeolocationDataStore()
        {
            Geolocation = new List<GeolocationDto>();
        }
    }
}
