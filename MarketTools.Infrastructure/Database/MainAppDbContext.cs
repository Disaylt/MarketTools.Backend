using MarketTools.Application.Interfaces.Database;
using MarketTools.Domain.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarketTools.Infrastructure.Database
{
    public class MainAppDbContext : IdentityDbContext<AppIdentityUser>
    {
        public MainAppDbContext(DbContextOptions<MainAppDbContext> options) : base(options) { }

        public DbSet<AutoresponderStandardColumn> AutoresponderColumns { get; set; } = null!;
        public DbSet<AutoresponderStandardRecommendationProduct> AutoresponderRecommendationProducts { get; set;} = null!;
        public DbSet<AutoresponderStandardCell> AutoresponderCells { get; set; } = null!;
        public DbSet<AutoresponderStandardTemplate> AutoresponderTemplates { get; set; } = null!;
        public DbSet<AutoresponderStandardTemplateArticle> AutoresponderTemplateArticles { get; set; } = null!;
        public DbSet<AutoresponderStandardColumnBindPosition> AutoresponderColumnBindPositions { get; set; } = null!;
        public DbSet<AutoresponderStandardConnection> AutoresponderConnections { get; set; } = null!;
        public DbSet<AutoresponderStandardConnectionRating> AutoresponderConnectionRatings { get; set; } = null!;
        public DbSet<AutoresponderStandardTemplateSettings> AutoresponderTemplateSettings { get; set; } = null!;
        public DbSet<SellerConnection> SellerConnections { get; set; } = null!;
        public DbSet<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; set; } = null!;
        public DbSet<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; set; } = null!;
        public DbSet<AutoresponderStandardBlackList> AutoresponderBlackLists { get; set; } = null!;
        public DbSet<AutoresponderStandardBanWord> AutoresponderBanWords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<AutoresponderStandardColumnBindPosition>().HasKey(x => new { x.Position, x.TemplateId });
            builder.Entity<AutoresponderStandardConnectionRating>().HasKey(x => new { x.Rating, x.ConnectionId });
        }
    }
}
