using FluentValidation;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Cells.Commands.Create
{
    public class CommandValidator : AbstractValidator<CreateCellCommand>
    {
        public CommandValidator(IMainDatabaseContext _context, IAuthReadHelper _authReadHelper) 
        {
            RuleFor(x => x.ColumnId)
                .MustAsync(async (columnId, ct) =>
                {
                    return await _context.AutoresponderColumns
                        .AnyAsync(x=> x.Id == columnId && x.UserId == _authReadHelper.UserId);
                })
                .WithMessage("Колонка не найдена.");
        }
    }
}
