using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI.Controllers;
using WebAPI.Data.Repository.v1;
using WebAPI.Dtos;
using WebAPI.Entities;
using WebAPI.Services;
using Xunit;

namespace HotDiggetyDogTests
{
    public class OrdersControllerTests : DatabaseBaseTest
    {
        private readonly OrdersController _ordersController;

        public OrdersControllerTests()
        {
            OrdersRepository orderRepository = new(dataContext);
            UsersRepository userRepository = new(dataContext);
            Repository<OrderProduct> orderPorductRepository = new(dataContext);
            Repository<Product> productsRepository = new(dataContext);
            CsvService csvService = new();

            _ordersController = new OrdersController(orderRepository, userRepository, orderPorductRepository,
                                                        productsRepository, csvService);
        }

        [Fact]
        public async void GetOrderBy_Generated_Id_ShouldReturn_NotFound()
        {
            //Arrange
            Guid id = Guid.Parse("8d63df60-fa0d-40a0-9a98-6ace7ea6db43");

            // Act
            ActionResult<Order> actionResult = await _ordersController.GetOrderById(id);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Null_Order_ShouldReturn_BadRequest()
        {
            //Arrange
            CreateOrderRequest createOrderRequest = null;

            // Act
            ActionResult<Order> actionResult = await _ordersController.CreateOrder(createOrderRequest);

            // Assert
            Assert.IsType<BadRequestObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Order_With_Null_Opearator_ShouldReturn_NotFound()
        {
            //Arrange
            CreateOrderRequest createOrderRequest = new()
            {
                OperatorId = Guid.Empty,
                UserId = Guid.Parse("d9500fbb-0b51-4a1d-9e65-dd88dd7389ee"),
                Products = null,
                Timestamp = DateTime.Now
            };

            // Act
            ActionResult<Order> actionResult = await _ordersController.CreateOrder(createOrderRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Order_With_Null_Customer_ShouldReturn_NotFound()
        {
            //Arrange
            CreateOrderRequest createOrderRequest = new()
            {
                OperatorId = Guid.Parse("d9605834-2d64-416c-9e33-af9cc5c04735"),
                UserId = Guid.Empty,
                Products = null,
                Timestamp = DateTime.Now
            };

            // Act
            ActionResult<Order> actionResult = await _ordersController.CreateOrder(createOrderRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }

        [Fact]
        public async void Create_Order_With_Null_Products_ShouldReturn_NotFound()
        {
            //Arrange
            CreateOrderRequest createOrderRequest = new()
            {
                OperatorId = Guid.Parse("9297b757-42e9-4338-86e2-d66771ee7d56"),
                UserId = Guid.Parse("209cbf69-2082-4bfc-8216-03b654523106"),
                Products = null,
                Timestamp = DateTime.Now
            };

            // Act
            ActionResult<Order> actionResult = await _ordersController.CreateOrder(createOrderRequest);

            // Assert
            Assert.IsType<NotFoundObjectResult>(actionResult.Result);
        }
    }
}
