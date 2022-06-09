using Geolocation.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geolocation.Api.Controllers
{
    [Route("api/[controller]/{id}/data")]
    [ApiController]
    public class GeolocationDetailsController : ControllerBase
    {
        [HttpGet]
        public ActionResult<GeolocationDetailsDto> GetGeoData(int id)
        {
            var geolocation = GeolocationDataStore.Current.Geolocation.FirstOrDefault(g => g.Id == id);
            if (geolocation == null || geolocation.GeoDetails == null)
            {
                return NotFound();
            }

            return Ok(geolocation.GeoDetails.Ip);
        }
    }
}
