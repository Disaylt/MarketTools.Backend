using FluentValidation;
using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Interfaces.Limits;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Requests.Wb.Connections.Seller.OpenApi.Commands.Add
{
    public class CommandValidator : AbstractValidator<SellerOpenApiAddCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IMarketplaceConnectionLimits> limitsService) 
        {
            RuleFor(x => x)
                .MustAsync(async (x, ct) =>
                {
                    int numConnections = await authUnitOfWork.SellerConnections.CountAsync();
                    IMarketplaceConnectionLimits limits = await limitsService.GetAsync();

                    return numConnections < limits.MaxConnections;
                });
        }
    }
}
