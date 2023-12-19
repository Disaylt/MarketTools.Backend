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
        public IAuthRepository<StandardAutoresponderColumn> StandardAutoresponderColumns { get; }
        public IAuthRepository<StandardAutoresponderRecommendationProduct> StandardAutoresponderRecommendationProducts { get; }
        public IAuthRepository<StandardAutoresponderCell> StandardAutoresponderCells { get; }
        public IAuthRepository<StandardAutoresponderTemplate> StandardAutoresponderTemplates { get; }
        public IAuthRepository<StandardAutoresponderTemplateArticle> StandardAutoresponderTemplateArticles { get; }
        public IAuthRepository<StandardAutoresponderColumnBindPosition> StandardAutoresponderColumnBindPositions { get; }
        public IAuthRepository<StandardAutoresponderConnection> StandardAutoresponderConnections { get; }
        public IAuthRepository<StandardAutoresponderConnectionRating> StandardAutoresponderConnectionRatings { get; }
        public IAuthRepository<StandardAutoresponderTemplateSettings> StandardAutoresponderTemplateSettings { get; }
        public IAuthRepository<SellerConnection> SellerConnections { get; }
        public IAuthRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; }
        public IAuthRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; }
        public IAuthRepository<StandardAutoresponderBlackList> StandardAutoresponderBlackLists { get; }
        public IAuthRepository<StandardAutoresponderBanWord> StandardAutoresponderBanWords { get; }
    }
}
