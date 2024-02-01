using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Database.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Database
{
    internal class AuthUnitOfWork : UnitOfWork, IAuthUnitOfWork
    {
        private readonly IAuthReadHelper _authReadHelper;
        public AuthUnitOfWork(MainAppDbContext dbContext, IAuthReadHelper authReadHelper) : base(dbContext)
        {
            _authReadHelper = authReadHelper;
        }

        public IRepository<StandardAutoresponderColumnEntity> StandardAutoresponderColumns 
            => new AuthRepository<StandardAutoresponderColumnEntity>(
                DbContext.StandardAutoresponderColumns,
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderRecommendationProductEntity> StandardAutoresponderRecommendationProducts
            => new AuthRepository<StandardAutoresponderRecommendationProductEntity>(
                DbContext.StandardAutoresponderRecommendationProducts, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderCell> StandardAutoresponderCells
            => new AuthRepository<StandardAutoresponderCell>(
                DbContext.StandardAutoresponderCells, 
                x => x.Column.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateEntity> StandardAutoresponderTemplates
            => new AuthRepository<StandardAutoresponderTemplateEntity>(
                DbContext.StandardAutoresponderTemplates, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateArticleEntity> StandardAutoresponderTemplateArticles
            => new AuthRepository<StandardAutoresponderTemplateArticleEntity>(
                DbContext.StandardAutoresponderTemplateArticles, 
                x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBindPositionEntity> StandardAutoresponderBindPositions
            => new AuthRepository<StandardAutoresponderBindPositionEntity>(
                DbContext.StandardAutoresponderBindPositions, 
                x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderConnectionEntity> StandardAutoresponderConnections
            => new AuthRepository<StandardAutoresponderConnectionEntity>(
                DbContext.StandardAutoresponderConnections, 
                x => x.SellerConnection.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderConnectionRatingEntity> StandardAutoresponderConnectionRatings
             => new AuthRepository<StandardAutoresponderConnectionRatingEntity>(
                 DbContext.StandardAutoresponderConnectionRatings, 
                 x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateSettingsEntity> StandardAutoresponderTemplateSettings
            => new AuthRepository<StandardAutoresponderTemplateSettingsEntity>(
                DbContext.StandardAutoresponderTemplateSettings, 
                x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<MarketplaceConnectionEntity> SellerConnections
            => new AuthRepository<MarketplaceConnectionEntity>(
                DbContext.MarketplaceConnection, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<MarketplaceConnectionOpenApiEntity> MarketplaceConnectionsOpenAPIs
            => new AuthRepository<MarketplaceConnectionOpenApiEntity>(
                DbContext.WbSellerOpenApiConnections, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBlackListEntity> StandardAutoresponderBlackLists
            => new AuthRepository<StandardAutoresponderBlackListEntity>(
                DbContext.StandardAutoresponderBlackLists, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBanWordEntity> StandardAutoresponderBanWords
            => new AuthRepository<StandardAutoresponderBanWordEntity>(
                DbContext.StandardAutoresponderBanWords, 
                x => x.BlackList.UserId == _authReadHelper.UserId);
    }
}
