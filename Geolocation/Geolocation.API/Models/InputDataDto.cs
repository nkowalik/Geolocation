using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Geolocation.Api.Models
{
    [Route("api/[controller]")]
    [ApiController]
    public class InputDataDto : ControllerBase
    {
        [Required(ErrorMessage = "You should provide a URL or IP address")]
        [MaxLength(200)]
        public string Address { get; set; } = string.Empty;
    }
}
