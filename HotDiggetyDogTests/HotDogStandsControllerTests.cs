using Microsoft.AspNetCore.Mvc;
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
        private const string SECRET = "JWT SECRET LONG KEY";

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
    }
}

