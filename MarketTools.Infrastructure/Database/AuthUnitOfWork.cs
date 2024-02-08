using DocumentFormat.OpenXml.Vml.Office;
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
        private readonly Dictionary<Type, Func<object>> _conditions;

        public AuthUnitOfWork(MainAppDbContext dbContext, IAuthReadHelper authReadHelper) : base(dbContext)
        {
            _conditions = UserConditionsList(authReadHelper.UserId);
        }

        public override IRepository<T> GetRepository<T>()
        {
            AuthCondition<T> authCondition = _conditions.GetValueOrDefault(typeof(T))?
                .Invoke()
                as AuthCondition<T>
                ?? throw new Exception($"Не найдено условие авторизации для таблицы {typeof(T).Name}");

            return CreateAuthRepository(authCondition.Condition);
        }

        private static Dictionary<Type, Func<object>> UserConditionsList(string userId)
        {
            return new Dictionary<Type, Func<object>>
            {
                { typeof(StandardAutoresponderBanWordEntity), () => new AuthCondition<StandardAutoresponderBanWordEntity>(x=> x.BlackList.UserId == userId)},
                { typeof(StandardAutoresponderBlackListEntity), () => new AuthCondition<StandardAutoresponderBlackListEntity>(x=> x.UserId == userId)},
                { typeof(MarketplaceConnectionOpenApiEntity), () => new AuthCondition<MarketplaceConnectionOpenApiEntity>(x=> x.UserId == userId)},
                { typeof(MarketplaceConnectionEntity), () => new AuthCondition<MarketplaceConnectionEntity>(x=> x.UserId == userId)},
                { typeof(StandardAutoresponderTemplateSettingsEntity), () => new AuthCondition<StandardAutoresponderTemplateSettingsEntity>(x=> x.Template.UserId == userId)},
                { typeof(StandardAutoresponderConnectionRatingEntity), () => new AuthCondition<StandardAutoresponderConnectionRatingEntity>(x=> x.Connection.SellerConnection.UserId == userId)},
                { typeof(StandardAutoresponderConnectionEntity), () => new AuthCondition<StandardAutoresponderConnectionEntity>(x=> x.SellerConnection.UserId == userId)},
                { typeof(StandardAutoresponderBindPositionEntity), () => new AuthCondition<StandardAutoresponderBindPositionEntity>(x=> x.Template.UserId == userId)},
                { typeof(StandardAutoresponderTemplateArticleEntity), () => new AuthCondition<StandardAutoresponderTemplateArticleEntity>(x=> x.Template.UserId == userId)},
                { typeof(StandardAutoresponderTemplateEntity), () => new AuthCondition<StandardAutoresponderTemplateEntity>(x=> x.UserId == userId)},
                { typeof(StandardAutoresponderCellEntity), () => new AuthCondition<StandardAutoresponderCellEntity>(x=> x.Column.UserId == userId)},
                { typeof(StandardAutoresponderRecommendationProductEntity), () => new AuthCondition<StandardAutoresponderRecommendationProductEntity>(x=> x.UserId == userId)},
                { typeof(StandardAutoresponderColumnEntity), () => new AuthCondition<StandardAutoresponderColumnEntity>(x=> x.UserId == userId)},
                { typeof(UserNotificationEntity), () => new AuthCondition<UserNotificationEntity>(x=> x.UserId == userId)}
            };
        }

        private IRepository<T> CreateAuthRepository<T>(Expression<Func<T, bool>> userCondition) where T : class
        {
            return new AuthRepository<T>(DbContext.Set<T>(), userCondition);
        }
    }
}
