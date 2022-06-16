using AutoMapper;
using Geolocation.Api.Models;
using Geolocation.Api.Services;
using Newtonsoft.Json;

namespace Geolocation.Api.AddressToGeolocationApi
{
    public class GeolocationDataCollector : IGeolocationDataCollector
    {
        private readonly IConfiguration _config;

        public GeolocationDataCollector(IConfiguration config,
            IGeolocationRepository geolocationRepository,
            IMapper mapper)
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));
        }

        public async Task<GeolocationDetailsDto?> FetchGeolocationDetailsFromApiAsync(string address)
        {
            var accessKey = _config.GetValue<string>("Geolocation:AccessKey");
            using var httpClient = new HttpClient();
            using var response = await httpClient
                .GetAsync($"http://api.ipstack.com/{address}?access_key={accessKey}");
            string apiResponse = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<GeolocationDetailsDto>(apiResponse);
        }
    }
}
