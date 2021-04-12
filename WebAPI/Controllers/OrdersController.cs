using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Entities;
using WebAPI.Helpers.Authorization;
using WebAPI.Resources;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("api/v1/orders")]
    public class OrdersController : Controller
    {
        private readonly IRepository<Order> _ordersRepository;
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Product> _productsRepository;

        public OrdersController(IRepository<Order> ordersRepository, IRepository<User> usersRepository, IRepository<OrderProduct> orderPorductRepository, IRepository<Product> productsRepository)
        {
            _ordersRepository = ordersRepository;
            _usersRepository = usersRepository;
            _orderProductRepository = orderPorductRepository;
            _productsRepository = productsRepository;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Order>> GetOrders()
        {
            return Ok(_ordersRepository.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Order> GetOrderById(Guid id)
        {
            Order order = _ordersRepository.GetById(id);

            if (order == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.OrderEntity, id));
            }

            return Ok(order);
        }

        [RoleAuthorize(Role.OPERATOR)]
        [HttpPost]
        public ActionResult CreateOrder(CreateOrderRequest orderRequest)
        {
            if (orderRequest == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            User operatorUser = _usersRepository.GetById(orderRequest.OperatorId);
            User customerUser = _usersRepository.GetById(orderRequest.UserId);
            if (operatorUser.Role != Role.OPERATOR || customerUser.Role != Role.CUSTOMER)
            {
                return BadRequest(Messages.InvalidData);
            }

            double totalPrice = 0;
            foreach (AddProductToOrderRequest request in orderRequest.Products)
            {
                if (_productsRepository.GetById(request.ProductId) != null)
                {
                    totalPrice += _productsRepository.GetById(request.ProductId).Price * request.Quantity;
                }
                else
                {
                    return NotFound();
                }
            }

            Order order = new() { OperatorId = orderRequest.OperatorId, UserId = orderRequest.UserId, Timestamp = orderRequest.Timestamp, Total = totalPrice };
            _ordersRepository.Create(order);
            foreach (AddProductToOrderRequest request in orderRequest.Products)
            {
                _orderProductRepository.Create(new OrderProduct()
                {
                    OrderId = order.Id,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                });
            }
            return CreatedAtAction("GetOrderById", new { id = order.Id }, order);
        }
    }
}
