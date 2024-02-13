using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameBindPositionTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderBindPositions",
                columns: table => new
                {
                    Position = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    ColumnId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderBindPositions", x => new { x.Position, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderBindPositions_StandardAutoresponderCol~",
                        column: x => x.ColumnId,
                        principalTable: "StandardAutoresponderColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderBindPositions_StandardAutoresponderTem~",
                        column: x => x.TemplateId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderBindPositions_ColumnId",
                table: "StandardAutoresponderBindPositions",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderBindPositions_TemplateId",
                table: "StandardAutoresponderBindPositions",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardAutoresponderBindPositions");

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderColumnBindPositions",
                columns: table => new
                {
                    Position = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    ColumnId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderColumnBindPositions", x => new { x.Position, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespon~",
                        column: x => x.ColumnId,
                        principalTable: "StandardAutoresponderColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespo~1",
                        column: x => x.TemplateId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderColumnBindPositions_ColumnId",
                table: "StandardAutoresponderColumnBindPositions",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderColumnBindPositions_TemplateId",
                table: "StandardAutoresponderColumnBindPositions",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "PosotionUniqueIndex",
                table: "StandardAutoresponderColumnBindPositions",
                columns: new[] { "Position", "TemplateId", "ColumnId" },
                unique: true);
        }
    }
}
