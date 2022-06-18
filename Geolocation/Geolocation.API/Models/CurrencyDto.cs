namespace Geolocation.Api.Models
{
    /// <summary>
    /// A DTO for the currency information
    /// </summary>
    public class CurrencyDto
    {
        /// <summary>
        /// A currency code
        /// </summary>
        public string? Code { get; set; }
        /// <summary>
        /// A currency name
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// A currency plural name
        /// </summary>
        public string? Plural { get; set; }
        /// <summary>
        /// A currency symbol
        /// </summary>
        public string? Symbol { get; set; }
        /// <summary>
        /// A currency native symbol
        /// </summary>
        public string? Symbol_native { get; set; }
    }
}