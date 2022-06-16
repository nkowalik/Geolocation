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
    public class GeolocationControllerTests
    {
        private IConfiguration _config;
        private IFixture _fixture;
        private IGeolocationRepository _geoRepository;
        private IMapper _mapper;

        private GeolocationController _sut;

        [SetUp]
        public void Setup()
        {
            _fixture = new Fixture().Customize(new AutoNSubstituteCustomization
            {
                ConfigureMembers = false
            });
            _config = _fixture.Create<IConfiguration>();
            _geoRepository = _fixture.Create<IGeolocationRepository>();
            _mapper = _fixture.Create<IMapper>();
        }

        [Test]
        public async Task WhenGetGeolocationsAsyncIsCalled_ThenProperResultIsReturned()
        {
            const string address = "135.120.201.155";
            var sampleGeolocations = GetSampleGeolocations(address);
            _geoRepository.GetGeolocationsAsync()
                .ReturnsForAnyArgs(sampleGeolocations);
            _sut = new GeolocationController(_config, _geoRepository, _mapper);

            var result = await _sut.GetGeolocationsAsync();

            Assert.Multiple(async () =>
            {
                Assert.That(result, Is.Not.Null);
                _mapper.Received(1).Map<IEnumerable<GeolocationDto>>(Arg.Any<IEnumerable<Entities.Geolocation>>());
                await _geoRepository.Received(1).GetGeolocationsAsync(Arg.Any<string>());
            });
        }

        private IEnumerable<Entities.Geolocation> GetSampleGeolocations(string address)
        {
            return new List<Entities.Geolocation>
            {
                new Entities.Geolocation(address)
                {
                    Id = 1,
                    GeoDetails = new Entities.GeolocationDetails
                    {
                        Id = 2,
                        Ip = address,
                        Continent = "Europe",
                        ContinentCode = "EU",
                        Country = "Poland",
                        CountryCode = "PL",
                        Region = "Pomerania",
                        RegionCode = "PM",
                        City = "Gdansk",
                        Zip = "80-809",
                        Location = new Entities.Location
                        {
                            Id = 3,
                            Capital = "Warsaw",
                            Is_eu = true
                        },
                        Currency = new Entities.Currency
                        {
                            Id = 4,
                            Code = "PLN",
                            Name = "Polish Zloty"
                        }
                    }
                },
            };
        }
    }
}
