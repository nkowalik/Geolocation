using Geolocation.Api.DbContexts;
using Geolocation.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Geolocation.Api.Services
{
    public class GeolocationRepository : IGeolocationRepository
    {
        private readonly GeolocationContext _context;
        public GeolocationRepository(GeolocationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entities.Geolocation>> GetGeolocationsAsync()
        {
            return await _context.Geolocations.ToListAsync();
        }

        public async Task<Entities.Geolocation?> GetGeolocationAsync(int id)
        {
            return await _context.Geolocations.Include(g => g.GeoDetails)
                .Where(g => g.Id == id).FirstOrDefaultAsync();
        }

        public async Task<GeolocationDetails?> GetGeolocationDetailsAsync(int id)
        {
            return await _context.GeolocationDetails.Where(g => g.GeolocationId == id)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> GeolocationExistsAsync(int id)
        {
            var geolocation = await _context.Geolocations.FirstOrDefaultAsync(g => g.Id == id);
            return geolocation?.GeoDetails != null;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void DeleteGeolocation(Entities.Geolocation geolocation)
        {
            _context.Geolocations.Remove(geolocation);
        }
    }
}
