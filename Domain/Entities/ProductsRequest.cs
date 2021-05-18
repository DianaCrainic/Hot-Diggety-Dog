using Domain.Common;
using Domain.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.Entities
{
    public class ProductsRequest : BaseEntity
    {
        [Required]
        public Guid OperatorId { set; get; }
        
        [Required]
        public virtual User Operator { get; set; }

        [Required]
        public List<ProductRequest> ProductRequest { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
