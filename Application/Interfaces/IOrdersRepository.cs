using Domain.Entities;
using System.Linq;

namespace Application.Interfaces
{
    public interface IOrdersRepository : IRepository<Order>
    {
        IQueryable<Order> GetAllAsQueryable();
    }
}
