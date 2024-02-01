using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class DeleteNameMarketplacesConnections : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WbSellerOpenApiConnectionEntity_Token",
                table: "MarketplaceConnection");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WbSellerOpenApiConnectionEntity_Token",
                table: "MarketplaceConnection",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
