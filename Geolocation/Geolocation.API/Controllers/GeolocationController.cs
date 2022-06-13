using AutoMapper;
using Geolocation.Api.Entities;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Geolocation.Api.Controllers
{
    [ApiController]
    [Route("api/geolocation")]
    public class GeolocationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly IMapper _mapper;

        public GeolocationController(IConfiguration config,
            IGeolocationRepository geolocationRepository,
            IMapper mapper)
        {
            _config = config ?? 
                throw new ArgumentNullException(nameof(config));
            _geolocationRepository = geolocationRepository ??
                throw new ArgumentNullException(nameof(geolocationRepository));
            _mapper = mapper ?? 
                throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeolocationDetailsDto>>> GetGeolocations()
        {
            var geolocationEntities = await _geolocationRepository.GetGeolocationsAsync();
            return Ok(_mapper.Map<IEnumerable<GeolocationDetailsDto>>(geolocationEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeolocation(int id)
        {
            var geolocationEntity = await _geolocationRepository.GetGeolocationAsync(id);
            
            if (geolocationEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GeolocationDetailsDto>(geolocationEntity));
        }

        [HttpPost("{address}")]
        public async Task<ActionResult<GeolocationDto>> CreateGeolocation(string address)
        {
            GeolocationDetailsDto? geoDetails;
            var accessKey = _config.GetValue<string>("Geolocation:AccessKey");
            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"http://api.ipstack.com/{address}?access_key={accessKey}");
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

            var finalGeoDetails = _mapper.Map<GeolocationDetails>(geoDetails);

            return CreatedAtRoute("GetGeolocation", new
            {
                Address = address,
                GeoDetails = finalGeoDetails
            }, finalGeoDetails);
        }

        private static bool IsValidateInput(GeolocationDetailsDto geoDetails)
        {
            return true;
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGeolocation(int id)
        {
            if(!await _geolocationRepository.GeolocationExistsAsync(id))
            {
                return NotFound();
            }

            var geolocationEntity = await _geolocationRepository.GetGeolocationAsync(id);
            _geolocationRepository.DeleteGeolocation(geolocationEntity!);

            return NoContent();
        }
    }
}
