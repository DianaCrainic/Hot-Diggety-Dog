using Application.Features.HotDogStandsFeatures.Commands;
using Application.Features.HotDogStandsFeatures.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Authorization;
using System;
using System.Threading.Tasks;
using WebApi.Resources;

namespace WebAPI.Controllers.v2
{
    [ApiVersion("2.0")]
    public class HotDogStandsController : BaseApiController
    {
        public HotDogStandsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetStands()
        {
            return Ok(await mediator.Send(new GetStandsQuery()));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStandById(Guid id)
        {
            HotDogStand stand = await mediator.Send(new GetStandByIdQuery { Id = id });

            if (stand == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            return Ok(stand);
        }

        [RoleAuthorize("ADMIN")]
        [HttpPost]
        public async Task<IActionResult> CreateStand([FromBody] CreateStandCommand command)
        {
            if (command == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            return Ok(await mediator.Send(command));
        }

        [RoleAuthorize("ADMIN")]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateStand(Guid id, [FromBody] UpdateStandCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            Guid standId = await mediator.Send(command);
            if (standId == Guid.Empty)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            return NoContent();
        }

        [RoleAuthorize("ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> RemoveStand(Guid id)
        {
            Guid standId = await mediator.Send(new DeleteStandCommand { Id = id });
            if (standId == Guid.Empty)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.HotDogStandEntity, id));
            }

            return NoContent();
        }
    }
}
