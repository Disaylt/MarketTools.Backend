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

        public IAuthRepository<AutoresponderStandardColumn> AutoresponderColumns 
            => new GenericAuthRepository<AutoresponderStandardColumn>(GetDbSet<AutoresponderStandardColumn>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardRecommendationProduct> AutoresponderRecommendationProducts
            => new GenericAuthRepository<AutoresponderStandardRecommendationProduct>(GetDbSet<AutoresponderStandardRecommendationProduct>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardCell> AutoresponderCells
            => new GenericAuthRepository<AutoresponderStandardCell>(GetDbSet<AutoresponderStandardCell>(), x => x.Column.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardTemplate> AutoresponderTemplates
            => new GenericAuthRepository<AutoresponderStandardTemplate>(GetDbSet<AutoresponderStandardTemplate>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardTemplateArticle> AutoresponderTemplateArticles
            => new GenericAuthRepository<AutoresponderStandardTemplateArticle>(GetDbSet<AutoresponderStandardTemplateArticle>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardColumnBindPosition> AutoresponderColumnBindPositions
            => new GenericAuthRepository<AutoresponderStandardColumnBindPosition>(GetDbSet<AutoresponderStandardColumnBindPosition>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardConnection> AutoresponderConnections
            => new GenericAuthRepository<AutoresponderStandardConnection>(GetDbSet<AutoresponderStandardConnection>(), x => x.SellerConnection.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardConnectionRating> AutoresponderConnectionRatings
             => new GenericAuthRepository<AutoresponderStandardConnectionRating>(GetDbSet<AutoresponderStandardConnectionRating>(), x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardTemplateSettings> AutoresponderTemplateSettings
            => new GenericAuthRepository<AutoresponderStandardTemplateSettings>(GetDbSet<AutoresponderStandardTemplateSettings>(), x => x.Template.UserId == _authReadHelper.UserId);

        public IAuthRepository<SellerConnection> SellerConnections
            => new GenericAuthRepository<SellerConnection>(GetDbSet<SellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections
            => new GenericAuthRepository<OzonOpenApiSellerConnection>(GetDbSet<OzonOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections
            => new GenericAuthRepository<WbOpenApiSellerConnection>(GetDbSet<WbOpenApiSellerConnection>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardBlackList> AutoresponderBlackLists
            => new GenericAuthRepository<AutoresponderStandardBlackList>(GetDbSet<AutoresponderStandardBlackList>(), x => x.UserId == _authReadHelper.UserId);

        public IAuthRepository<AutoresponderStandardBanWord> AutoresponderBanWords
            => new GenericAuthRepository<AutoresponderStandardBanWord>(GetDbSet<AutoresponderStandardBanWord>(), x => x.BlackList.UserId == _authReadHelper.UserId);
    }
}
