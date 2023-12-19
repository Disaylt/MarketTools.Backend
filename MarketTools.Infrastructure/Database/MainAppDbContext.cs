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

        public DbSet<StandardAutoresponderColumn> StandardAutoresponderColumns { get; set; } = null!;
        public DbSet<StandardAutoresponderRecommendationProduct> StandardAutoresponderRecommendationProducts { get; set;} = null!;
        public DbSet<StandardAutoresponderCell> StandardAutoresponderCells { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplate> StandardAutoresponderTemplates { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateArticle> StandardAutoresponderTemplateArticles { get; set; } = null!;
        public DbSet<StandardAutoresponderColumnBindPosition> StandardAutoresponderColumnBindPositions { get; set; } = null!;
        public DbSet<StandardAutoresponderConnection> StandardAutoresponderConnections { get; set; } = null!;
        public DbSet<StandardAutoresponderConnectionRating> StandardAutoresponderConnectionRatings { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateSettings> StandardAutoresponderTemplateSettings { get; set; } = null!;
        public DbSet<SellerConnection> SellerConnections { get; set; } = null!;
        public DbSet<OzonOpenApiSellerConnection> OzonOpenApiSellerConnections { get; set; } = null!;
        public DbSet<WbOpenApiSellerConnection> WbOpenApiSellerConnections { get; set; } = null!;
        public DbSet<StandardAutoresponderBlackList> StandardAutoresponderBlackLists { get; set; } = null!;
        public DbSet<StandardAutoresponderBanWord> StandardAutoresponderBanWords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StandardAutoresponderColumnBindPosition>().HasKey(x => new { x.Position, x.TemplateId });
            builder.Entity<StandardAutoresponderConnectionRating>().HasKey(x => new { x.Rating, x.ConnectionId });
        }
    }
}
