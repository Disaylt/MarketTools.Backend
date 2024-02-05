using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Utilities.ProjectServices
{
    internal class WbProjectServiceProvider<T> : ProjectServiceProvider<T>
    {
        public WbProjectServiceProvider(Dictionary<EnumProjectServices, Func<IServiceProvider, T>> projectServices, IServiceProvider serviceProvider) 
            : base(projectServices, serviceProvider)
        {
        }
    }
}
