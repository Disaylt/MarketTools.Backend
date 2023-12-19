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

        public IAuthRepository<StandardAutoresponderColumn> AutoresponderColumns 
            => new GenericAuthRepository<StandardAutoresponderColumn>(GetDbSet<StandardAutoresponderColumn>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderRecommendationProduct> AutoresponderRecommendationProducts
            => new GenericAuthRepository<StandardAutoresponderRecommendationProduct>(GetDbSet<StandardAutoresponderRecommendationProduct>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderCell> AutoresponderCells
            => new GenericAuthRepository<StandardAutoresponderCell>(GetDbSet<StandardAutoresponderCell>(), x => x.Column.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderTemplate> AutoresponderTemplates
            => new GenericAuthRepository<StandardAutoresponderTemplate>(GetDbSet<StandardAutoresponderTemplate>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderTemplateArticle> AutoresponderTemplateArticles
            => new GenericAuthRepository<StandardAutoresponderTemplateArticle>(GetDbSet<StandardAutoresponderTemplateArticle>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderColumnBindPosition> AutoresponderColumnBindPositions
            => new GenericAuthRepository<StandardAutoresponderColumnBindPosition>(GetDbSet<StandardAutoresponderColumnBindPosition>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderConnection> AutoresponderConnections
            => new GenericAuthRepository<StandardAutoresponderConnection>(GetDbSet<StandardAutoresponderConnection>(), x => x.SellerConnection.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderConnectionRating> AutoresponderConnectionRatings
             => new GenericAuthRepository<StandardAutoresponderConnectionRating>(GetDbSet<StandardAutoresponderConnectionRating>(), x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderTemplateSettings> AutoresponderTemplateSettings
            => new GenericAuthRepository<StandardAutoresponderTemplateSettings>(GetDbSet<StandardAutoresponderTemplateSettings>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<SellerConnection> SellerConnections
            => new GenericAuthRepository<SellerConnection>(GetDbSet<SellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections
            => new GenericAuthRepository<OzonOpenApiSellerConnection>(GetDbSet<OzonOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections
            => new GenericAuthRepository<WbOpenApiSellerConnection>(GetDbSet<WbOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderBlackList> AutoresponderBlackLists
            => new GenericAuthRepository<StandardAutoresponderBlackList>(GetDbSet<StandardAutoresponderBlackList>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<StandardAutoresponderBanWord> AutoresponderBanWords
            => new GenericAuthRepository<StandardAutoresponderBanWord>(GetDbSet<StandardAutoresponderBanWord>(), x => x.BlackList.UserId == _authReadHelper.UserId);
    }
}
