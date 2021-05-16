using Application.Features.HotDogStandsFeatures.Commands;
using Application.Features.HotDogStandsFeatures.Queries;
using Application.Features.StandProductsFeatures.Commands;
using Application.Features.UserFeatures.Queries;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Authorization;
using System;
using System.Threading.Tasks;
using WebApi.Resources;
using WebAPI.Controllers;

namespace WebApi.Controllers.v2
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

        [HttpGet("operator/{operatorId}")]
        public async Task<IActionResult> GetStandByOperator(Guid operatorId)
        {
            User operatorUser = await mediator.Send(new GetUserByIdQuery() { Id = operatorId });
            if (operatorUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, operatorId));
            }

            if (operatorUser.Role != Role.OPERATOR)
            {
                return BadRequest(Messages.InvalidData);
            }

            HotDogStand stand = await mediator.Send(new GetStandByOperatorQuery { OperatorId = operatorId });
            if (stand == null)
            {
                return NotFound(Messages.StandByOperatorNotFoundMessage(operatorId));
            }

            return Ok(stand);
        }

        [HttpPost("update-products")]
        public async Task<IActionResult> UpdateStandProductsByOrder(CreateOrderRequest order)
        {
            HotDogStand stand = await mediator.Send(new GetStandByOperatorQuery { OperatorId = order.OperatorId });

            if (stand == null)
            {
                return NotFound(Messages.StandByOperatorNotFoundMessage(order.OperatorId));
            }

            foreach (AddProductToOrderRequest product in order.Products)
            {
                Guid standProductId = await mediator.Send(new UpdateStandProductCommand { StandId = stand.Id, ProductId = product.ProductId, QuantityOrdered = product.Quantity });
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
