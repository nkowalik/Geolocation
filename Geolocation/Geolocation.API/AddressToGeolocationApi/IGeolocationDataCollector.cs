using Geolocation.Api.Models;

namespace Geolocation.Api.AddressToGeolocationApi
{
    public interface IGeolocationDataCollector
    {
        Task<GeolocationDetailsDto?> FetchGeolocationDetailsFromApiAsync(string address);
    }
}
