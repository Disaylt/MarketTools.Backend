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

        public override IRepository<T> GetRepository<T>()
        {
            IRepository<T>? result = null;

            if (typeof(T) == typeof(StandardAutoresponderColumnEntity))
            {
                result = new AuthRepository<StandardAutoresponderColumnEntity>(
                    DbContext.StandardAutoresponderColumns,
                    x => x.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderColumnEntity))
            {
                result = new AuthRepository<StandardAutoresponderRecommendationProductEntity>(
                    DbContext.StandardAutoresponderRecommendationProducts,
                    x => x.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderColumnEntity))
            {
                result = new AuthRepository<StandardAutoresponderCellEntity>(
                    DbContext.StandardAutoresponderCells,
                    x => x.Column.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderTemplateEntity))
            {
                result = new AuthRepository<StandardAutoresponderTemplateEntity>(
                    DbContext.StandardAutoresponderTemplates,
                    x => x.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderTemplateArticleEntity))
            {
                result = new AuthRepository<StandardAutoresponderTemplateArticleEntity>(
                    DbContext.StandardAutoresponderTemplateArticles,
                    x => x.Template.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderBindPositionEntity))
            {
                result = new AuthRepository<StandardAutoresponderBindPositionEntity>(
                    DbContext.StandardAutoresponderBindPositions,
                    x => x.Template.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderConnectionEntity))
            {
                result = new AuthRepository<StandardAutoresponderConnectionEntity>(
                    DbContext.StandardAutoresponderConnections,
                    x => x.SellerConnection.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderConnectionRatingEntity))
            {
                result = new AuthRepository<StandardAutoresponderConnectionRatingEntity>(
                    DbContext.StandardAutoresponderConnectionRatings,
                    x => x.Connection.SellerConnection.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderTemplateSettingsEntity))
            {
                result = new AuthRepository<StandardAutoresponderTemplateSettingsEntity>(
                    DbContext.StandardAutoresponderTemplateSettings,
                    x => x.Template.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(MarketplaceConnectionEntity))
            {
                result = new AuthRepository<MarketplaceConnectionEntity>(
                    DbContext.MarketplaceConnection,
                    x => x.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(MarketplaceConnectionOpenApiEntity))
            {
                result = new AuthRepository<MarketplaceConnectionOpenApiEntity>(
                    DbContext.MarketplaceConnectionOpenAPIs,
                    x => x.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderBlackListEntity))
            {
                result = new AuthRepository<StandardAutoresponderBlackListEntity>(
                    DbContext.StandardAutoresponderBlackLists,
                    x => x.UserId == _authReadHelper.UserId) as IRepository<T>;
            }
            else if (typeof(T) == typeof(StandardAutoresponderBanWordEntity))
            {
                result = new AuthRepository<StandardAutoresponderBanWordEntity>(
                    DbContext.StandardAutoresponderBanWords,
                    x => x.BlackList.UserId == _authReadHelper.UserId) as IRepository<T>;
            }

            return result ?? throw new AppNotFoundException("Невозможно получить контекст данных.");
        }
    }
}
