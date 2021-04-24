using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Qureries
{
    public class GetOrdersByUserIdHandler : IRequestHandler<GetOrdersByUserIdQuery, IEnumerable<Order>>
    {
        private readonly IOrdersRepository _ordersRepository;

        public GetOrdersByUserIdHandler(IOrdersRepository ordersRepository)
        {
            _ordersRepository = ordersRepository;
        }

        public async Task<IEnumerable<Order>> Handle(GetOrdersByUserIdQuery request, CancellationToken cancellationToken)
        {
            return await _ordersRepository.GetByUserId(request.Id);
        }
    }
}
