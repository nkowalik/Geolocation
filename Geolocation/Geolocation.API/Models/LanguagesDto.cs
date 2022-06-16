namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the language information
    /// </summary>
    public class LanguageDto
    {
        /// <summary>
        /// An id of the language
        /// </summary>
        public int Id { get; set; }
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
