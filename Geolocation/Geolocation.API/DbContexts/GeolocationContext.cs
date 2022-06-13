using Microsoft.EntityFrameworkCore;

namespace Geolocation.Api.DbContexts
{
    public class GeolocationContext : DbContext
    {
        public DbSet<Entities.Geolocation> Geolocations { get; set; } = null!;
        public DbSet<Entities.GeolocationDetails> GeolocationDetails { get; set; } = null!;

        public GeolocationContext(DbContextOptions<GeolocationContext> options) : base(options)
        {}
    }
}
