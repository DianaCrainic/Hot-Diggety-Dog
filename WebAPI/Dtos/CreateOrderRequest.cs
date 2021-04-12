﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Dtos
{
    public class CreateOrderRequest
    {
        [Required]
        public Guid OperatorId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        [Required]
        public List<AddProductToOrderRequest> Products { get; set; }

    }
}
