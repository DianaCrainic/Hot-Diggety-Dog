using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Data.Repository.v1;
using WebAPI.Dtos.Account;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Services;
using Xunit;

namespace HotDiggetyDogTests
{
    public class UsersControllerTests : IClassFixture<ControllersFixture>
    {
        private readonly ControllersFixture _controllersFixture;
        private readonly UsersController _usersController;
        private const string SECRET = "JWT SECRET LONG KEY";

        public UsersControllerTests(ControllersFixture controllersFixture)
        {
            _controllersFixture = controllersFixture;
            UsersRepository userRepository = new(_controllersFixture.DataContext);
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings());
            appSettings.Value.Secret = SECRET;
            JwtService jwtService = new(appSettings);
            _usersController = new UsersController(userRepository, jwtService);
        }

        [Fact]
        public async void GetUsers_ShouldReturn_OK()
        {
            // Act
            ActionResult<IEnumerable<User>> actionResult = await _usersController.GetUsersAsync();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }


        [Fact]
        public async void GetCustomers_ShouldReturn_OK()
        {
            // Act
            ActionResult<IEnumerable<User>> actionResult = await _usersController.GetCustomers();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void GetUserBy_Generated_Id_ShouldReturn_NotFound()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<User> actionResult = await _usersController.GetUserById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void RegisterRequestFor_New_User_ShouldReturn_CreatedAtAction()
        {
            // Arrange
            RegisterRequest registerRequest = new RegisterRequest
            {
                Username = "admin2",
                Email = "admin2@gmail.com",
                Password = "admin2"
            };

            // Act
            ActionResult<User> actionResult = await _usersController.Register(registerRequest);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }

        [Fact]
        public async void AuthenticateRequestFor_NonExisting_User_ShouldReturn_BadRequest()
        {
            // Arrange
            AuthenticateRequest authenticateRequest = new AuthenticateRequest
            {
                Username = "administrator",
                Password = "administrator"
            };

            // Act
            ActionResult<User> actionResult = await _usersController.Authenticate(authenticateRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Delete_NonExisting_User_ShouldReturn_NotFound()
        {
            // Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<User> actionResult = await _usersController.DeleteUser(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

    }
}
