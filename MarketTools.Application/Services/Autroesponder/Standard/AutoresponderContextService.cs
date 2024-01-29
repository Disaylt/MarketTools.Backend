using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Services.Autroesponder.Standard
{
    internal class AutoresponderContextService
        (IAuthUnitOfWork _authUnitOfWork)
        : IAutoresponderContextWriter, IAutoresponderContextReader, IAutoresponderContextService
    {
        private AutoresponderContext? _context;

        public AutoresponderContext Context
        {
            get
            {
                if( _context == null)
                {
                    throw new AppNotFoundException("Контекст с данными автоответчика не найден.");
                }

                return _context;
            }
        }

        public async Task<AutoresponderContext> Create(int connectionId)
        {
            AutoresponderContext context = new AutoresponderContext();

            MarketplaceConnectionEntity connection = await _authUnitOfWork.SellerConnections.FirstAsync(x => x.Id == connectionId);

            context.RecommendationProducts = await _authUnitOfWork.StandardAutoresponderRecommendationProducts
                .GetRangeAsync(x => x.MarketplaceName == connection.MarketplaceName);

            context.Connection = await _authUnitOfWork.StandardAutoresponderConnections
                .FirstAsync(x => x.SellerConnectionId == connectionId);

            await _authUnitOfWork.StandardAutoresponderConnectionRatings
                .GetAsQueryable()
                .Include(x => x.Templates)
                .Where(x => x.ConnectionId == connectionId)
                .LoadAsync();

            await _authUnitOfWork.StandardAutoresponderTemplates
                .GetAsQueryable()
                .Include(x => x.Settings)
                .Include(x => x.Articles)
                .Include(x => x.BindPositions)
                .ThenInclude(x => x.Column)
                .ThenInclude(x => x.Cells)
                .AsSplitQuery()
                .LoadAsync();

            await _authUnitOfWork.StandardAutoresponderBlackLists
                .GetAsQueryable()
                .Include(x => x.BanWords)
                .LoadAsync();

            return context;
        }

        public void Write(AutoresponderContext context)
        {
            if(_context != null)
            {
                throw new AppBadRequestException("Контекст для автоответчика уже записан.");
            }

            _context = context;
        }
    }
}
