using System;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class AuthenticateResult
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Role { get; set; }
        public string Token { get; set; }
    }
}
