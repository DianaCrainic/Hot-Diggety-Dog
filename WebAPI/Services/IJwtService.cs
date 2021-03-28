using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user);
    }
}
