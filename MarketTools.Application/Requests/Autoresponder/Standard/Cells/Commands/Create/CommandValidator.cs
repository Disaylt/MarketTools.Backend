﻿using FluentValidation;
using MarketTools.Application.Interfaces;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Interfaces.Limits;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Standard.Cells.Commands.Create
{
    public class CommandValidator : AbstractValidator<CellCreateCommand>
    {
        public CommandValidator(IAuthUnitOfWork authUnitOfWork, ILimitsService<IStandarAutoresponderLimits> limitsService)
        {
            RuleFor(x => x.ColumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    return await authUnitOfWork.GetRepository<StandardAutoresponderCellEntity>()
                        .AnyAsync(x => x.Id == columnId);
                })
                .WithErrorCode("404")
                .WithMessage("Колонка не найдена.");

            RuleFor(x => x.ColumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    IStandarAutoresponderLimits limits = await limitsService.GetAsync();
                    int totalCells = await authUnitOfWork.StandardAutoresponderCells.CountAsync(x=> x.ColumnId == columnId);

                    return totalCells < limits.MaxCells;
                })
                .WithErrorCode("400")
                .WithMessage("Превышен лимит ячеек.");
        }
    }
}
