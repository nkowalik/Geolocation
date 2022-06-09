using Geolocation.Api.Models;
using Microsoft.AspNetCore.Mvc;

namespace Geolocation.Api.Controllers
{
    [ApiController]
    [Route("api/geolocation")]
    public class GeolocationController : ControllerBase
    {
        [HttpGet]
        public ActionResult<IEnumerable<GeolocationDto>> GetAllGeolocationInformation()
        {
            return Ok(GeolocationDataStore.Current.Geolocation);
        }

        [HttpGet("{id}", Name = "GetGeolocation")]
        public ActionResult<GeolocationDto> GetGeolocationInformationById(int id)
        {
            var geolocation = GeolocationDataStore.Current.Geolocation
                .FirstOrDefault(g => g.Id == id);
            
            if (geolocation == null)
            {
                return NotFound();
            }

            return Ok(geolocation);
        }

        [HttpPost]
        public ActionResult<GeolocationDto> CreateGeolocation(InputDataDto inputData)
        {
            // try to get details from https://ipstack.com/
            // validate input data: ModelState.IsValid -> bad request
            // if failed - return NotFound()
            // if ok - add it to the dto

            var geolocation = new GeolocationDto
            {
                Id = GeolocationDataStore.Current.Geolocation.Max(g => g.Id)+1,
                Address = inputData.Address,
                GeoDetails = new GeolocationDetailsDto()
            };

            return CreatedAtRoute("GetGeolocation", geolocation);
        }

        [HttpDelete]
        public ActionResult DeleteGeolocation(InputDataDto inputData)
        {
            bool isGeolocationPresent = GeolocationDataStore.Current.Geolocation
                .Any(g => g.Address == inputData.Address);
            if (!isGeolocationPresent)
            {
                return NotFound();
            }

            GeolocationDataStore.Current.Geolocation
                .RemoveAll(g => g.Address == inputData.Address);

            return NoContent();
        }

        [HttpDelete]
        public ActionResult DeleteGeolocation(int id)
        {
            var geolocation = GeolocationDataStore.Current.Geolocation
                .FirstOrDefault(g => g.Id == id);
            if (geolocation == null)
            {
                return NotFound();
            }

            GeolocationDataStore.Current.Geolocation.Remove(geolocation);

            return NoContent();
        }
    }
}
