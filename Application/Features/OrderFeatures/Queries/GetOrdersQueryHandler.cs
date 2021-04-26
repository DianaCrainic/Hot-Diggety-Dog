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
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, IQueryable<Order>>
    {
        private readonly IOrdersRepository ordersRepository;

        public GetOrdersQueryHandler(IOrdersRepository ordersRepository)
        {
            this.ordersRepository = ordersRepository;
        }
        public async Task<IQueryable<Order>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return ordersRepository.GetAllAsQueryable();
        }
    }
}
