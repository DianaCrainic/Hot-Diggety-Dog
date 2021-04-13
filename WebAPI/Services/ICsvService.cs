using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface ICsvService
    {
        string WriteOrderCsv(IEnumerable<Order> orders);
    }
}
