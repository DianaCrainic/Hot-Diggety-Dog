using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebAPI.Controllers;
using WebAPI.Data.Repository.v1;
using WebAPI.Entities;
using Xunit;

namespace HotDiggetyDogTests
{
    public class ProductsControllerTests : IClassFixture<ControllersFixture>
    {
        private readonly ControllersFixture _controllersFixture;
        private readonly ProductsController _productsController;

        public ProductsControllerTests(ControllersFixture controllersFixture)
        {
            _controllersFixture = controllersFixture;
            Repository<Product> productRepository = new(_controllersFixture.DataContext);
            _productsController = new ProductsController(productRepository);
        }

        [Fact]
        public async void GetProducts_ShouldReturn_OK()
        {
            // Act
            ActionResult<IEnumerable<Product>> actionResult = await _productsController.GetProducts();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Null_Product_ShouldReturn_BadRequest()
        {
            //Arrange
            Product product = null;

            // Act
            ActionResult<Product> actionResult = await _productsController.CreateProduct(product);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }
    }
}

