using Application.Features.UserFeatures.Command;
using Application.Features.UserFeatures.Queries;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using WebApi.Resources;
using WebAPI.Controllers;

namespace WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class UsersController : BaseApiController
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        //[RoleAuthorize("ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await mediator.Send(new GetUsersQuery()));
        }

        //[RoleAuthorize("ADMIN,OPERATOR")]
        [HttpGet("customers")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await mediator.Send(new GetCustomersQuery()));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(Guid id)
        {
            User user = await mediator.Send(new GetUserByIdQuery { Id = id });

            if (user == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, id));
            }

            return Ok(user);
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(CreateUserCommand command)
        {
            if (command == null)
            {
                return BadRequest(Messages.DuplicateUsernameOrEmail);
            }

            await mediator.Send(command);
            return Ok(command.Username);
        }


        //[HttpPost("authenticate")]
        //public async Task<ActionResult> Authenticate(AuthenticateRequest authenticateRequest)
        //{
        //    User user = await _repository.GetByUsernameAndPassword(authenticateRequest.Username, authenticateRequest.Password);

        //    if (user == null)
        //    {
        //        return BadRequest(Messages.InvalidCredentials);
        //    }

        //    AuthenticateResult authenticateResult = new()
        //    {
        //        Id = user.Id,
        //        Username = user.Username,
        //        Role = user.Role.ToString(),
        //        Token = _jwtService.GenerateJwtToken(user)
        //    };

        //    return Ok(authenticateResult);
        //}


        //[RoleAuthorize("ADMIN")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(Guid id)
        {
            Guid userId = await mediator.Send(new DeleteUserCommand { Id = id });
            if (userId == Guid.Empty)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, id));
            }

            return NoContent();
        }
    }
}
