using AutoMapper;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace Geolocation.Api.Controllers
{
    [Route("api/[controller]/{id}/data")]
    [ApiController]
    public class GeolocationDetailsController : ControllerBase
    {
        private readonly ILogger<GeolocationDetailsController> _logger;
        private readonly IMapper _mapper;
        private readonly IGeolocationRepository _repository;

        public GeolocationDetailsController(ILogger<GeolocationDetailsController> logger,
            IMapper mapper, IGeolocationRepository repository)
        {
            _logger = logger ??
                throw new ArgumentNullException(nameof(logger));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _repository = repository ??
                throw new ArgumentNullException(nameof(repository));
        }

        [HttpGet]
        public async Task<ActionResult<GeolocationDetailsDto>> GetGeolocationDetailsAsync(int id)
        {
            if (!await _repository.GeolocationExistsAsync(id))
            {
                _logger.LogInformation($"Geolocation details with id {id} were not found.");
                return NotFound();
            }

            var geolocationDetails = await _repository.GetGeolocationDetailsAsync(id);

            return Ok(_mapper.Map<GeolocationDetailsDto>(geolocationDetails));
        }
    }
}
