using Geolocation.Api.Models;
using Newtonsoft.Json;

namespace Geolocation.Api.AddressToGeolocationApi
{
    /// <summary>
    /// Collector of the geolocation data from ipstack API
    /// </summary>
    public class GeolocationDataCollector : IGeolocationDataCollector
    {
        private readonly IConfiguration _config;

        /// <summary>
        /// A constructor for GeolocationDataCollector
        /// </summary>
        /// <param name="config">Configuration containing access key value</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GeolocationDataCollector(IConfiguration config)
        {
            _config = config ??
                throw new ArgumentNullException(nameof(config));
        }

        /// <summary>
        /// Collects geolocation details based on IP address
        /// </summary>
        /// <param name="address">IP address</param>
        /// <returns>GeolocationDetailsDto</returns>
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
