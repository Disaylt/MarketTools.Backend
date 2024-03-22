using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddConnectionHeaderAndCookieIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarketplaceConnectionHeaders_ConnectionId",
                table: "MarketplaceConnectionHeaders");

            migrationBuilder.DropIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId",
                table: "MarketplaceConnectionCookies");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionHeaders_ConnectionId_Name",
                table: "MarketplaceConnectionHeaders",
                columns: new[] { "ConnectionId", "Name" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId_Name",
                table: "MarketplaceConnectionCookies",
                columns: new[] { "ConnectionId", "Name" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarketplaceConnectionHeaders_ConnectionId_Name",
                table: "MarketplaceConnectionHeaders");

            migrationBuilder.DropIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId_Name",
                table: "MarketplaceConnectionCookies");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionHeaders_ConnectionId",
                table: "MarketplaceConnectionHeaders",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId",
                table: "MarketplaceConnectionCookies",
                column: "ConnectionId");
        }
    }
}
