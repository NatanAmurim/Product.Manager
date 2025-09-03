using System.ComponentModel.DataAnnotations;

namespace ProductManager.Api.Presentation.Controllers.Contracts.Requests.Login
{
    public class LoginRequest
    {
        [Required]
        public string UserName { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}
