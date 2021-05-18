using Domain.Entities;
using MediatR;
using System.Collections.Generic;

namespace Application.Features.ProductRequestFeatures.Queries
{
    public class GetProductsRequestsQuery : IRequest<IEnumerable<ProductsRequest>>
    {
    }
}
