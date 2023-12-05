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

        public DbSet<AutoresponderColumn> AutoresponderColumns { get; set; } = null!;
        public DbSet<AutoresponderRecommendationProduct> AutoresponderRecommendationProducts { get; set;} = null!;
        public DbSet<AutoresponderCell> AutoresponderCells { get; set; } = null!;
        public DbSet<AutoresponderTemplate> AutoresponderTemplates { get; set; } = null!;
        public DbSet<AutoresponderTemplateArticle> AutoresponderTemplateArticles { get; set; } = null!;
        public DbSet<AutoresponderColumnBindPosition> AutoresponderColumnBindPositions { get; set; } = null!;
        public DbSet<AutoresponderConnection> AutoresponderConnections { get; set; } = null!;
        public DbSet<AutoresponderConnectionRating> AutoresponderConnectionRatings { get; set; } = null!;
        public DbSet<AutoresponderTemplateSettings> AutoresponderTemplateSettings { get; set; } = null!;
        public DbSet<SellerConnection> SellerConnections { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<AutoresponderColumnBindPosition>().HasKey(x => new { x.Position, x.TemplateId });
            builder.Entity<AutoresponderConnectionRating>().HasKey(x => new { x.Rating, x.ConnectionId });
        }
    }
}
