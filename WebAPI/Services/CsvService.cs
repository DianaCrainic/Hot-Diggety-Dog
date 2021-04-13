using System.Collections.Generic;
using System.Text;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class CsvService : ICsvService
    {
        public string WriteOrderCsv(IEnumerable<Order> orders)
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
