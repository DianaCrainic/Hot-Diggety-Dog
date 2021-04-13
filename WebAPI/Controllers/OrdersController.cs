using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data;
using WebAPI.Dtos;
using WebAPI.Entities;
using WebAPI.Helpers.Authorization;
using WebAPI.Helpers.Extensions;
using WebAPI.Resources;
using WebAPI.Services;

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
        private readonly ICsvService _csvService;

        public OrdersController(IRepository<Order> ordersRepository, IRepository<User> usersRepository,
                                IRepository<OrderProduct> orderPorductRepository, IRepository<Product> productsRepository,
                                ICsvService csvService)
        {
            _ordersRepository = ordersRepository;
            _usersRepository = usersRepository;
            _orderProductRepository = orderPorductRepository;
            _productsRepository = productsRepository;
            _csvService = csvService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders([FromQuery] PaginationDto pagination)
        {
            var queryable = _ordersRepository.GetAll().AsQueryable();
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.EntitiesPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        [HttpGet("customers/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerId(Guid customerId, [FromQuery] PaginationDto pagination)
        {
            User customerUser = _usersRepository.GetById(customerId);
            if (customerUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, customerId));
            }

            if (customerUser.Role != Role.CUSTOMER)
            {
                return BadRequest(Messages.InvalidData);
            }

            var queryable = _ordersRepository.GetAll().AsQueryable().Where(order => order.UserId == customerId);
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.EntitiesPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        [HttpGet("operators/{operatorId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByOperatorId(Guid operatorId, [FromQuery] PaginationDto pagination)
        {
            User operatorUser = _usersRepository.GetById(operatorId);
            if (operatorUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, operatorId));
            }

            if (operatorUser.Role != Role.OPERATOR)
            {
                return BadRequest(Messages.InvalidData);
            }

            var queryable = _ordersRepository.GetAll().AsQueryable().Where(order => order.UserId == operatorId);
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.EntitiesPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
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
            if (operatorUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, orderRequest.OperatorId));
            }

            User customerUser = _usersRepository.GetById(orderRequest.UserId);
            if (customerUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, orderRequest.UserId));
            }

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

        [HttpGet("export-csv")]
        public IActionResult ExportOrdersAsCsv()
        {
            IEnumerable<Order> orders = _ordersRepository.GetAll();
            string result = _csvService.WriteOrderCsv(orders);
            return File(Encoding.UTF8.GetBytes(result), "text/csv", Constants.ReportFilename);
        }
    }
}
