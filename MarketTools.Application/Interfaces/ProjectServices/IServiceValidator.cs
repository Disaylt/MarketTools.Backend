using MarketTools.Application.Interfaces.Services;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.ProjectServices
{
    public interface IServiceValidator : IProjectService
    {
        public Task TryActivete();
    }
}
