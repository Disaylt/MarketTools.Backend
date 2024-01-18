using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.RefreshToken
{
    public class OpenApiRefreshTokenCommand : IRequest
    {
        public int Id { get; set; }
        public required string Token { get; set; }
    }
}
