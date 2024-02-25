using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections.Converters
{
    internal class ApiConnectionConverter(MarketplaceConnectionEntity _connection)
        : IConnectionConverter<ApiConnectionDto>
    {

        public ApiConnectionDto Convert()
        {
            return new ApiConnectionDto
            {
                Token = GetTokenHeader(_connection.Headers).Value
            };
        }

        public void SetDetails(ApiConnectionDto apiConnection)
        {
            MarketplaceConnectionHeaderEntity? tokenHeader = _connection
                .Headers
                .FirstOrDefault(x => x.Name == nameof(ApiConnectionDto.Token));

            if (tokenHeader == null)
            {
                MarketplaceConnectionHeaderEntity newTokenHeader = new MarketplaceConnectionHeaderEntity
                {
                    Name = nameof(ApiConnectionDto.Token),
                    Value = apiConnection.Token
                };
                _connection.Headers.Add(newTokenHeader);
            }
            else
            {
                tokenHeader.Value = apiConnection.Token;
            }
        }

        private MarketplaceConnectionHeaderEntity GetTokenHeader(IEnumerable<MarketplaceConnectionHeaderEntity> headers)
        {
            return headers.FirstOrDefault(x => x.Name == nameof(ApiConnectionDto.Token))
                ?? throw new AppNotFoundException("У подключения не установлен токен.");
        }
    }
}
