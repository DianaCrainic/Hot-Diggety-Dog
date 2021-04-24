using Application.Features.UserFeatures.Command;
using Application.Features.UserFeatures.Queries;
using Domain.Dtos.Account;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Security.Authorization;
using Security.Services;
using System;
using System.Threading.Tasks;
using WebApi.Resources;
using WebAPI.Controllers;

namespace WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class UsersController : BaseApiController
    {
        private readonly IJwtService _jwtService;

        public UsersController(IMediator mediator, IJwtService jwtService) : base(mediator)
        {
            _jwtService = jwtService;
        }

        [RoleAuthorize("ADMIN")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            return Ok(await mediator.Send(new GetUsersQuery()));
        }

        [RoleAuthorize("ADMIN,OPERATOR")]
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

            User user = await mediator.Send(command);
            if (user == null)
            {
                return BadRequest(Messages.DuplicateUsernameOrEmail);
            }

            return CreatedAtAction("GetUserById", new { id = user.Id }, user);
        }


        [HttpPost("authenticate")]
        public async Task<IActionResult> Authenticate(AuthenticateUserQuery query)
        {
            User user = await mediator.Send(new GetUserByUsernameAndPasswordQuery { Username = query.Username, Password = query.Password });

            if (query == null || user == null)
            {
                return BadRequest(Messages.InvalidCredentials);
            }

            AuthenticateResult authenticateResult = new()
            {
                Id = user.Id,
                Username = user.Username,
                Role = user.Role.ToString(),
                Token = _jwtService.GenerateJwtToken(user)
            };

            return Ok(authenticateResult);
        }


        [RoleAuthorize("ADMIN")]
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
