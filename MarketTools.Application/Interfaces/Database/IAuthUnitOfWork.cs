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
        public IAuthRepository<AutoresponderColumn> AutoresponderColumns { get; }
        public IAuthRepository<AutoresponderRecommendationProduct> AutoresponderRecommendationProducts { get; }
        public IAuthRepository<AutoresponderCell> AutoresponderCells { get; }
        public IAuthRepository<AutoresponderTemplate> AutoresponderTemplates { get; }
        public IAuthRepository<AutoresponderTemplateArticle> AutoresponderTemplateArticles { get; }
        public IAuthRepository<AutoresponderColumnBindPosition> AutoresponderColumnBindPositions { get; }
        public IAuthRepository<AutoresponderConnection> AutoresponderConnections { get; }
        public IAuthRepository<AutoresponderConnectionRating> AutoresponderConnectionRatings { get; }
        public IAuthRepository<AutoresponderTemplateSettings> AutoresponderTemplateSettings { get; }
        public IAuthRepository<SellerConnection> SellerConnections { get; }
        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; }
        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; }
        public IAuthRepository<AutoresponderBlackList> AutoresponderBlackLists { get; }
        public IAuthRepository<AutoresponderBanWord> AutoresponderBanWords { get; }
    }
}
