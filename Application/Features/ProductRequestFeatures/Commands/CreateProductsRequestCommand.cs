using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;

namespace Application.Features.ProductRequestFeatures.Commands
{
    public class CreateProductsRequestCommand : IRequest<Guid>
    {
        public Guid OperatorId { get; set; }

        public List<ProductRequest> ProductRequest { get; set; }

        public DateTime Timestamp { get; set; }
    }
}
