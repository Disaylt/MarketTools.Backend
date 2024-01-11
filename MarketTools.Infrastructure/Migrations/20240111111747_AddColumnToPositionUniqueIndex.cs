using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnToPositionUniqueIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions",
                columns: new[] { "Position", "TemplateId" },
                unique: true);
        }
    }
}
