namespace Geolocation.Api.Services
{
    public interface IGeolocationRepository
    {
        Task<IEnumerable<Entities.Geolocation>> GetGeolocationsAsync();
        Task<IEnumerable<Entities.Geolocation>> GetGeolocationsAsync(string? countryName);
        Task<Entities.Geolocation?> GetGeolocationAsync(int id);
        Task<Entities.GeolocationDetails?> GetGeolocationDetailsAsync(int id);
        Task CreateGeolocationAsync(Entities.Geolocation geoEntity);
        Task<bool> GeolocationExistsAsync(int id);
        Task<bool> SaveChangesAsync();
        void DeleteGeolocation(Entities.Geolocation geolocation);
    }
}
