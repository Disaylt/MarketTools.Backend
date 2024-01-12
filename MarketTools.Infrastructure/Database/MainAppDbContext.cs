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

        public DbSet<StandardAutoresponderColumnEntity> StandardAutoresponderColumns { get; set; } = null!;
        public DbSet<StandardAutoresponderRecommendationProductEntity> StandardAutoresponderRecommendationProducts { get; set;} = null!;
        public DbSet<StandardAutoresponderCell> StandardAutoresponderCells { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateEntity> StandardAutoresponderTemplates { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateArticleEntity> StandardAutoresponderTemplateArticles { get; set; } = null!;
        public DbSet<StandardAutoresponderBindPositionEntity> StandardAutoresponderBindPositions { get; set; } = null!;
        public DbSet<StandardAutoresponderConnectionEntity> StandardAutoresponderConnections { get; set; } = null!;
        public DbSet<StandardAutoresponderConnectionRatingEntity> StandardAutoresponderConnectionRatings { get; set; } = null!;
        public DbSet<StandardAutoresponderTemplateSettingsEntity> StandardAutoresponderTemplateSettings { get; set; } = null!;
        public DbSet<SellerConnectionEntity> SellerConnections { get; set; } = null!;
        public DbSet<OzonOpenApiSellerConnectionEntity> OzonOpenApiSellerConnections { get; set; } = null!;
        public DbSet<WbOpenApiSellerConnectionEntity> WbOpenApiSellerConnections { get; set; } = null!;
        public DbSet<StandardAutoresponderBlackListEntity> StandardAutoresponderBlackLists { get; set; } = null!;
        public DbSet<StandardAutoresponderBanWordEntity> StandardAutoresponderBanWords { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<StandardAutoresponderBindPositionEntity>().HasKey(x => new { x.Position, x.TemplateId });
            builder.Entity<StandardAutoresponderConnectionRatingEntity>().HasKey(x => new { x.Rating, x.ConnectionId });
        }
    }
}
