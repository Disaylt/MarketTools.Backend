using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.MarketplaceConnections;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.MarketplaceConnections
{
    internal class WbServiceConnectionFactory(IQueryable<MarketplaceConnectionEntity> _query, IConnectionTypeFactory _connectionTypeFactory)
    {
        public IQueryable<MarketplaceConnectionEntity> Select(ProjectServices projectService)
        {
            switch(projectService)
            {
                case ProjectServices.StandardAutoresponder:
                    string discriminator = _connectionTypeFactory.Get(MarketplaceConnectionType.OpenApi);
                    return _query.Where(x => x.Discriminator == discriminator);
                default:
                    throw new AppNotFoundException($"Для сервиса {projectService} не реализованно WB подключение.");
            }
        }
    }
}
