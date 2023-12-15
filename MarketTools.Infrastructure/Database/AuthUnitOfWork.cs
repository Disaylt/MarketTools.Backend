using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Domain.Entities;
using MarketTools.Domain.Enums;
using MarketTools.Infrastructure.Database.AuthRepositories;
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

        public IAuthRepository<AutoresponderColumn> AutoresponderColumns 
            => new GenericAuthRepository<AutoresponderColumn>(GetDbSet<AutoresponderColumn>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderRecommendationProduct> AutoresponderRecommendationProducts
            => new GenericAuthRepository<AutoresponderRecommendationProduct>(GetDbSet<AutoresponderRecommendationProduct>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderCell> AutoresponderCells
            => new GenericAuthRepository<AutoresponderCell>(GetDbSet<AutoresponderCell>(), x => x.Column.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderTemplate> AutoresponderTemplates
            => new GenericAuthRepository<AutoresponderTemplate>(GetDbSet<AutoresponderTemplate>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderTemplateArticle> AutoresponderTemplateArticles
            => new GenericAuthRepository<AutoresponderTemplateArticle>(GetDbSet<AutoresponderTemplateArticle>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderColumnBindPosition> AutoresponderColumnBindPositions
            => new GenericAuthRepository<AutoresponderColumnBindPosition>(GetDbSet<AutoresponderColumnBindPosition>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderConnection> AutoresponderConnections
            => new GenericAuthRepository<AutoresponderConnection>(GetDbSet<AutoresponderConnection>(), x => x.SellerConnection.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderConnectionRating> AutoresponderConnectionRatings
             => new GenericAuthRepository<AutoresponderConnectionRating>(GetDbSet<AutoresponderConnectionRating>(), x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderTemplateSettings> AutoresponderTemplateSettings
            => new GenericAuthRepository<AutoresponderTemplateSettings>(GetDbSet<AutoresponderTemplateSettings>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<SellerConnection> SellerConnections
            => new GenericAuthRepository<SellerConnection>(GetDbSet<SellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections
            => new GenericAuthRepository<OzonOpenApiSellerConnection>(GetDbSet<OzonOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections
            => new GenericAuthRepository<WbOpenApiSellerConnection>(GetDbSet<WbOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderBlackList> AutoresponderBlackLists
            => new GenericAuthRepository<AutoresponderBlackList>(GetDbSet<AutoresponderBlackList>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderBanWord> AutoresponderBanWords
            => new GenericAuthRepository<AutoresponderBanWord>(GetDbSet<AutoresponderBanWord>(), x => x.BlackList.UserId == _authReadHelper.UserId);
    }
}
