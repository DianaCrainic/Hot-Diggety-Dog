using MediatR;
using System;

namespace Application.Features.StandProductsFeatures.Commands
{
    public class DeleteStandProductCommand : IRequest<Guid>
    {
        public Guid StandId { get; set; }
        public Guid ProductId { get; set; }
    }
}
