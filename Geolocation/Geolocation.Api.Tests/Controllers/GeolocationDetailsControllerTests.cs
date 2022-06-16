using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoMapper;
using Geolocation.Api.Controllers;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using NSubstitute;
using NUnit.Framework;

namespace Geolocation.Api.Tests.Controllers
{
    public class GeolocationDetailsControllerTests
    {
        private ILogger<GeolocationDetailsController> _logger;
        private IFixture _fixture;
        private IGeolocationRepository _geoRepository;
        private IMapper _mapper;
        private ResourceHelper _helper;

        private GeolocationDetailsController _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = false
            });
            _logger = _fixture.Create<ILogger<GeolocationDetailsController>>();
            _geoRepository = _fixture.Create<IGeolocationRepository>();
            _mapper = _fixture.Create<IMapper>();
            _helper = new ResourceHelper();

            _sut = new GeolocationDetailsController(_logger, _mapper, _geoRepository);
        }

        [Test]
        public async Task WhenGetGeolocationDetailsAsyncIsCalled_ThenProperResultIsReturned()
        {
            const int id = 1;
            const string address = "184.173.255.201";
            _geoRepository.GeolocationExistsAsync(id).Returns(true);
            _geoRepository.GetGeolocationDetailsAsync(id).Returns(_helper.GetSampleGeolocationDetails(address));

            var result = await _sut.GetGeolocationDetailsAsync(id);

            Assert.Multiple(async () =>
            {
                Assert.That(result, Is.Not.Null);
                _mapper.Received(1).Map<GeolocationDetailsDto>(Arg.Any<Entities.GeolocationDetails>());
                await _geoRepository.Received(1).GetGeolocationDetailsAsync(Arg.Any<int>());
            });
        }
    }
}
