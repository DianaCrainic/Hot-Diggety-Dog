using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Entities;
using WebAPI.Helpers;
using WebAPI.Services;
using Xunit;

namespace HotDiggetyDogTests
{
    public class UsersControllerTests : IClassFixture<ControllersFixture>
    {
        private readonly ControllersFixture _controllersFixture;
        private const string SECRET = "JWT SECRET LONG KEY";

        public UsersControllerTests(ControllersFixture controllersFixture)
        {
            _controllersFixture = controllersFixture;
        }

        private UsersController Create_SystemUnderTest()
        {
            Repository<User> userRepository = new Repository<User>(_controllersFixture.DataContext);
            IOptions<AppSettings> appSettings = Options.Create(new AppSettings());
            appSettings.Value.Secret = SECRET;
            JwtService jwtService = new JwtService(appSettings);
            return new UsersController(userRepository, jwtService);
        }


        [Fact]
        public void GetUsers_ShouldReturn_OK()
        {
            UsersController usersController = Create_SystemUnderTest();

            // Act
            ActionResult<IEnumerable<User>> actionResult = usersController.GetUsers();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }


        [Fact]
        public void GetUserWithNew_GeneratedGuid_ShouldReturn_NotFound()
        {
            UsersController usersController = Create_SystemUnderTest();

            //Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<User> actionResult = usersController.GetUserById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public void DeleteUserWithNew_GeneratedGuid_ShouldReturn_NotFound()
        {
            UsersController usersController = Create_SystemUnderTest();

            //Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<User> actionResult = usersController.DeleteUser(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}
