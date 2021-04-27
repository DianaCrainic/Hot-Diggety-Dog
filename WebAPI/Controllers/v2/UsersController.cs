using Application.Features.UserFeatures.Queries;
using Application.Features.UserFeatures.Commands;
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
using System.Web.Helpers;

namespace WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class UsersController : BaseApiController
    {
        private readonly IJwtService _jwtService;
        private readonly IFacebookAuthService _fbService;

        public UsersController(IMediator mediator, IJwtService jwtService, IFacebookAuthService fbService) : base(mediator)
        {
            _jwtService = jwtService;
            _fbService = fbService;
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
        [HttpPost("FBauthenticate")]
        public async Task<IActionResult> FBAuthenticate(FBAuthenticateRequest fbLoginRequest)
        {
            var validToken = await _fbService.ValidateAccessTokenAsync(fbLoginRequest.AccessToken);

            if (!validToken.tokenData.IsValid)
            {
                return BadRequest(Messages.FBLoginFailed);
            }

            var userInfo = await _fbService.GetUserInfoAsync(fbLoginRequest.AccessToken);

            CreateUserCommand command = new()
            {
                Username = $"{userInfo.FirstName}.{userInfo.LastName}",
                Email = userInfo.Email,
                Password = Crypto.SHA256($"{userInfo.FirstName}.{userInfo.LastName}"),
                Role = Role.CUSTOMER
            };

            User user = await mediator.Send(command);

            if (user == null)
            {
                user = await mediator.Send(new GetUserByUsernameAndPasswordQuery { Username = $"{userInfo.FirstName}.{userInfo.LastName}", Password = Crypto.SHA256($"{userInfo.FirstName}.{userInfo.LastName}") });
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
