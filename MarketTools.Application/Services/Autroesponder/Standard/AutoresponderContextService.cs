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
        : IAutoresponderContextService
    {
        private readonly AutoresponderContext _context = new AutoresponderContext();

        public async Task<AutoresponderContext> CreateContextAsync(int connectionId, MarketplaceName marketplaceName)
        {
            _context.RecommendationProducts = await _authUnitOfWork.StandardAutoresponderRecommendationProducts
                .GetRangeAsync(x => x.MarketplaceName == marketplaceName);

            _context.Connection = await _authUnitOfWork.StandardAutoresponderConnections
                .FirstAsync(x=> x.SellerConnectionId == connectionId);

            await _authUnitOfWork.StandardAutoresponderConnectionRatings
                .GetAsQueryable()
                .Where(x=> x.ConnectionId == connectionId)
                .LoadAsync();

            await _authUnitOfWork.StandardAutoresponderTemplates
                .GetAsQueryable()
                .Include(x => x.Settings)
                .Include(x => x.Articles)
                .Include(x => x.BindPositions)
                .ThenInclude(x=> x.Column)
                .ThenInclude(x=> x.Cells)
                .LoadAsync();

            await _authUnitOfWork.StandardAutoresponderBlackLists
                .GetAsQueryable()
                .Include(x => x.BanWords)
                .LoadAsync();

            return _context;
        }


    }
}
