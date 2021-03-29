﻿using Microsoft.AspNetCore.Authorization;
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
    [Route("api/users")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IRepository<User> _repository;
        private readonly IJwtService _jwtService;
        private readonly IUserService _userService;
        public UserController(IUserService userService,IRepository<User> usersRepository, IJwtService jwtService)
        {
            _repository = usersRepository;
            _jwtService = jwtService;
            _userService = userService;
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

        [HttpPost("Register")]
        public ActionResult<User> Register(RegisterRequest registerRequest)
        {
            User user = _userService.UserValidator(registerRequest);
            if (user==null)
            {
                return BadRequest(Messages.DuplicateUsernameOrEmail);
            }            
            _repository.Create(user);
            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        [HttpPost("Authenticate")]
        public ActionResult Authenticate(AuthenticateRequest authenticateRequest)
        {
            User user = _repository.GetAll().SingleOrDefault(
                u => u.Username == authenticateRequest.Username &&
                u.Password == Crypto.SHA256(authenticateRequest.Password));

            if (user == null)
            {
                return BadRequest(Messages.InvalidCredentials);
            }

            AuthenticateResult authenticateResult = new AuthenticateResult
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
            User user =  _repository.GetById(id);
            if (user == null)
            {
                return NotFound(Messages.NotFoundMessage("User", id));
            }

            _repository.Remove(user);
            
            return NoContent();
        }

    }
}
