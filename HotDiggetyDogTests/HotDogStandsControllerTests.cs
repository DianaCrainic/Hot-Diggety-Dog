using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Entities;
using Xunit;

namespace HotDiggetyDogTests
{
    public class HotDogStandsControllerTests : IClassFixture<ControllersFixture>
    {
        private readonly ControllersFixture _controllersFixture;

        public HotDogStandsControllerTests(ControllersFixture controllersFixture)
        {
            _controllersFixture = controllersFixture;
        }

        private HotDogStandsController Create_SystemUnderTest()
        {
            Repository<HotDogStand> hotDogStandRepository = new Repository<HotDogStand>(_controllersFixture.DataContext);
            return new HotDogStandsController(hotDogStandRepository);
        }


        [Fact]
        public void GetHotDogStands_ShouldReturn_OK()
        {
            HotDogStandsController hotDogStandsController = Create_SystemUnderTest();

            // Act
            ActionResult<IEnumerable<HotDogStand>> actionResult = hotDogStandsController.GetStands();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public void GetHotDogStandWithNew_GeneratedGuid_ShouldReturn_NotFound()
        {
            HotDogStandsController hotDogStandsController = Create_SystemUnderTest();

            //Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<HotDogStand> actionResult = hotDogStandsController.GetStandById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Create_Null_HotDogStand_ShouldReturn_BadRequest()
        {
            HotDogStandsController hotDogStandsController = Create_SystemUnderTest();

            //Arrange
            HotDogStand stand = null;

            // Act
            ActionResult<HotDogStand> actionResult = hotDogStandsController.CreateStand(stand);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void Update_New_HotDogStand_ShouldReturn_NotFound()
        {
            HotDogStandsController hotDogStandsController = Create_SystemUnderTest();

            //Arrange
            HotDogStand stand = new HotDogStand
            {
                Id = Guid.NewGuid(),
                Address = "New Adress"
            };

            // Act
            ActionResult<HotDogStand> actionResult = hotDogStandsController.UpdateStand(stand);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public void RemoveHotDogStandWithNew_GeneratedGuid_ShouldReturn_NotFound()
        {
            HotDogStandsController hotDogStandsController = Create_SystemUnderTest();

            //Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<HotDogStand> actionResult = hotDogStandsController.RemoveStand(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}

