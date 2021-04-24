using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;


namespace Application.Features.OrderFeatures.Commands
{
    public class CreateOrderCommand : IRequest<Guid>
    {
        public DateTime Timestamp { get; set; }

        public double Total { get; set; }

        public Guid OperatorId { set; get; }

        public Guid UserId { set; get; }

        public User User { get; set; }

        public User Operator { get; set; }

        public ICollection<OrderProduct> OrderProducts { get; set; }
    }
}
