using System.ComponentModel.DataAnnotations;

namespace CORS.API.Controllers
{
    public class LoginViewModel
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
