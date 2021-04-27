using System.ComponentModel.DataAnnotations;

namespace Domain.Dtos.Account
{
    public class FBAuthenticateRequest
    {
        [Required]
        public string AccessToken { get; set; }

    }
}
