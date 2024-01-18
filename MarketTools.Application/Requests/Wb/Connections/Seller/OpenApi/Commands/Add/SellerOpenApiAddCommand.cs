using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Add
{
    public class SellerOpenApiAddCommand : IRequest<SellerConnectionEntity>
    {
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required string Token { get; set; }
    }
}
