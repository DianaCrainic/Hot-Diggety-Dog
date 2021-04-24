using Application.Interfaces;
using Domain.Dtos;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApi.Extensions;
using WebApi.Resources;
using WebAPI.Controllers;
using Application.Features.OrderFeatures.Qureries;
using Application.Features.OrderFeatures.Commands;
using System.Linq;
using Security.Authorization;
using System.Text;
using Application.Features.UserFeatures.Queries;
using Application.Features.ProductFeatures.Queries;
using Application.Features.OrderProductFeatures.Commands;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v2
{
    [ApiVersion("2.0")]
    public class OrdersController : BaseApiController
    {


        private readonly IOrdersService _ordersService;
        public OrdersController(IMediator mediator,IOrdersService orderService) : base(mediator)
        {
            _ordersService = orderService;
        }

       


       
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrders([FromQuery] PaginationDto pagination)
        {
            var queryable = (await mediator.Send(new GetOrdersQuery())).AsQueryable();
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.EntitiesPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }
        
        [HttpGet("customers/{customerId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByCustomerId(Guid customerId, [FromQuery] PaginationDto pagination)
        {
            User customerUser = await mediator.Send(new GetUserByIdQuery(){Id=customerId}); 
            if (customerUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, customerId));
            }

            if (customerUser.Role != Role.CUSTOMER)
            {
                return BadRequest(Messages.InvalidData);
            }

            var queryable = (await mediator.Send(new GetOrdersByUserIdQuery() { Id = customerId })).AsQueryable();

            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.EntitiesPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        [HttpGet("operators/{operatorId}")]
        public async Task<ActionResult<IEnumerable<Order>>> GetOrdersByOperatorId(Guid operatorId, [FromQuery] PaginationDto pagination)
        {
            User operatorUser = await mediator.Send(new GetUserByIdQuery() { Id=operatorId}); 
            if (operatorUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, operatorId));
            }

            if (operatorUser.Role != Role.OPERATOR)
            {
                return BadRequest(Messages.InvalidData);
            }
            var queryable = (await mediator.Send(new GetOrdersByUserIdQuery() { Id = operatorId })).AsQueryable();
           
            await HttpContext.InsertPaginationParameterInResponse(queryable, pagination.EntitiesPerPage);
            return await queryable.Paginate(pagination).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrderById(Guid id)
        {
            Order order = await mediator.Send(new GetOrderByIdQuery() { Id=id}); 

            if (order == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.OrderEntity, id));
            }

            return Ok(await mediator.Send(new GetOrderByIdQuery() { Id=id }));
        }

        [RoleAuthorize("OPERATOR")]
        [HttpPost]
        public async Task<ActionResult> CreateOrder(CreateOrderCommand command)
        {
            if (command == null)
            {
                return BadRequest(Messages.InvalidData);
            }

            User operatorUser = await mediator.Send(new GetUserByIdQuery() {Id=command.UserId});
            if (operatorUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, command.OperatorId));
            }

            User customerUser = await mediator.Send(new GetUserByIdQuery() { Id = command.OperatorId });
            if (customerUser == null)
            {
                return NotFound(Messages.NotFoundMessage(EntitiesConstants.UserEntity, command.UserId));
            }

            if (operatorUser.Role != Role.OPERATOR || customerUser.Role != Role.CUSTOMER)
            {
                return BadRequest(Messages.InvalidData);
            }

            double totalPrice = 0;
            foreach (OrderProduct request in command.OrderProducts)
            {
                Product product = await mediator.Send(new GetProductByIdQuery() { Id = request.ProductId });
                if (product != null)
                {
                    totalPrice += product.Price * request.Quantity;
                }
                else
                {
                    return NotFound(Messages.NotFoundMessage(EntitiesConstants.ProductEntity, request.ProductId));
                }
            }

            Guid orderId =await  mediator.Send(new CreateOrderCommand() { OperatorId = command.OperatorId, UserId = command.UserId, Timestamp = command.Timestamp, Total = totalPrice });

            command.Total = totalPrice;
            await mediator.Send(command);
            foreach (OrderProduct request in command.OrderProducts)
            {
                await mediator.Send(new CreateOrderProductCommand()
                {
                    OrderId = orderId,
                    ProductId = request.ProductId,
                    Quantity = request.Quantity
                });
             
            }
            return CreatedAtAction("GetOrderById", new { id = orderId }, await mediator.Send( new GetOrderByIdQuery() { Id=orderId}));
        }
        
        [RoleAuthorize("ADMIN")]
        [HttpGet("export-csv")]
        public async Task<IActionResult> ExportOrdersAsCsv()
        {
            IEnumerable<Order> orders = await mediator.Send(new GetOrdersQuery());
            string result = _ordersService.ConvertToCsv(orders);
            return File(Encoding.UTF8.GetBytes(result), "text/csv", Constants.ReportFilename);
        }
    }

}
