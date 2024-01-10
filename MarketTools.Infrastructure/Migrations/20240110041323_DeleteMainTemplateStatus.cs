using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteMainTemplateStatus : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardAutoresponderConnectionRatingStandardAutoresponderTemp~");

            migrationBuilder.DropColumn(
                name: "AsMainTemplate",
                table: "StandardAutoresponderTemplateSettings");

            migrationBuilder.RenameColumn(
                name: "WbOpenApiSellerConnection_Token",
                table: "SellerConnections",
                newName: "WbOpenApiSellerConnectionEntity_Token");

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderConnectionRatingEntityStandardAutorespond~",
                columns: table => new
                {
                    TemplatesId = table.Column<int>(type: "integer", nullable: false),
                    RatingsRating = table.Column<int>(type: "integer", nullable: false),
                    RatingsConnectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderConnectionRatingEntityStandardAutoresp~", x => new { x.TemplatesId, x.RatingsRating, x.RatingsConnectionId });
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnectionRatingEntityStandardAutoresp~",
                        column: x => x.TemplatesId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnectionRatingEntityStandardAutores~1",
                        columns: x => new { x.RatingsRating, x.RatingsConnectionId },
                        principalTable: "StandardAutoresponderConnectionRatings",
                        principalColumns: new[] { "Rating", "ConnectionId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderConnectionRatingEntityStandardAutoresp~",
                table: "StandardAutoresponderConnectionRatingEntityStandardAutorespond~",
                columns: new[] { "RatingsRating", "RatingsConnectionId" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardAutoresponderConnectionRatingEntityStandardAutorespond~");

            migrationBuilder.RenameColumn(
                name: "WbOpenApiSellerConnectionEntity_Token",
                table: "SellerConnections",
                newName: "WbOpenApiSellerConnection_Token");

            migrationBuilder.AddColumn<bool>(
                name: "AsMainTemplate",
                table: "StandardAutoresponderTemplateSettings",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderConnectionRatingStandardAutoresponderTemp~",
                columns: table => new
                {
                    TemplatesId = table.Column<int>(type: "integer", nullable: false),
                    RatingsRating = table.Column<int>(type: "integer", nullable: false),
                    RatingsConnectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderConnectionRatingStandardAutoresponderT~", x => new { x.TemplatesId, x.RatingsRating, x.RatingsConnectionId });
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnectionRatingStandardAutoresponderT~",
                        column: x => x.TemplatesId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnectionRatingStandardAutoresponder~1",
                        columns: x => new { x.RatingsRating, x.RatingsConnectionId },
                        principalTable: "StandardAutoresponderConnectionRatings",
                        principalColumns: new[] { "Rating", "ConnectionId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderConnectionRatingStandardAutoresponderT~",
                table: "StandardAutoresponderConnectionRatingStandardAutoresponderTemp~",
                columns: new[] { "RatingsRating", "RatingsConnectionId" });
        }
    }
}
