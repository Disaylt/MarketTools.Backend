using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class BasePriceMontiringTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PriceMonitoringConnections",
                columns: table => new
                {
                    SellerConnectionId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitoringConnections", x => x.SellerConnectionId);
                    table.ForeignKey(
                        name: "FK_PriceMonitoringConnections_MarketplaceConnection_SellerConn~",
                        column: x => x.SellerConnectionId,
                        principalTable: "MarketplaceConnection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceMonitoringProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Article = table.Column<string>(type: "text", nullable: false),
                    SellerArticle = table.Column<string>(type: "text", nullable: false),
                    ConnectionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitoringProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceMonitoringProducts_PriceMonitoringConnections_Connecti~",
                        column: x => x.ConnectionId,
                        principalTable: "PriceMonitoringConnections",
                        principalColumn: "SellerConnectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceMonitoringReports",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ConnectionId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitoringReports", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceMonitoringReports_PriceMonitoringConnections_Connectio~",
                        column: x => x.ConnectionId,
                        principalTable: "PriceMonitoringConnections",
                        principalColumn: "SellerConnectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceMonitoringSizes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SizeName = table.Column<string>(type: "text", nullable: false),
                    SellerPrice = table.Column<double>(type: "double precision", nullable: false),
                    SellerDicsountPrice = table.Column<double>(type: "double precision", nullable: false),
                    SellerDiscount = table.Column<int>(type: "integer", nullable: false),
                    BuyerDiscountPrice = table.Column<double>(type: "double precision", nullable: false),
                    BuyerDiscount = table.Column<int>(type: "integer", nullable: false),
                    ProductId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitoringSizes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceMonitoringSizes_PriceMonitoringProducts_ProductId",
                        column: x => x.ProductId,
                        principalTable: "PriceMonitoringProducts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceMonitoringProductRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Article = table.Column<string>(type: "text", nullable: false),
                    SellerArticle = table.Column<string>(type: "text", nullable: false),
                    ReportId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitoringProductRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceMonitoringProductRecords_PriceMonitoringReports_Report~",
                        column: x => x.ReportId,
                        principalTable: "PriceMonitoringReports",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PriceMonitoringSizetRecords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    SizeName = table.Column<string>(type: "text", nullable: false),
                    NewSellerPrice = table.Column<double>(type: "double precision", nullable: false),
                    NewSellerDicsountPrice = table.Column<double>(type: "double precision", nullable: false),
                    NewSellerDiscount = table.Column<int>(type: "integer", nullable: false),
                    NewBuyerDiscountPrice = table.Column<double>(type: "double precision", nullable: false),
                    NewBuyerDiscount = table.Column<int>(type: "integer", nullable: false),
                    OldSellerPrice = table.Column<double>(type: "double precision", nullable: false),
                    OldSellerDicsountPrice = table.Column<double>(type: "double precision", nullable: false),
                    OldSellerDiscount = table.Column<int>(type: "integer", nullable: false),
                    OldBuyerDiscountPrice = table.Column<double>(type: "double precision", nullable: false),
                    OldBuyerDiscount = table.Column<int>(type: "integer", nullable: false),
                    ProductRecordId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PriceMonitoringSizetRecords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PriceMonitoringSizetRecords_PriceMonitoringProductRecords_P~",
                        column: x => x.ProductRecordId,
                        principalTable: "PriceMonitoringProductRecords",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitoringProductRecords_ReportId",
                table: "PriceMonitoringProductRecords",
                column: "ReportId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitoringProducts_ConnectionId",
                table: "PriceMonitoringProducts",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitoringReports_ConnectionId",
                table: "PriceMonitoringReports",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitoringSizes_ProductId",
                table: "PriceMonitoringSizes",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_PriceMonitoringSizetRecords_ProductRecordId",
                table: "PriceMonitoringSizetRecords",
                column: "ProductRecordId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PriceMonitoringSizes");

            migrationBuilder.DropTable(
                name: "PriceMonitoringSizetRecords");

            migrationBuilder.DropTable(
                name: "PriceMonitoringProducts");

            migrationBuilder.DropTable(
                name: "PriceMonitoringProductRecords");

            migrationBuilder.DropTable(
                name: "PriceMonitoringReports");

            migrationBuilder.DropTable(
                name: "PriceMonitoringConnections");
        }
    }
}
