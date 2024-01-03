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

        public IRepository<StandardAutoresponderColumn> StandardAutoresponderColumns 
            => new AuthRepository<StandardAutoresponderColumn>(
                DbContext.StandardAutoresponderColumns,
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderRecommendationProduct> StandardAutoresponderRecommendationProducts
            => new AuthRepository<StandardAutoresponderRecommendationProduct>(
                DbContext.StandardAutoresponderRecommendationProducts, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderCell> StandardAutoresponderCells
            => new AuthRepository<StandardAutoresponderCell>(
                DbContext.StandardAutoresponderCells, 
                x => x.Column.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplate> StandardAutoresponderTemplates
            => new AuthRepository<StandardAutoresponderTemplate>(
                DbContext.StandardAutoresponderTemplates, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateArticle> StandardAutoresponderTemplateArticles
            => new AuthRepository<StandardAutoresponderTemplateArticle>(
                DbContext.StandardAutoresponderTemplateArticles, 
                x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderColumnBindPosition> StandardAutoresponderColumnBindPositions
            => new AuthRepository<StandardAutoresponderColumnBindPosition>(
                DbContext.StandardAutoresponderColumnBindPositions, 
                x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderConnection> StandardAutoresponderConnections
            => new AuthRepository<StandardAutoresponderConnection>(
                DbContext.StandardAutoresponderConnections, 
                x => x.SellerConnection.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderConnectionRating> StandardAutoresponderConnectionRatings
             => new AuthRepository<StandardAutoresponderConnectionRating>(
                 DbContext.StandardAutoresponderConnectionRatings, 
                 x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateSettings> StandardAutoresponderTemplateSettings
            => new AuthRepository<StandardAutoresponderTemplateSettings>(
                DbContext.StandardAutoresponderTemplateSettings, 
                x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<SellerConnection> SellerConnections
            => new AuthRepository<SellerConnection>(
                DbContext.SellerConnections, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections
            => new AuthRepository<OzonOpenApiSellerConnection>(
                DbContext.OzonOpenApiSellerConnections, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections
            => new AuthRepository<WbOpenApiSellerConnection>(
                DbContext.WbOpenApiSellerConnections, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBlackList> StandardAutoresponderBlackLists
            => new AuthRepository<StandardAutoresponderBlackList>(
                DbContext.StandardAutoresponderBlackLists, 
                x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBanWord> StandardAutoresponderBanWords
            => new AuthRepository<StandardAutoresponderBanWord>(
                DbContext.StandardAutoresponderBanWords, 
                x => x.BlackList.UserId == _authReadHelper.UserId);
    }
}
