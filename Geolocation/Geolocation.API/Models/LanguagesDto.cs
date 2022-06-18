namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the language information
    /// </summary>
    public class LanguageDto
    {
        /// <summary>
        /// A code of the language
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// A language name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// A native language name
        /// </summary>
        public string? Native { get; set; }
    }
}
