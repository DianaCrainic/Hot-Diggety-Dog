using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Qureries
{
    public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdQuery, IQueryable<Order>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetOrdersByUserIdHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }
        public async Task<IQueryable<Order>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            return _ordersRepository.GetAllAsQueryable().Where(order => order.UserId == request.Id);
        }
    }
}
