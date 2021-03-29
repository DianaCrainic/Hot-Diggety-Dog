using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IUserService
    {
        public User UserValidator(RegisterRequest registerRequest);
    }
}
