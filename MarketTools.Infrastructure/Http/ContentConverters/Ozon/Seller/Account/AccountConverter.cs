using MarketTools.Application.Common.Exceptions;
using MarketTools.Application.Models.Http.Ozon.Seller.Account;
using MarketTools.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Http.ContentConverters.Ozon.Seller.Account
{
    public abstract class BaseOzonSellerAccountConverter
    {
        protected virtual string Convert(SortBy sortBy)
        {
            return sortBy switch
            {
                SortBy.PublishedAt => "PUBLISHED_AT",
                _ => throw new AppNotFoundException("Невозможна конвертация типа сортировки.")
            };
        }

        protected virtual string Convert(OzonCompanyType type)
        {
            return type switch
            {
                OzonCompanyType.Seller => "seller",
                _ => throw new AppNotFoundException("Невозможна конвертация типа кабинета.")
            };
        }

        protected virtual string Convert(OrderType orderType)
        {
            return orderType switch
            {
                OrderType.Desc => "DESC",
                OrderType.Asc => "ASC",
                _ => throw new AppNotFoundException("Невозможна конвертация типа сортировки.")
            };
        }
    }
}
