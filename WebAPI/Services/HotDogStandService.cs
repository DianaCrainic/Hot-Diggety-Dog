using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebAPI.Data;
using WebAPI.Entities;

namespace WebAPI.Services
{
    public class HotDogStandService : IHotDogStandService
    {
        private readonly IRepository<HotDogStand> _repository;

        public HotDogStandService(IRepository<HotDogStand> repository)
        {
            _repository = repository;
        }

        public ActionResult<IEnumerable<HotDogStand>> GetStands()
        {
            return _repository.GetAll().ToList();
        }

        public ActionResult<HotDogStand> GetStandById(Guid id)
        {
            return _repository.GetById(id);
        }

        public void CreateStand(HotDogStand stand)
        {
            _repository.Create(stand);
        }

        public void UpdateStand(HotDogStand stand)
        {
            _repository.Update(stand);
        }

        public void RemoveStand(HotDogStand stand)
        {
            _repository.Remove(stand);
        }
    }
}
