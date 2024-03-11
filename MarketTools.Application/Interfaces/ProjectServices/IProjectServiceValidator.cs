using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.ProjectServices
{
    public interface IProjectServiceValidator : IProjectService
    {
        public Task<bool> TryActivate(MarketplaceConnectionEntity connection);
    }
}
