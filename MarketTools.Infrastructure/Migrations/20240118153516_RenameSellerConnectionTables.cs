using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameSellerConnectionTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderConnections_SellerConnections_SellerCo~",
                table: "StandardAutoresponderConnections");

            migrationBuilder.DropTable(
                name: "SellerConnections");

            migrationBuilder.CreateTable(
                name: "MarketplaceConnection",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    NumConnectionsAttempt = table.Column<int>(type: "integer", nullable: false),
                    LastBadConnectDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    Token = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    WbSellerOpenApiConnectionEntity_Token = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceConnection", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceConnection_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnection_UserId",
                table: "MarketplaceConnection",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderConnections_MarketplaceConnection_Sell~",
                table: "StandardAutoresponderConnections",
                column: "SellerConnectionId",
                principalTable: "MarketplaceConnection",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StandardAutoresponderConnections_MarketplaceConnection_Sell~",
                table: "StandardAutoresponderConnections");

            migrationBuilder.DropTable(
                name: "MarketplaceConnection");

            migrationBuilder.CreateTable(
                name: "SellerConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Description = table.Column<string>(type: "character varying(300)", maxLength: 300, nullable: true),
                    Discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    LastBadConnectDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    NumConnectionsAttempt = table.Column<int>(type: "integer", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Token = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true),
                    WbOpenApiSellerConnectionEntity_Token = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SellerConnections", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SellerConnections_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SellerConnections_UserId",
                table: "SellerConnections",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_StandardAutoresponderConnections_SellerConnections_SellerCo~",
                table: "StandardAutoresponderConnections",
                column: "SellerConnectionId",
                principalTable: "SellerConnections",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
