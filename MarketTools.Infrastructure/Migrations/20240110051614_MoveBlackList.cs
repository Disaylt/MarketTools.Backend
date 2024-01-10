using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class MoveBlackList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderConnectionRatings_StandardAutoresponde~",
                table: "StandardAutoresponderConnectionRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderConnectionRatings_StandardAutorespond~1",
                table: "StandardAutoresponderConnectionRatings");

            migrationBuilder.DropIndex(
                name: "IX_StandardAutoresponderConnectionRatings_BindAutoresponerBlac~",
                table: "StandardAutoresponderConnectionRatings");

            migrationBuilder.DropColumn(
                name: "BindAutoresponerBlackListId",
                table: "StandardAutoresponderConnectionRatings");

            migrationBuilder.AddColumn<int>(
                name: "BindAutoresponerBlackListId",
                table: "StandardAutoresponderTemplates",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderTemplates_BindAutoresponerBlackListId",
                table: "StandardAutoresponderTemplates",
                column: "BindAutoresponerBlackListId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderConnectionRatings_StandardAutoresponde~",
                table: "StandardAutoresponderConnectionRatings",
                column: "ConnectionId",
                principalTable: "StandardAutoresponderConnections",
                principalColumn: "SellerConnectionId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderTemplates_StandardAutoresponderBlackLi~",
                table: "StandardAutoresponderTemplates",
                column: "BindAutoresponerBlackListId",
                principalTable: "StandardAutoresponderBlackLists",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderConnectionRatings_StandardAutoresponde~",
                table: "StandardAutoresponderConnectionRatings");

            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderTemplates_StandardAutoresponderBlackLi~",
                table: "StandardAutoresponderTemplates");

            migrationBuilder.DropIndex(
                name: "IX_StandardAutoresponderTemplates_BindAutoresponerBlackListId",
                table: "StandardAutoresponderTemplates");

            migrationBuilder.DropColumn(
                name: "BindAutoresponerBlackListId",
                table: "StandardAutoresponderTemplates");

            migrationBuilder.AddColumn<int>(
                name: "BindAutoresponerBlackListId",
                table: "StandardAutoresponderConnectionRatings",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderConnectionRatings_BindAutoresponerBlac~",
                table: "StandardAutoresponderConnectionRatings",
                column: "BindAutoresponerBlackListId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderConnectionRatings_StandardAutoresponde~",
                table: "StandardAutoresponderConnectionRatings",
                column: "BindAutoresponerBlackListId",
                principalTable: "StandardAutoresponderBlackLists",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderConnectionRatings_StandardAutorespond~1",
                table: "StandardAutoresponderConnectionRatings",
                column: "ConnectionId",
                principalTable: "StandardAutoresponderConnections",
                principalColumn: "SellerConnectionId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
