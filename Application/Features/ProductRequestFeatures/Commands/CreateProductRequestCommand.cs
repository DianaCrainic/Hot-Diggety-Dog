using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.ProductFeatures.Commands
{
    public class CreateProductRequestCommand : IRequest<Guid>
    {
        public ProductsRequest ProductsRequest { get; set; }

        public Guid RequestId { get; set; }

        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
