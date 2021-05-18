using Application.Interfaces;
using Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductsRequestFeatures.Queries
{
    public class GetProductsRequestByIdQueryHandler : IRequestHandler<GetProductsRequestByIdQuery, ProductsRequest>
    {
        private readonly IRepository<ProductsRequest> productsRequestRepository;

        public GetProductsRequestByIdQueryHandler(IRepository<ProductsRequest> productsRequestRepository)
        {
            this.productsRequestRepository = productsRequestRepository;
        }

        public async Task<ProductsRequest> Handle(GetProductsRequestByIdQuery request, CancellationToken cancellationToken)
        {
            return await productsRequestRepository.GetByIdAsync(request.Id);
        }
    }
}
