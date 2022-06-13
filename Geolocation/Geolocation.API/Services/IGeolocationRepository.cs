namespace Geolocation.Api.Services
{
    public interface IGeolocationRepository
    {
        Task<IEnumerable<Entities.Geolocation>> GetGeolocationsAsync();
        Task<Entities.Geolocation?> GetGeolocationAsync(int id);
        Task<Entities.GeolocationDetails?> GetGeolocationDetailsAsync(int id);
        Task<bool> GeolocationExistsAsync(int id);
        Task<bool> SaveChangesAsync();
        void DeleteGeolocation(Entities.Geolocation geolocation);
    }
}
