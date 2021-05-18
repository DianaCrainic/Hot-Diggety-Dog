using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductRequestCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
