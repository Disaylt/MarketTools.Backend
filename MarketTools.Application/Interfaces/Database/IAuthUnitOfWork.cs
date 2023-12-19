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
        public IAuthRepository<StandardAutoresponderColumn> AutoresponderColumns { get; }
        public IAuthRepository<StandardAutoresponderRecommendationProduct> AutoresponderRecommendationProducts { get; }
        public IAuthRepository<StandardAutoresponderCell> AutoresponderCells { get; }
        public IAuthRepository<StandardAutoresponderTemplate> AutoresponderTemplates { get; }
        public IAuthRepository<StandardAutoresponderTemplateArticle> AutoresponderTemplateArticles { get; }
        public IAuthRepository<StandardAutoresponderColumnBindPosition> AutoresponderColumnBindPositions { get; }
        public IAuthRepository<StandardAutoresponderConnection> AutoresponderConnections { get; }
        public IAuthRepository<StandardAutoresponderConnectionRating> AutoresponderConnectionRatings { get; }
        public IAuthRepository<StandardAutoresponderTemplateSettings> AutoresponderTemplateSettings { get; }
        public IAuthRepository<SellerConnection> SellerConnections { get; }
        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; }
        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; }
        public IAuthRepository<StandardAutoresponderBlackList> AutoresponderBlackLists { get; }
        public IAuthRepository<StandardAutoresponderBanWord> AutoresponderBanWords { get; }
    }
}
