using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
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
    public class WbServiceConnectionFactory() : IServiceConnectionFactory
    {
        public IConnectionSerivceDeterminant Select(ProjectServices projectService)
        {
            switch (projectService)
            {
                case ProjectServices.StandardAutoresponder:
                    return new ConnectionSerivceDeterminant<MarketplaceConnectionOpenApiEntity>();
            }

            throw new AppNotFoundException($"Для сервиса {projectService} не реализованно WB подключение.");
        }
    }
}
