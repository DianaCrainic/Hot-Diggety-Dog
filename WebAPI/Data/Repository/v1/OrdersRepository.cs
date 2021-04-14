using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Data.Context;
using WebAPI.Entities;

namespace WebAPI.Data.Repository.v1
{
    public class OrdersRepository : Repository<Order>, IOrdersRepository
    {
        public OrdersRepository(DataContext context) : base(context)
        {

        }

        public IQueryable<Order> GetAllAsQueryable()
        {
            return _context.Orders.AsQueryable();
        }

        public override async Task<Order> GetByIdAsync(Guid id)
        {
            return await _context.Orders.Include(order => order.OrderProducts)
                                  .ThenInclude(orderProduct => orderProduct.Product)
                                  .FirstOrDefaultAsync(order => order.Id == id);
        }
    }
}
