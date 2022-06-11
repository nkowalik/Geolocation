using Geolocation.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geolocation.Api.Controllers
{
    [Route("api/[controller]/{id}/data")]
    [ApiController]
    public class GeolocationDetailsController : ControllerBase
    {
        private readonly ILogger<GeolocationDetailsController> _logger;

        public GeolocationDetailsController(ILogger<GeolocationDetailsController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<GeolocationDetailsDto> GetGeoData(int id)
        {
            var geolocation = GeolocationDataStore.Current.Geolocation.FirstOrDefault(g => g.Id == id);
            if (geolocation == null || geolocation.GeoDetails == null)
            {
                _logger.LogInformation($"Geolocation details with id {id} were not found.");
                return NotFound();
            }

            return Ok(geolocation.GeoDetails.Ip);
        }
    }
}
