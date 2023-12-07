using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Commands;
using MarketTools.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Cases.Autoresponder.Columns.Commands.Delete
{
    public class CommandHandler
        (IMainDatabaseContext _mainDatabaseContext,
        IAuthReadHelper _authReadHelper)
        : IRequestHandler<DefaultDeleteCommand<AutoresponderColumn>>
    {
        public async Task Handle(DefaultDeleteCommand<AutoresponderColumn> request, CancellationToken cancellationToken)
        {
            AutoresponderColumn entity = await GetEntityAsync(request.Id);
            _mainDatabaseContext.AutoresponderColumns.Remove(entity);
            await _mainDatabaseContext.SaveChangesAsync();
        }

        private async Task<AutoresponderColumn> GetEntityAsync(int id)
        {
            return await _mainDatabaseContext.AutoresponderColumns
                .FirstOrDefaultAsync(x => x.Id == id && x.UserId == _authReadHelper.UserId)
                ?? throw new DefaultNotFoundException();
        }
    }
}
