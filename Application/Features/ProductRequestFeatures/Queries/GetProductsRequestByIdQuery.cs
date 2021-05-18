using Domain.Entities;
using MediatR;
using System;

namespace Application.Features.ProductRequestFeatures.Queries
{
    public class GetProductsRequestByIdQuery : IRequest<ProductsRequest>
    {
        public Guid Id { get; set; }
    }
}
