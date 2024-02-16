using MarketTools.Application.Interfaces.Autoresponder.Standard;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Models.Autoresponder.Standard;
using MarketTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Autoresponder.Standard.Services
{
    internal class AutoresponderContextLoadService
        (IAuthUnitOfWork _authUnitOfWork)
        : IAutoresponderContextLoadService
    {
        private readonly IRepository<MarketplaceConnectionEntity> _marketplaceConnectionRepository = _authUnitOfWork.GetRepository<MarketplaceConnectionEntity>();
        private readonly IRepository<StandardAutoresponderConnectionEntity> _autoresponderConnectionRepository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionEntity>();
        private readonly IRepository<StandardAutoresponderRecommendationProductEntity> _recommendationProductsRepository = _authUnitOfWork.GetRepository<StandardAutoresponderRecommendationProductEntity>();
        private readonly IRepository<StandardAutoresponderConnectionRatingEntity> _autoresponderConnectionRatingRepository = _authUnitOfWork.GetRepository<StandardAutoresponderConnectionRatingEntity>();
        private readonly IRepository<StandardAutoresponderTemplateEntity> _templateRepository = _authUnitOfWork.GetRepository<StandardAutoresponderTemplateEntity>();
        private readonly IRepository<StandardAutoresponderBlackListEntity> _blackListRepository = _authUnitOfWork.GetRepository<StandardAutoresponderBlackListEntity>();

        public async Task<AutoresponderContext> Create(int connectionId)
        {
            AutoresponderContext context = new AutoresponderContext();

            MarketplaceConnectionEntity connection = await _marketplaceConnectionRepository.FirstAsync(x => x.Id == connectionId);

            context.RecommendationProducts = await _recommendationProductsRepository
                .GetRangeAsync(x => x.MarketplaceName == connection.MarketplaceName);

            context.Connection = await _autoresponderConnectionRepository
                .FirstAsync(x => x.SellerConnectionId == connectionId);

            await _autoresponderConnectionRatingRepository
                .GetAsQueryable()
                .Include(x => x.Templates)
                .Where(x => x.ConnectionId == connectionId)
                .LoadAsync();

            await _templateRepository
                .GetAsQueryable()
                .Include(x => x.Settings)
                .Include(x => x.Articles)
                .Include(x => x.BindPositions)
                .ThenInclude(x => x.Column)
                .ThenInclude(x => x.Cells)
                .AsSplitQuery()
                .LoadAsync();

            await _blackListRepository
                .GetAsQueryable()
                .Include(x => x.BanWords)
                .LoadAsync();

            return context;
        }
    }
}
