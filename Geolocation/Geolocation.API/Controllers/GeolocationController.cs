using Geolocation.Api.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geolocation.Api.Controllers
{
    [ApiController]
    [Route("api/geolocation")]
    public class GeolocationController : ControllerBase
    {
        private readonly IConfiguration _config;

        public GeolocationController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet]
        public ActionResult<IEnumerable<GeolocationDto>> GetAllGeolocationInformation()
        {
            return Ok(GeolocationDataStore.Current.Geolocation);
        }

        [HttpGet("{id}", Name = "GetGeolocationInformationById")]
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

        [HttpPost("{address}")]
        public async Task<ActionResult<GeolocationDto>> CreateGeolocationAsync(string address)
        {
            GeolocationDetailsDto? geoDetails;
            var accessKey = _config.GetValue<string>("Geolocation:AccessKey");
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"https://api.ipstack.com/{address}?access_key={accessKey}");
                string apiResponse = await response.Content.ReadAsStringAsync();
                geoDetails = JsonConvert.DeserializeObject<GeolocationDetailsDto>(apiResponse);
            }

            if (geoDetails == null)
            {
                return NotFound();
            }

            if (!IsValidateInput(geoDetails))
            {
                return BadRequest(address);
            }

            var geolocation = new GeolocationDto
            {
                Id = GeolocationDataStore.Current.Geolocation.Max(g => g.Id) + 1,
                Address = address,
                GeoDetails = geoDetails
            };

            return CreatedAtRoute("GetGeolocation", geolocation);
        }

        private bool IsValidateInput(GeolocationDetailsDto geoDetails)
        {
            return true;
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
