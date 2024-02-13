using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Queries.GetRange
{
    public class QueryValidator : AbstractValidator<CellGetRangeQuery>
    {
        public QueryValidator(IAuthUnitOfWork authUnitOfWork)
        {
            RuleFor(x => x.CollumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    return await authUnitOfWork.GetRepository<StandardAutoresponderColumnEntity>()
                        .AnyAsync(column => column.Id == columnId, ct);
                })
                .WithErrorCode("404")
                .WithMessage("Колонка не найдена.");
        }
    }
}
