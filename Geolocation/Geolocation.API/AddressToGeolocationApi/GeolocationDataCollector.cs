using Geolocation.Api.Models;
using Microsoft.Net.Http.Headers;
using Newtonsoft.Json;
using System.Net.Http;

namespace Geolocation.Api.AddressToGeolocationApi
{
    /// <summary>
    /// Collector of the geolocation data from ipstack API
    /// </summary>
    public class GeolocationDataCollector : IGeolocationDataCollector
    {
        private readonly IConfiguration _config;
        private readonly IHttpClientFactory _httpClientFactory;

        /// <summary>
        /// A constructor for GeolocationDataCollector
        /// </summary>
        /// <param name="config">Configuration containing access key value</param>
        /// <param name="httpClientFactory">Factory for http client</param>
        /// <exception cref="ArgumentNullException"></exception>
        public GeolocationDataCollector(IConfiguration config, IHttpClientFactory httpClientFactory)
        {
            _config = config;
            _httpClientFactory = httpClientFactory;
        }

        /// <summary>
        /// Collects geolocation details based on IP address
        /// </summary>
        /// <param name="address">IP address</param>
        /// <returns>GeolocationDetailsDto</returns>
        public async Task<GeolocationDetailsDto?> FetchGeolocationDetailsFromApiAsync(string address)
        {
            var accessKey = _config.GetValue<string>("Geolocation:AccessKey");
            using var httpClient = _httpClientFactory.CreateClient();

            var httpRequestMessage = new HttpRequestMessage(
            HttpMethod.Get,
            $"http://api.ipstack.com/{address}?access_key={accessKey}");

            var response = await httpClient.SendAsync(httpRequestMessage);

            if (response.IsSuccessStatusCode)
            {
                string apiResponse = await response.Content.ReadAsStringAsync();

                return JsonConvert.DeserializeObject<GeolocationDetailsDto>(apiResponse);
            }

            return null;
        }
    }
}
