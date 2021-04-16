using Microsoft.AspNetCore.Mvc;
using System;
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

        [Fact]
        public async void Create_New_Product_ShouldReturn_CreatedAtAction()
        {
            //Arrange
            Product product = new Product
            {
                Id = Guid.Parse("9b6f4a18-526a-4d59-ba60-aa2429a8e174"),
                Name = "Product",
                Description = "Product Description",
                Category = "Product Category",
                Price = 20
            };

            // Act
            ActionResult<Product> actionResult = await _productsController.CreateProduct(product);

            // Assert
            Assert.IsType<CreatedAtActionResult>(actionResult.Result);
        }

        [Fact]
        public async void GetProductBy_Generated_Id_ShouldReturn_NotFound()
        {
            //Arrange
            Guid id = Guid.Parse("23737b93-4d76-4fc7-953d-0be0eae24786");

            // Act
            ActionResult<Product> actionResult = await _productsController.GetProductById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Update_Null_Product_ShouldReturn_BadRequest()
        {
            //Arrange
            Product product = null;

            // Act
            ActionResult<Product> actionResult = await _productsController.UpdateProduct(product);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Remove_NonExisting_Product_ShouldReturn_BadRequest()
        {
            //Arrange
            Guid id = Guid.Parse("0e9b0951-0788-4498-a694-f50a916c56b5");

            // Act
            ActionResult<Product> actionResult = await _productsController.RemoveProduct(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}

