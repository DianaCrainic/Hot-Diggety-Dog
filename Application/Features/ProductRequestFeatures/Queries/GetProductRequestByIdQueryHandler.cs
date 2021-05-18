using Application.Interfaces;
using Domain.Dtos;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.ProductRequestFeatures.Queries
{
    class GetProductRequestByIdQueryHandler : IRequestHandler<GetProductRequestByIdQuery, ProductRequest>
    {
        private readonly IRepository<ProductRequest> productRequestRepository;

        public GetProductRequestByIdQueryHandler(IRepository<ProductRequest> productRequestRepository)
        {
            this.productRequestRepository = productRequestRepository;
        }

        public async Task<ProductRequest> Handle(GetProductRequestByIdQuery request, CancellationToken cancellationToken)
        {
            return await productRequestRepository.GetByIdAsync(request.Id);
        }
    }
}
