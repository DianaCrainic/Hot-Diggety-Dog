using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Entities;

namespace WebAPI.Data.Repository.v1
{
    public interface IUsersRepository : IRepository<User>
    {
        Task<User> GetByUsernameAndPassword(string username, string password);
        Task<IEnumerable<User>> GetAllByRoleAsync(Role role);
        Task<bool> ExistsByEmailAsync(string email);
        Task<bool> ExistsByUsernameAsync(string username);
    }
}
