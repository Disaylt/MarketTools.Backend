using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Application.Utilities.MarketplaceConnections.Converters;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Http.Connections;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    public class MarketplaceConnectionConverterFactory
    {
        public IConnectionConverter<T> Create<T>(MarketplaceConnectionEntity connection) where T : AbstractConnection
        {
            return Find<T>(connection) as IConnectionConverter<T>
                ?? throw new AppBadRequestException("Такого конвертера подключений не существует.");
        }

        private static object? Find<T>(MarketplaceConnectionEntity connection)
        {
            return typeof(T).Name switch
            {
                nameof(ApiConnectionDto) => new ApiConnectionConverter(connection),
                _ => null
            };
        }
    }
}
