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
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IEnumerable<Order>>
    {
        private readonly IRepository<Order> ordersRepository;

        public GetOrdersQueryHandler(IRepository<Order> ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public async Task<IEnumerable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await ordersRepository.GetAllAsync();
        }
    }
}
