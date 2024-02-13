using MarketTools.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.MarketplaceConnections.OpenApi.Command.RefreshToken
{
    public class OpenApiRefreshTokenCommand : IRequest<MarketplaceConnectionEntity>
    {
        public int Id { get; set; }
        public required string Token { get; set; }
    }
}
