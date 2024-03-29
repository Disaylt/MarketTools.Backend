﻿using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.OpenApi.Command.Add
{
    public class SellerOpenApiAddCommand : IRequest<MarketplaceConnectionEntity>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Token { get; set; }
        public MarketplaceName MarketplaceName { get; set; }
    }
}
