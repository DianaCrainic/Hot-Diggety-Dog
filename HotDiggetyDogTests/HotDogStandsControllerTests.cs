using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Controllers;
using WebAPI.Data.Repository.v1;
using WebAPI.Entities;
using Xunit;

namespace HotDiggetyDogTests
{
    public class HotDogStandsControllerTests : IClassFixture<ControllersFixture>
    {
        private readonly ControllersFixture _controllersFixture;
        private readonly HotDogStandsController _hotDogStandsController;

        public HotDogStandsControllerTests(ControllersFixture controllersFixture)
        {
            _controllersFixture = controllersFixture;
            Repository<HotDogStand> hotDogStandRepository = new(_controllersFixture.DataContext);
            _hotDogStandsController = new HotDogStandsController(hotDogStandRepository);
        }

        [Fact]
        public async void GetHotDogStands_ShouldReturn_OK()
        {
            // Act
            ActionResult<IEnumerable<HotDogStand>> actionResult = await _hotDogStandsController.GetStands();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Null_HotDogStand_ShouldReturn_BadRequest()
        {
            //Arrange
            HotDogStand stand = null;

            // Act
            ActionResult<HotDogStand> actionResult = await _hotDogStandsController.CreateStand(stand);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
    }
}

