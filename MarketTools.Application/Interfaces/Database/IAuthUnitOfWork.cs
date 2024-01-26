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
        public IRepository<StandardAutoresponderColumnEntity> StandardAutoresponderColumns { get; }
        public IRepository<StandardAutoresponderRecommendationProductEntity> StandardAutoresponderRecommendationProducts { get; }
        public IRepository<StandardAutoresponderCell> StandardAutoresponderCells { get; }
        public IRepository<StandardAutoresponderTemplateEntity> StandardAutoresponderTemplates { get; }
        public IRepository<StandardAutoresponderTemplateArticleEntity> StandardAutoresponderTemplateArticles { get; }
        public IRepository<StandardAutoresponderBindPositionEntity> StandardAutoresponderBindPositions { get; }
        public IRepository<StandardAutoresponderConnectionEntity> StandardAutoresponderConnections { get; }
        public IRepository<StandardAutoresponderConnectionRatingEntity> StandardAutoresponderConnectionRatings { get; }
        public IRepository<StandardAutoresponderTemplateSettingsEntity> StandardAutoresponderTemplateSettings { get; }
        public IRepository<MarketplaceConnectionEntity> SellerConnections { get; }
        public IRepository<StandardAutoresponderBlackListEntity> StandardAutoresponderBlackLists { get; }
        public IRepository<StandardAutoresponderBanWordEntity> StandardAutoresponderBanWords { get; }
        public IRepository<OzonSellerOpenApiConnectionEntity> OzonSellerOpenApiConnections { get; }
        public IRepository<WbSellerOpenApiConnectionEntity> WbSellerOpenApiConnections { get; }
    }
}
