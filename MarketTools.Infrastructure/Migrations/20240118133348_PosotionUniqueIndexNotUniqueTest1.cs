using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class PosotionUniqueIndexNotUniqueTest1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions");

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions");

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" },
                unique: true);
        }
    }
}
