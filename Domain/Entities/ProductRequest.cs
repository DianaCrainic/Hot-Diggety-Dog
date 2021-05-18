using Domain.Common;
using Domain.Entities;
using System;

namespace Domain.Dtos
{
    public class ProductRequest : BaseEntity
    {
        public Guid ProductId { get; set; }

        public virtual Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
