﻿using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Add
{
    public class CommandHandler
        : IRequestHandler<SellerOpenApiAddCommand, MarketplaceConnectionEntity>
    {
        public Task<MarketplaceConnectionEntity> Handle(SellerOpenApiAddCommand request, CancellationToken cancellationToken)
        {
            
            throw new NotImplementedException();
        }
    }
}
