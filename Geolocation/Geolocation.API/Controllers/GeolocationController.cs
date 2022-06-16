using AutoMapper;
using Geolocation.Api.AddressToGeolocationApi;
using Geolocation.Api.ConnectionHandlers;
using Geolocation.Api.Entities;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Rest.TransientFaultHandling;
using System.Diagnostics;

namespace Geolocation.Api.Controllers
{
    /// <summary>
    /// The controller for the geolocation information
    /// </summary>
    [ApiController]
    [Route("api/geolocation")]
    public class GeolocationController : ControllerBase
    {
        private readonly IGeolocationDataCollector _collector;
        private readonly IGeolocationRepository _geolocationRepository;
        private readonly IMapper _mapper;

        private readonly RetryPolicy _retryPolicy;

        /// <summary>
        /// A constructor for GeolocationController
        /// </summary>
        /// <param name="collector">A geolocation data collector</param>
        /// <param name="geolocationRepository">A geolocation repository</param>
        /// <param name="mapper">An auto mapper</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GeolocationController(IGeolocationDataCollector collector,
            IGeolocationRepository geolocationRepository, IMapper mapper)
        {
            _collector = collector ??
                throw new ArgumentNullException(nameof(collector));
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

        /// <summary>
        /// Get all geolocation information with possibility to filter by country name
        /// </summary>
        /// <param name="countryName">Optional parameter to filter geolocation by country name</param>
        /// <returns>An ActionResult</returns>
        /// <response code="200">Returns all geolocations</response>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GeolocationDto>>> GetGeolocationsAsync(
            string? countryName = null)
        {
            var geolocationEntities = await _geolocationRepository.GetGeolocationsAsync(countryName);
            return Ok(_mapper.Map<IEnumerable<GeolocationDto>>(geolocationEntities));
        }

        /// <summary>
        /// Get geolocation by id
        /// </summary>
        /// <param name="id">An id of the geolocation</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">Returns the requested geolocation</response>
        /// <response code="404">The requested geolocation is not found</response>
        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetGeolocationAsync(int id)
        {
            var geolocationEntity = await _geolocationRepository.GetGeolocationAsync(id);
            
            if (geolocationEntity == null)
            {
                return NotFound();
            }

            return Ok(_mapper.Map<GeolocationDto>(geolocationEntity));
        }

        /// <summary>
        /// Create geolocation based on IP address
        /// </summary>
        /// <param name="address">IP address</param>
        /// <returns>An IActionResult</returns>
        /// <response code="200">A requested geolocation is created</response>
        /// <response code="404">Geolocation detailes are not found using address provided</response>
        /// <response code="400">Invalid input received</response>
        [HttpPost("{address}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateGeolocationAsync(string address)
        {
            var geoDetailsDto = await _retryPolicy.ExecuteAction(() => 
                _collector.FetchGeolocationDetailsFromApiAsync(address));

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

        /// <summary>
        /// Delete geolocation by id
        /// </summary>
        /// <param name="id">An id of the geolocation</param>
        /// <returns>An ActionResult</returns>
        /// <response code="200">A requested geolocation is deleted</response>
        [HttpDelete]
        public async Task<ActionResult> DeleteGeolocationAsync(int id)
        {
            if(!await _geolocationRepository.GeolocationExistsAsync(id))
            {
                return NotFound();
            }

            var geolocationEntity = await _geolocationRepository.GetGeolocationAsync(id);
            await _geolocationRepository.DeleteGeolocation(geolocationEntity!);

            return NoContent();
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
