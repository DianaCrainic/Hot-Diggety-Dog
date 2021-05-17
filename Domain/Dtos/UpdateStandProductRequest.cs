using Domain.Entities;
using System;
using System.Collections.Generic;

namespace Domain.Dtos
{
    public class UpdateStandProductsRequest
    {
        public Guid StandId { set; get; }
        public List<HotDogStandProduct> Products { set; get; }
    }
}
