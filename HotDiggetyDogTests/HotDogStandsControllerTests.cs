using Microsoft.AspNetCore.Mvc;
using System;
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

        [Fact]
        public async void Create_New_HotDogStand_ShouldReturn_CreatedAtAction()
        {
            //Arrange
            HotDogStand hotDogStand = new HotDogStand
            {
                Id = new Guid("27ddd60f-7b93-4e51-93a7-c0b53c3c9850"),
                Address = "Address"
            };

            // Act
            ActionResult<HotDogStand> actionResult = await _hotDogStandsController.CreateStand(hotDogStand);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }

        [Fact]
        public async void GetHotDogStandBy_Generated_Id_ShouldReturn_NotFound()
        {
            //Arrange
            Guid id = Guid.Parse("f7cb8e84-b440-4b6f-886e-496cc5dc3ccd");

            // Act
            ActionResult<HotDogStand> actionResult = await _hotDogStandsController.GetStandById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Update_Null_HotDogStand_ShouldReturn_BadRequest()
        {
            //Arrange
            HotDogStand hotDogStand = null;

            // Act
            ActionResult<HotDogStand> actionResult = await _hotDogStandsController.UpdateStand(hotDogStand);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Remove_NonExisting_HotDogStand_ShouldReturn_BadRequest()
        {
            //Arrange
            Guid id = Guid.Parse("0e9b0951-0788-4498-a694-f50a916c56b5");

            // Act
            ActionResult<HotDogStand> actionResult = await _hotDogStandsController.RemoveStand(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}

