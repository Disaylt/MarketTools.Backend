using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangBinPositionEntity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespon~",
                table: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.AlterColumn<int>(
                name: "ColumnId",
                table: "StandardAutoresponderColumnBindPositions",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions",
                columns: new[] { "Position", "TemplateId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespon~",
                table: "StandardAutoresponderColumnBindPositions",
                column: "ColumnId",
                principalTable: "StandardAutoresponderColumns",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespon~",
                table: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.DropIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.AlterColumn<int>(
                name: "ColumnId",
                table: "StandardAutoresponderColumnBindPositions",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespon~",
                table: "StandardAutoresponderColumnBindPositions",
                column: "ColumnId",
                principalTable: "StandardAutoresponderColumns",
                principalColumn: "Id");
        }
    }
}
