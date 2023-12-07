using MarketTools.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Application.Interfaces.Database
{
    public interface IMainDatabaseContext : IDisposable
    {
        public DbSet<AutoresponderColumn> AutoresponderColumns { get; set; }
        public DbSet<AutoresponderRecommendationProduct> AutoresponderRecommendationProducts { get; set; }
        public DbSet<AutoresponderCell> AutoresponderCells { get; set; }
        public DbSet<AutoresponderTemplate> AutoresponderTemplates { get; set; }
        public DbSet<AutoresponderTemplateArticle> AutoresponderTemplateArticles { get; set; }
        public DbSet<AutoresponderColumnBindPosition> AutoresponderColumnBindPositions { get; set; }
        public DbSet<AutoresponderConnection> AutoresponderConnections { get; set; }
        public DbSet<AutoresponderConnectionRating> AutoresponderConnectionRatings { get; set; }
        public DbSet<AutoresponderTemplateSettings> AutoresponderTemplateSettings { get; set; }
        public DbSet<SellerConnection> SellerConnections { get; set; }
        public DbSet<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; set; }
        public DbSet<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; set; }
        public DbSet<AutoresponderBlackList> AutoresponderBlackLists { get; set; }
        public DbSet<AutoresponderBanWord> AutoresponderBanWords { get; set; }

        public DbSet<AppIdentityUser> Users { get; set; }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public Task<int> SaveChangesAsync();
        public DatabaseFacade Database { get; }
    }
}
