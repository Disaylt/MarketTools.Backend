﻿using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Cells.Queries.GetList
{
    public class QueryValidator : AbstractValidator<GetRangeQuery>
    {
        public QueryValidator(IAuthUnitOfWork authUnitOfWork) 
        {
            RuleFor(x => x.CollumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    return await authUnitOfWork.StandardAutoresponderColumns
                        .AnyAsync(column => column.Id == columnId, ct);
                })
                .WithErrorCode("404")
                .WithMessage("Колонка не найдена.");
        }
    }
}
