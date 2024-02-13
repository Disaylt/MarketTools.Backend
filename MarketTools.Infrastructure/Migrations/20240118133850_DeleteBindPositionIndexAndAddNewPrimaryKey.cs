using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteBindPositionIndexAndAddNewPrimaryKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StandardAutoresponderBindPositions",
                table: "StandardAutoresponderBindPositions");

            migrationBuilder.DropIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandardAutoresponderBindPositions",
                table: "StandardAutoresponderBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_StandardAutoresponderBindPositions",
                table: "StandardAutoresponderBindPositions");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StandardAutoresponderBindPositions",
                table: "StandardAutoresponderBindPositions",
                columns: new[] { "Position", "TemplateId" });

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" });
        }
    }
}
