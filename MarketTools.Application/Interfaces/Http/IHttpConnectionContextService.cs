using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Http
{
    public interface IHttpConnectionContextService
    {
        void Write<T>(T entity) where T : MarketplaceConnectionEntity;
        public T Read<T>() where T : MarketplaceConnectionEntity;
    }
}
