namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the location information
    /// </summary>
    public class LocationDto
    {
        /// <summary>
        /// An id of the location
        /// </summary>
        public int Id { get; set; }
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
        /// Is the country in European Union
        /// </summary>
        public bool Is_eu { get; set; } = false;
        /// <summary>
        /// A collection of languages information
        /// </summary>
        public IEnumerable<LanguageDto> Languages = new List<LanguageDto>();
    }
}
