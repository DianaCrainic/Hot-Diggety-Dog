using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Security.Services;
using Security.Settings;

namespace Security
{
    public static class SecurityDI
    {
        public static void AddSecurity(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(typeof(IJwtService), typeof(JwtService))
                .Configure<SecuritySettings>(configuration.GetSection("SecuritySettings"));
        }
    }
}
