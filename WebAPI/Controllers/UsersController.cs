using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Helpers;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Resources;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [Route("api/v1/users")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IRepository<User> _repository;
        private readonly IJwtService _jwtService;

        public UsersController(IRepository<User> usersRepository, IJwtService jwtService)
        {
            _repository = usersRepository;
            _jwtService = jwtService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<User>> GetUsers()
        {
            return Ok(_repository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<User> GetUser(Guid id)
        {
            User user = _repository.GetById(id);

            if (user == null)
            {
                return NotFound(Messages.NotFoundMessage("User", id));
            }

            return Ok(user);
        }

        [HttpPost("register")]
        public ActionResult<User> Register(RegisterRequest registerRequest)
        {
            if (UserWithEmailExists(registerRequest.Email) || UserWithUsernameExists(registerRequest.Username))
            {
                return BadRequest(Messages.DuplicateUsernameOrEmail);
            }

            User user = new()
            {
                Email = registerRequest.Email,
                Username = registerRequest.Username,
                Password = Crypto.SHA256(registerRequest.Password)
            };

            _repository.Create(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("authenticate")]
        public ActionResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            User user = _repository.GetAll().SingleOrDefault(
                u => u.Username == authenticateRequest.Username &&
                u.Password == Crypto.SHA256(authenticateRequest.Password));

            if (user == null)
            {
                return BadRequest(Messages.InvalidCredentials);
            }

            AuthenticateResult authenticateResult = new()
            {
                Id = user.Id,
                Username = user.Username,
                Token = _jwtService.GenerateJwtToken(user)
            };

            return Ok(authenticateResult);
        }

        [HttpDelete("{id}")]
        public ActionResult<User> DeleteUser(Guid id)
        {
            User user = _repository.GetById(id);
            if (user == null)
            {
                return NotFound(Messages.NotFoundMessage("User", id));
            }

            _repository.Remove(user);

            return NoContent();
        }

        private bool UserWithEmailExists(string email)
        {
            return _repository.GetAll().Where(u => u.Email == email).Any();
        }

        private bool UserWithUsernameExists(string username)
        {
            return _repository.GetAll().Where(u => u.Username == username).Any();
        }
    }
}
