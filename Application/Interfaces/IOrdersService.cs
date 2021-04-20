using Domain.Entities;
using System.Collections.Generic;

namespace Application.Interfaces
{
    public interface IOrdersService
    {
        string ConvertToCsv(IEnumerable<Order> orders);
    }
}
