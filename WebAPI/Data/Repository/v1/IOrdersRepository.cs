using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Data.Repository.v1
{
    public interface IOrdersRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllAsQueryable();
    }
}
