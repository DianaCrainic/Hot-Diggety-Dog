using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Data.Repository.v1;
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
        public async Task<ActionResult<IEnumerable<HotDogStand>>> GetStands()
        {
            return Ok(await _repository.GetAllAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<HotDogStand>> GetStandById(Guid id)
        {
            HotDogStand stand = await _repository.GetByIdAsync(id);

            if (stand == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            return Ok(stand);
        }

        [RoleAuthorize("ADMIN")]
        [HttpPost]
        public async Task<ActionResult> CreateStand(HotDogStand stand)
        {
            if (stand == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            await _repository.CreateAsync(stand);
            return CreatedAtAction("GetStandById", new { id = stand.Id }, stand);
        }

        [RoleAuthorize("ADMIN")]
        [HttpPut]
        public async Task<ActionResult> UpdateStand(HotDogStand stand)
        {
            if (stand == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            if (! await _repository.ExistsAsync(stand.Id))
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, stand.Id));
            }

            await _repository.UpdateAsync(stand);
            return NoContent();
        }

        [RoleAuthorize("ADMIN")]
        [HttpDelete]
        public async Task<ActionResult> RemoveStand(Guid id)
        {
            HotDogStand stand = await _repository.GetByIdAsync(id);
            if (stand == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            await _repository.RemoveAsync(stand);
            return NoContent();
        }
    }
}
