using AutoMapper;
using Geolocation.Api.ConnectionHandlers;
using Geolocation.Api.Entities;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest.TransientFaultHandling;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Geolocation.Api.Controllers
{
    [ApiController]
    [Route("api/geolocation")]
    public class GeolocationController : ControllerBase
    {
        private readonly IConfiguration _config;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly IMapper _mapper;

        private readonly RetryPolicy _retryPolicy;

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

            _retryPolicy = new RetryPolicy<GeolocationTransientErrorDetectionStrategy>
                (new IncrementalRetryStrategy(5, TimeSpan.FromSeconds(0), TimeSpan.FromSeconds(1.5))
                {
                    FastFirstRetry = true
                });

            _retryPolicy.Retrying += (s, e) =>
            Trace.TraceWarning("An error occurred in attempt number {1} to create geolocation: {0}", e.LastException.Message, e.CurrentRetryCount);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeolocationDto>>> GetGeolocationsAsync(
            string? countryName = null)
        {
            var geolocationEntities = await _geolocationRepository.GetGeolocationsAsync(countryName);
            return Ok(_mapper.Map<IEnumerable<GeolocationDto>>(geolocationEntities));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetGeolocationAsync(int id)
        {
            var geolocationEntity = await _geolocationRepository.GetGeolocationAsync(id);
            
            if (geolocationEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GeolocationDetailsDto>(geolocationEntity));
        }

        [HttpPost("{address}")]
        public async Task<IActionResult> CreateGeolocationAsync(string address)
        {
            var geoDetailsDto = await _retryPolicy.ExecuteAction(() => GetGeolocationDetails(address));

            if (geoDetailsDto == null)
            {
                return NotFound();
            }

            if (!IsValidateInput(geoDetailsDto))
            {
                return BadRequest(address);
            }

            var geoEntity = new Entities.Geolocation(address)
            {
                GeoDetails = _mapper.Map<GeolocationDetails>(geoDetailsDto)
            };

            await _geolocationRepository.CreateGeolocationAsync(geoEntity);

            return Ok(geoEntity);
        }

        [HttpDelete]
        public async Task<ActionResult> DeleteGeolocationAsync(int id)
        {
            if(!await _geolocationRepository.GeolocationExistsAsync(id))
            {
                return NotFound();
            }

            var geolocationEntity = await _geolocationRepository.GetGeolocationAsync(id);
            _geolocationRepository.DeleteGeolocation(geolocationEntity!);

            return NoContent();
        }

        private async Task<GeolocationDetailsDto?> GetGeolocationDetails(string address)
        {
            var accessKey = _config.GetValue<string>("Geolocation:AccessKey");
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync($"http://api.ipstack.com/{address}?access_key={accessKey}");
            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GeolocationDetailsDto>(apiResponse);
        }

        private static bool IsValidateInput(GeolocationDetailsDto geoDetails)
        {
            if (geoDetails.Continent_name is null || geoDetails.Country_name is null)
            {
                return false;
            }

            return true;
        }
    }
}
