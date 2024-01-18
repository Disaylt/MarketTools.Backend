using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexForTemplateArticle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_StandardAutoresponderTemplateArticles_TemplateId",
                table: "StandardAutoresponderTemplateArticles");

            migrationBuilder.CreateIndex(
                name: "UniqueArticlesIndex",
                table: "StandardAutoresponderTemplateArticles",
                columns: new[] { "TemplateId", "Article" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UniqueArticlesIndex",
                table: "StandardAutoresponderTemplateArticles");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderTemplateArticles_TemplateId",
                table: "StandardAutoresponderTemplateArticles",
                column: "TemplateId");
        }
    }
}
