using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.ProjectServices
{
    public interface IProjectServiceFactory<T> where T : IProjectService
    {
        public T Create(EnumProjectServices service);
    }
}
