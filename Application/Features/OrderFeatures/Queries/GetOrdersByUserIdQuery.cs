using Domain.Entities;
using MediatR;
using System;
using System.Linq;

namespace Application.Features.OrderFeatures.Qureries
{
    public class GetOrdersByUserIdQuery : IRequest<IQueryable<Order>>
    {
        public Guid Id { get; set; }
    }
}
