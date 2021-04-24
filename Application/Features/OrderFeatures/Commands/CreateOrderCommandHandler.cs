

using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {


        private readonly IOrdersRepository _ordersRepository;
        private readonly IRepository<User> _usersRepository;
        private readonly IRepository<OrderProduct> _orderProductRepository;
        private readonly IRepository<Product> _productsRepository;
        private readonly IOrdersService _ordersService;

        public CreateOrderCommandHandler(IMediator mediator, IOrdersRepository ordersRepository, IRepository<User> usersRepository,
                                IRepository<OrderProduct> orderPorductRepository, IRepository<Product> productsRepository,
                                IOrdersService ordersService)
        {
            _ordersRepository = ordersRepository;
            _usersRepository = usersRepository;
            _orderProductRepository = orderPorductRepository;
            _productsRepository = productsRepository;
            _ordersService = ordersService;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            Product product = new()
            {
                Name = request.Name,
                Price = request.Price,
                Description = request.Description,
                Category = request.Category
            };

            await productRepository.CreateAsync(product);
            return product.Id;
        }

    }
}
