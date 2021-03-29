using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public interface IHotDogStandService
    {
        ActionResult<IEnumerable<HotDogStand>> GetStands();
        ActionResult<HotDogStand> GetStandById(Guid id);
        void CreateStand(HotDogStand stand);
        void UpdateStand(HotDogStand stand);
        void RemoveStand(HotDogStand stand);
    }
}
