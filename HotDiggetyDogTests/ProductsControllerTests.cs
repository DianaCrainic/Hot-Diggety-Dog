using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Controllers;
using WebAPI.Data;
using WebAPI.Entities;
using Xunit;

namespace HotDiggetyDogTests
{
    public class ProductsControllerTests : IClassFixture<ControllersFixture>
    {
        private readonly ControllersFixture _controllersFixture;

        public ProductsControllerTests(ControllersFixture controllersFixture)
        {
            _controllersFixture = controllersFixture;
        }

        private ProductsController Create_SystemUnderTest()
        {
            Repository<Product> productRepository = new Repository<Product>(_controllersFixture.DataContext);
            return new ProductsController(productRepository);
        }


        [Fact]
        public void GetProducts_ShouldReturn_OK()
        {
            ProductsController productsController = Create_SystemUnderTest();

            // Act
            ActionResult<IEnumerable<Product>> actionResult = productsController.GetProducts();

            // Assert
            Assert.IsType<OkObjectResult>(actionResult.Result);
        }


        [Fact]
        public void GetProductWithNew_GeneratedGuid_ShouldReturn_NotFound()
        {
            ProductsController productsController = Create_SystemUnderTest();

            //Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<Product> actionResult = productsController.GetProductById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }


        [Fact]
        public void Create_Null_Product_ShouldReturn_BadRequest()
        {
            ProductsController productsController = Create_SystemUnderTest();

            //Arrange
            Product product = null;

            // Act
            ActionResult<Product> actionResult = productsController.CreateProduct(product);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public void RemoveProductWithNew_GeneratedGuid_ShouldReturn_NotFound()
        {
            ProductsController productsController = Create_SystemUnderTest();

            //Arrange
            Guid id = Guid.NewGuid();

            // Act
            ActionResult<Product> actionResult = productsController.RemoveProduct(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}

