namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the location information
    /// </summary>
    public class LocationDto
    {
        /// <summary>
        /// A geoname id
        /// </summary>
        public int Geoname_id { get; set; }
        /// <summary>
        /// A capital name
        /// </summary>
        public string? Capital { get; set; }
        /// <summary>
        /// A country flag (link)
        /// </summary>
        public string? Country_flag { get; set; }
        /// <summary>
        /// A country flag emoji
        /// </summary>
        public string? Country_flag_emoji { get; set; }
        /// <summary>
        /// A country flag emoji unicode
        /// </summary>
        public string? Country_flag_emoji_unicode { get; set; }
        /// <summary>
        /// A calling code
        /// </summary>
        public string? Calling_code { get; set; }
        /// <summary>
        /// Is the country in European Union
        /// </summary>
        public bool Is_eu { get; set; } = false;
        /// <summary>
        /// A collection of languages information
        /// </summary>
        public IEnumerable<LanguageDto> Languages = new List<LanguageDto>();
    }
}
