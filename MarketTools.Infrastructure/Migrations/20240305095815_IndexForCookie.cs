using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class IndexForCookie : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId_Name",
                table: "MarketplaceConnectionCookies");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId_Name_Domain",
                table: "MarketplaceConnectionCookies",
                columns: new[] { "ConnectionId", "Name", "Domain" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId_Name_Domain",
                table: "MarketplaceConnectionCookies");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId_Name",
                table: "MarketplaceConnectionCookies",
                columns: new[] { "ConnectionId", "Name" },
                unique: true);
        }
    }
}
