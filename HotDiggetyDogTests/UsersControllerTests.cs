using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WebAPI.Controllers;
using WebAPI.Data.Repository.v1;
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
    }
}
