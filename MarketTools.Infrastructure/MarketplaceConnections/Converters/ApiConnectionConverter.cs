using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.MarketplaceConnections.Converters
{
    internal class ApiConnectionConverter : IConnectionConverter<ApiConnectionDto>
    {

        public ApiConnectionDto Convert(MarketplaceConnectionEntity connection)
        {
            return new ApiConnectionDto
            {
                Token = GetTokenHeader(connection.Headers).Value
            };
        }

        public void UpdateDetails(MarketplaceConnectionEntity connection, ApiConnectionDto apiConnection)
        {
            MarketplaceConnectionHeaderEntity? tokenHeader = connection
                .Headers
                .FirstOrDefault(x => x.Name == nameof(ApiConnectionDto.Token));

            if (tokenHeader == null)
            {
                MarketplaceConnectionHeaderEntity newTokenHeader = new MarketplaceConnectionHeaderEntity
                {
                    Name = nameof(ApiConnectionDto.Token),
                    Value = apiConnection.Token
                };
                connection.Headers.Add(newTokenHeader);
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
