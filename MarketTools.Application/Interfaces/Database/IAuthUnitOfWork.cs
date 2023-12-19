using MarketTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Database
{
    public interface IAuthUnitOfWork : IUnitOfWork
    {
        public IAuthRepository<AutoresponderStandardColumn> AutoresponderColumns { get; }
        public IAuthRepository<AutoresponderStandardRecommendationProduct> AutoresponderRecommendationProducts { get; }
        public IAuthRepository<AutoresponderStandardCell> AutoresponderCells { get; }
        public IAuthRepository<AutoresponderStandardTemplate> AutoresponderTemplates { get; }
        public IAuthRepository<AutoresponderStandardTemplateArticle> AutoresponderTemplateArticles { get; }
        public IAuthRepository<AutoresponderStandardColumnBindPosition> AutoresponderColumnBindPositions { get; }
        public IAuthRepository<AutoresponderStandardConnection> AutoresponderConnections { get; }
        public IAuthRepository<AutoresponderStandardConnectionRating> AutoresponderConnectionRatings { get; }
        public IAuthRepository<AutoresponderStandardTemplateSettings> AutoresponderTemplateSettings { get; }
        public IAuthRepository<SellerConnection> SellerConnections { get; }
        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; }
        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; }
        public IAuthRepository<AutoresponderStandardBlackList> AutoresponderBlackLists { get; }
        public IAuthRepository<AutoresponderStandardBanWord> AutoresponderBanWords { get; }
    }
}
