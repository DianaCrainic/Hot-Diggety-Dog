using System;

namespace WebAPI.Dtos.Account
{
    public class AuthenticateResult
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
