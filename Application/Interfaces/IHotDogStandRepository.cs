using Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IHotDogStandRepository : IRepository<HotDogStand>
    {
        Task<HotDogStand> GetStandByOperatorIdAsync(Guid id);
    }
}
