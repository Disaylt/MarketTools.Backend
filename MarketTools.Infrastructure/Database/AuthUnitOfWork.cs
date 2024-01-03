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
            => new AuthRepository<StandardAutoresponderColumn>(GetDbSet<StandardAutoresponderColumn>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderRecommendationProduct> StandardAutoresponderRecommendationProducts
            => new AuthRepository<StandardAutoresponderRecommendationProduct>(GetDbSet<StandardAutoresponderRecommendationProduct>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderCell> StandardAutoresponderCells
            => new AuthRepository<StandardAutoresponderCell>(GetDbSet<StandardAutoresponderCell>(), x => x.Column.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplate> StandardAutoresponderTemplates
            => new AuthRepository<StandardAutoresponderTemplate>(GetDbSet<StandardAutoresponderTemplate>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateArticle> StandardAutoresponderTemplateArticles
            => new AuthRepository<StandardAutoresponderTemplateArticle>(GetDbSet<StandardAutoresponderTemplateArticle>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderColumnBindPosition> StandardAutoresponderColumnBindPositions
            => new AuthRepository<StandardAutoresponderColumnBindPosition>(GetDbSet<StandardAutoresponderColumnBindPosition>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderConnection> StandardAutoresponderConnections
            => new AuthRepository<StandardAutoresponderConnection>(GetDbSet<StandardAutoresponderConnection>(), x => x.SellerConnection.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderConnectionRating> StandardAutoresponderConnectionRatings
             => new AuthRepository<StandardAutoresponderConnectionRating>(GetDbSet<StandardAutoresponderConnectionRating>(), x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderTemplateSettings> StandardAutoresponderTemplateSettings
            => new AuthRepository<StandardAutoresponderTemplateSettings>(GetDbSet<StandardAutoresponderTemplateSettings>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IRepository<SellerConnection> SellerConnections
            => new AuthRepository<SellerConnection>(GetDbSet<SellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections
            => new AuthRepository<OzonOpenApiSellerConnection>(GetDbSet<OzonOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections
            => new AuthRepository<WbOpenApiSellerConnection>(GetDbSet<WbOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBlackList> StandardAutoresponderBlackLists
            => new AuthRepository<StandardAutoresponderBlackList>(GetDbSet<StandardAutoresponderBlackList>(), x => x.UserId == _authReadHelper.UserId);

        public IRepository<StandardAutoresponderBanWord> StandardAutoresponderBanWords
            => new AuthRepository<StandardAutoresponderBanWord>(GetDbSet<StandardAutoresponderBanWord>(), x => x.BlackList.UserId == _authReadHelper.UserId);
    }
}
