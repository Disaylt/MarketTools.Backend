using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddNewMarketplaceConnection : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Token",
                table: "MarketplaceConnection");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "MarketplaceConnection",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(34)",
                oldMaxLength: 34);

            migrationBuilder.AddColumn<int>(
                name: "ConnectionType",
                table: "MarketplaceConnection",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "MarketplaceConnectionCookies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConnectionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false),
                    Path = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Domain = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceConnectionCookies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceConnectionCookies_MarketplaceConnection_Connecti~",
                        column: x => x.ConnectionId,
                        principalTable: "MarketplaceConnection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MarketplaceConnectionHeaders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConnectionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    Value = table.Column<string>(type: "character varying(2000)", maxLength: 2000, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MarketplaceConnectionHeaders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MarketplaceConnectionHeaders_MarketplaceConnection_Connecti~",
                        column: x => x.ConnectionId,
                        principalTable: "MarketplaceConnection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionCookies_ConnectionId",
                table: "MarketplaceConnectionCookies",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_MarketplaceConnectionHeaders_ConnectionId",
                table: "MarketplaceConnectionHeaders",
                column: "ConnectionId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MarketplaceConnectionCookies");

            migrationBuilder.DropTable(
                name: "MarketplaceConnectionHeaders");

            migrationBuilder.DropColumn(
                name: "ConnectionType",
                table: "MarketplaceConnection");

            migrationBuilder.AlterColumn<string>(
                name: "Discriminator",
                table: "MarketplaceConnection",
                type: "character varying(34)",
                maxLength: 34,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Token",
                table: "MarketplaceConnection",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true);
        }
    }
}
