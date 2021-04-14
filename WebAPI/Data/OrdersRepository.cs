using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WebAPI.Entities;

namespace WebAPI.Data
{
    public class OrdersRepository : Repository<Order>
    {
        public OrdersRepository(DataContext context) : base(context)
        {
        }

        public override Order GetById(Guid id)
        {
            return _context.Orders.Include(order => order.OrderProducts).ThenInclude(orderProduct => orderProduct.Product).FirstOrDefault(order => order.Id == id);
        }
    }
}
