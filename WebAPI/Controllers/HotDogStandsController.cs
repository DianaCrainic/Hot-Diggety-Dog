using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Helpers.Authorization;
using WebAPI.Resources;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/stands")]
    public class HotDogStandsController : ControllerBase
    {
        private readonly IRepository<HotDogStand> _repository;

        public HotDogStandsController(IRepository<HotDogStand> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<HotDogStand>> GetStands()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<HotDogStand> GetStandById(Guid id)
        {
            HotDogStand stand = _repository.GetById(id);

            if (stand == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            return Ok(stand);
        }

        [RoleAuthorize("ADMIN")]
        [HttpPost]
        public ActionResult CreateStand(HotDogStand stand)
        {
            if (stand == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            _repository.Create(stand);
            return CreatedAtAction("GetStandById", new { id = stand.Id }, stand);
        }

        [RoleAuthorize("ADMIN")]
        [HttpPut]
        public ActionResult UpdateStand(HotDogStand stand)
        {
            if (stand == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            if (!_repository.Exists(stand))
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, stand.Id));
            }

            _repository.Update(stand);
            return NoContent();
        }

        [RoleAuthorize("ADMIN")]
        [HttpDelete]
        public ActionResult RemoveStand(Guid id)
        {
            HotDogStand stand = _repository.GetById(id);

            if (stand == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            _repository.Remove(stand);
            return NoContent();
        }
    }
}
