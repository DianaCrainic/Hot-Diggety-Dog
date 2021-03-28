using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Resources;

namespace WebAPI.Helpers
{
    public class JwtMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly AppSettings _appSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            _next = next;
            _appSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, IRepository<User> repository)
        {
            string token = context.Request.Headers[Constants.AuthorizationHeader].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
            {
                Guid userId = ExtractUserIdFromToken(token);
                if (!userId.Equals(Guid.Empty))
                {
                    context.Items[Constants.UserItem] = repository.GetById(userId);
                }
            }

            await _next(context);
        }

        private Guid ExtractUserIdFromToken(string token)
        {
            try
            {
                JwtSecurityTokenHandler tokenHandler = new();
                byte[] key = Encoding.ASCII.GetBytes(_appSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                JwtSecurityToken jwtToken = (JwtSecurityToken)validatedToken;
                return Guid.Parse(jwtToken.Claims.First(x => x.Type == Constants.IdField).Value);
            }
            catch
            {
                // do nothing if JWT validation fails
                // user is not attached to context so request won't have access to secure routes
            }
            return Guid.Empty;
        }
    }
}
