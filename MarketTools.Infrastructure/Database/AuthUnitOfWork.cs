using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Vml.Office;
using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Interfaces.Common;
using MarketTools.Application.Interfaces.Database;
using MarketTools.Application.Interfaces.Identity;
using MarketTools.Application.Models.Identity;
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
        private IContextService<IdentityContext> _identityContext;
        private static Dictionary<Type, Func<IdentityContext, object>> _conditions = new Dictionary<Type, Func<IdentityContext, object>>
        {
                { typeof(StandardAutoresponderBanWordEntity), (identity) => new AuthCondition<StandardAutoresponderBanWordEntity>(x=> x.BlackList.UserId == identity.UserId)},
                { typeof(StandardAutoresponderBlackListEntity), (identity) => new AuthCondition<StandardAutoresponderBlackListEntity>(x=> x.UserId == identity.UserId)},
                { typeof(MarketplaceConnectionEntity), (identity) => new AuthCondition<MarketplaceConnectionEntity>(x=> x.UserId == identity.UserId)},
                { typeof(StandardAutoresponderTemplateSettingsEntity), (identity) => new AuthCondition<StandardAutoresponderTemplateSettingsEntity>(x=> x.Template.UserId == identity.UserId)},
                { typeof(StandardAutoresponderConnectionRatingEntity), (identity) => new AuthCondition<StandardAutoresponderConnectionRatingEntity>(x=> x.Connection.SellerConnection.UserId == identity.UserId)},
                { typeof(StandardAutoresponderConnectionEntity), (identity) => new AuthCondition<StandardAutoresponderConnectionEntity>(x=> x.SellerConnection.UserId == identity.UserId)},
                { typeof(StandardAutoresponderBindPositionEntity), (identity) => new AuthCondition<StandardAutoresponderBindPositionEntity>(x=> x.Template.UserId == identity.UserId)},
                { typeof(StandardAutoresponderTemplateArticleEntity), (identity) => new AuthCondition<StandardAutoresponderTemplateArticleEntity>(x=> x.Template.UserId == identity.UserId)},
                { typeof(StandardAutoresponderTemplateEntity), (identity) => new AuthCondition<StandardAutoresponderTemplateEntity>(x=> x.UserId == identity.UserId)},
                { typeof(StandardAutoresponderCellEntity), (identity) => new AuthCondition<StandardAutoresponderCellEntity>(x=> x.Column.UserId == identity.UserId)},
                { typeof(StandardAutoresponderRecommendationProductEntity), (identity) => new AuthCondition<StandardAutoresponderRecommendationProductEntity>(x=> x.UserId == identity.UserId)},
                { typeof(StandardAutoresponderColumnEntity), (identity) => new AuthCondition<StandardAutoresponderColumnEntity>(x=> x.UserId == identity.UserId)},
                { typeof(UserNotificationEntity), (identity) => new AuthCondition<UserNotificationEntity>(x=> x.UserId == identity.UserId)},
                { typeof(AppIdentityUser), (identity) => new AuthCondition<AppIdentityUser>(x=> x.Id == identity.UserId)},
                { typeof(StandardAutoresponderNotificationEntity), (identity) => new AuthCondition<StandardAutoresponderNotificationEntity>(x=> x.StandardAutoresponderConnection.SellerConnection.UserId == identity.UserId)}
            };

        public AuthUnitOfWork(MainAppDbContext dbContext, IContextService<IdentityContext> identityContext) : base(dbContext)
        {
            _identityContext = identityContext;
        }

        public override IRepository<T> GetRepository<T>()
        {
            AuthCondition<T> authCondition = _conditions.GetValueOrDefault(typeof(T))?
                .Invoke(_identityContext.Context)
                as AuthCondition<T>
                ?? throw new Exception($"Не найдено условие авторизации для таблицы {typeof(T).Name}");

            return CreateAuthRepository(authCondition.Condition);
        }

        private IRepository<T> CreateAuthRepository<T>(Expression<Func<T, bool>> userCondition) where T : class
        {
            return new AuthRepository<T>(DbContext.Set<T>(), userCondition);
        }
    }
}
