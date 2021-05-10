using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System;
using System.Threading.Tasks;

namespace Persistence.Repository.v1
{
    public class HotDogStandRepository : Repository<HotDogStand>, IHotDogStandRepository
    {
        public HotDogStandRepository(DataContext context) : base(context)
        {

        }

        public async Task<HotDogStand> GetStandByOperatorId(Guid operatorId)
        {
            return await _context.HotDogStands
                .Include(stand => stand.StandProducts)
                .ThenInclude(standProduct => standProduct.Product)
                .FirstOrDefaultAsync(stand => stand.OperatorId == operatorId);
        }
    }
}
