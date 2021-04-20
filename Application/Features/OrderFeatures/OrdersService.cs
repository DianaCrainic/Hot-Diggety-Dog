using Application.Interfaces;
using Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace Application.Features.OrderFeatures
{
    public class OrdersService : IOrdersService
    {
        public string ConvertToCsv(IEnumerable<Order> orders)
        {
            StringBuilder stringBuilder = new();
            stringBuilder.AppendLine("Id,OperatorId,CustomerId,Date,Total");
            foreach (Order order in orders)
            {
                stringBuilder.AppendLine($"{order.Id},{order.OperatorId},{order.UserId},{order.Timestamp},{order.Total}");
            }
            return stringBuilder.ToString();
        }
    }
}
