using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.MarketplaceConnections
{
    public interface IProjectServiceFactory<T> where T : class, IProjectService
    {
        public T Create(EnumProjectServices projectService, MarketplaceName marketplaceName);
        public T? CreateOrDefault(EnumProjectServices projectService, MarketplaceName marketplaceName);
    }
}
