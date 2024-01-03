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
        public IRepository<StandardAutoresponderColumn> StandardAutoresponderColumns { get; }
        public IRepository<StandardAutoresponderRecommendationProduct> StandardAutoresponderRecommendationProducts { get; }
        public IRepository<StandardAutoresponderCell> StandardAutoresponderCells { get; }
        public IRepository<StandardAutoresponderTemplate> StandardAutoresponderTemplates { get; }
        public IRepository<StandardAutoresponderTemplateArticle> StandardAutoresponderTemplateArticles { get; }
        public IRepository<StandardAutoresponderColumnBindPosition> StandardAutoresponderColumnBindPositions { get; }
        public IRepository<StandardAutoresponderConnection> StandardAutoresponderConnections { get; }
        public IRepository<StandardAutoresponderConnectionRating> StandardAutoresponderConnectionRatings { get; }
        public IRepository<StandardAutoresponderTemplateSettings> StandardAutoresponderTemplateSettings { get; }
        public IRepository<SellerConnection> SellerConnections { get; }
        public IRepository<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; }
        public IRepository<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; }
        public IRepository<StandardAutoresponderBlackList> StandardAutoresponderBlackLists { get; }
        public IRepository<StandardAutoresponderBanWord> StandardAutoresponderBanWords { get; }
    }
}
