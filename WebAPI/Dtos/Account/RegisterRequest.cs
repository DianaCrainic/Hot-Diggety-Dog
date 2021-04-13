using System.ComponentModel.DataAnnotations;
using WebAPI.Resources;

namespace WebAPI.Dtos.Account
{
    public class RegisterRequest
    {
        [Required]
        public string Username { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = Messages.InvalidEmail)]
        public string Email { get; set; }

        [Required]
        [MinLength(6, ErrorMessage = Messages.PasswordLengthError)]
        public string Password { get; set; }
    }
}
