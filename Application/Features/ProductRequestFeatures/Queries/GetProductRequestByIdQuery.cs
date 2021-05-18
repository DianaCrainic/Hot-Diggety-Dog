using Domain.Dtos;
using MediatR;
using System;

namespace Application.Features.ProductRequestFeatures.Queries
{
    public class GetProductRequestByIdQuery : IRequest<ProductRequest>
    {
        public Guid Id { get; set; }
    }
}
