using AutoFixture;
using AutoFixture.AutoNSubstitute;
using AutoMapper;
using Geolocation.Api.AddressToGeolocationApi;
using Geolocation.Api.Controllers;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using NSubstitute;
using NUnit.Framework;

namespace Geolocation.Api.Tests.Controllers
{
    public class GeolocationControllerTests
    {
        private IGeolocationDataCollector _collector;
        private IFixture _fixture;
        private IGeolocationRepository _geoRepository;
        private IMapper _mapper;
        private ResourceHelper _helper;

        private GeolocationController _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = false
            });
            _collector = _fixture.Create<IGeolocationDataCollector>();
            _geoRepository = _fixture.Create<IGeolocationRepository>();
            _mapper = _fixture.Create<IMapper>();
            _helper = new ResourceHelper();

            _sut = new GeolocationController(_collector, _geoRepository, _mapper);
        }

        [Test]
        public async Task WhenGetGeolocationsAsyncIsCalled_ThenProperResultIsReturned()
        {
            const string address = "135.120.201.155";
            var sampleGeolocations = _helper.GetSampleGeolocations(address);
            _geoRepository.GetGeolocationsAsync()
                .ReturnsForAnyArgs(sampleGeolocations);

            var result = await _sut.GetGeolocationsAsync();

            Assert.Multiple(async () =>
            {
                Assert.That(result, Is.Not.Null);
                _mapper.Received(1).Map<IEnumerable<GeolocationDto>>(Arg.Any<IEnumerable<Entities.Geolocation>>());
                await _geoRepository.Received(1).GetGeolocationsAsync(Arg.Any<string>());
            });
        }

        [Test]
        public async Task WhenGetGeolocationAsyncIsCalled_ThenProperResultIsReturned()
        {
            const string address = "135.120.201.155";
            var sampleGeolocation = _helper.GetSampleGeolocations(address).First();
            _geoRepository.GetGeolocationAsync(Arg.Any<int>())
                .Returns(sampleGeolocation);

            var result = await _sut.GetGeolocationAsync(1);

            Assert.Multiple(async () =>
            {
                Assert.That(result, Is.Not.Null);
                _mapper.Received(1).Map<GeolocationDto>(Arg.Any<Entities.Geolocation>());
                await _geoRepository.Received(1).GetGeolocationAsync(Arg.Any<int>());
            });
        }

        [Test]
        public async Task WhenCreateGeolocationAsyncIsCalled_ThenProperResultIsReturned()
        {
            const string address = "135.120.201.155";
            var sampleGeolocationDetailsDto = _helper.GetSampleGeolocationDetailsDto(address);
            _collector.FetchGeolocationDetailsFromApiAsync(Arg.Any<string>())
                .Returns(sampleGeolocationDetailsDto);

            var result = await _sut.CreateGeolocationAsync(address);

            Assert.Multiple(async () =>
            {
                Assert.That(result, Is.Not.Null);
                _mapper.Received(1).Map<Entities.GeolocationDetails>(Arg.Any<GeolocationDetailsDto>());
                await _geoRepository.Received(1).CreateGeolocationAsync(Arg.Any<Entities.Geolocation>());
            });
        }

        [Test]
        public async Task WhenDeleteGeolocationAsyncIsCalled_ThenProperResultIsReturned()
        {
            const string address = "135.120.201.155";
            var sampleGeolocation = _helper.GetSampleGeolocations(address).First();
            _geoRepository.GeolocationExistsAsync(Arg.Any<int>()).Returns(true);
            _geoRepository.GetGeolocationAsync(Arg.Any<int>()).Returns(sampleGeolocation);

            var result = await _sut.DeleteGeolocationAsync(1);

            Assert.Multiple(() =>
            {
                Assert.That(result, Is.Not.Null);
            });
        }
    }
}