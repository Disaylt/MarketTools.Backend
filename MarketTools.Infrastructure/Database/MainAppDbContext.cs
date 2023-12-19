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

        public DbSet<StandardAutoresponderColumn> AutoresponderColumns { get; set; } = null!;
        public DbSet<StandardAutoresponderRecommendationProduct> AutoresponderRecommendationProducts { get; set;} = null!;
        public DbSet<StandardAutoresponderCell> AutoresponderCells { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplate> AutoresponderTemplates { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateArticle> AutoresponderTemplateArticles { get; set; } = null!;
        public DbSet<StandardAutoresponderColumnBindPosition> AutoresponderColumnBindPositions { get; set; } = null!;
        public DbSet<StandardAutoresponderConnection> AutoresponderConnections { get; set; } = null!;
        public DbSet<StandardAutoresponderConnectionRating> AutoresponderConnectionRatings { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateSettings> AutoresponderTemplateSettings { get; set; } = null!;
        public DbSet<SellerConnection> SellerConnections { get; set; } = null!;
        public DbSet<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; set; } = null!;
        public DbSet<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; set; } = null!;
        public DbSet<StandardAutoresponderBlackList> AutoresponderBlackLists { get; set; } = null!;
        public DbSet<StandardAutoresponderBanWord> AutoresponderBanWords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StandardAutoresponderColumnBindPosition>().HasKey(x => new { x.Position, x.TemplateId });
            builder.Entity<StandardAutoresponderConnectionRating>().HasKey(x => new { x.Rating, x.ConnectionId });
        }
    }
}
