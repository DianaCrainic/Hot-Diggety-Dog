using Domain.Dtos;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Application.Features.ProductsRequestFeatures.Commands
{
    public class CreateProductsRequestCommand : IRequest<Guid>
    {
        [Required]
        public Guid OperatorId { get; set; }

        public List<CreateProductRequestDto> ProductsRequest { get; set; } = new List<CreateProductRequestDto>();

        public DateTime Timestamp { get; set; }
    }
}
