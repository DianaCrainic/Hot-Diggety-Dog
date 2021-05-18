using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace Domain.Entities
{
    public class ProductsRequest : BaseEntity
    {
        [ForeignKey("Operator")]
        public Guid OperatorId { set; get; }

        [JsonIgnore]
        public virtual User Operator { get; set; }

        public List<ProductRequest> ProductRequest { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }
    }
}
