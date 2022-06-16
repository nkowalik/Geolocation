using Geolocation.Api.Models;

namespace Geolocation.Api.Tests.Controllers
{
    public class ResourceHelper
    {
        public IEnumerable<Entities.Geolocation> GetSampleGeolocations(string address)
        {
            return new List<Entities.Geolocation>
            {
                new Entities.Geolocation(address)
                {
                    Id = 1,
                    GeoDetails = GetSampleGeolocationDetails(address)
                },
            };
        }

        public Entities.GeolocationDetails GetSampleGeolocationDetails(string address)
        {
            return new Entities.GeolocationDetails
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
            };
        }

        public GeolocationDetailsDto GetSampleGeolocationDetailsDto(string address)
        {
            return new GeolocationDetailsDto
            {
                Id = 2,
                Ip = address,
                Continent_name = "Europe",
                Continent_code = "EU",
                Country_name = "Poland",
                Country_code = "PL",
                Region_name = "Pomerania",
                Region_code = "PM",
                City = "Gdansk",
                Zip = "80-809",
                Location = new LocationDto
                {
                    Id = 3,
                    Capital = "Warsaw",
                    Is_eu = true
                },
                Currency = new CurrencyDto
                {
                    Id = 4,
                    Code = "PLN",
                    Name = "Polish Zloty"
                }
            };
        }
    }
}
