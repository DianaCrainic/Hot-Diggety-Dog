using System;

namespace WebAPI.Data
{
    public class AuthenticateResult
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Token { get; set; }
    }
}
