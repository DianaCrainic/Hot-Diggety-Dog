﻿using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderFeatures.Qureries
{
    public class GetOrdersByUserIdQuery : IRequest<IQueryable<Order>>
    {
        public Guid Id { get; set; }
    }
}
