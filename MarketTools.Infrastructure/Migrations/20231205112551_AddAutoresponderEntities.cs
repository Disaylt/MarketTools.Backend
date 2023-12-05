using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddAutoresponderEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateDate",
                table: "AspNetUsers",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "AutoresponderBlackLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderBlackLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderBlackLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderColumns",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderColumns_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderRecommendationProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FeedbackArticle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    FeedbackProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    RecommendationArticle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    RecommendationProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MarketplaceName = table.Column<int>(type: "integer", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderRecommendationProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderRecommendationProducts_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderTemplates",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderTemplates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SellerConnections",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    Discriminator = table.Column<string>(type: "character varying(34)", maxLength: 34, nullable: false),
                    Token = table.Column<string>(type: "text", nullable: true),
                    WbOpenApiSellerConnection_Token = table.Column<string>(type: "text", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
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

            migrationBuilder.CreateTable(
                name: "AutoresponderBanWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    BlackListId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderBanWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderBanWords_AutoresponderBlackLists_BlackListId",
                        column: x => x.BlackListId,
                        principalTable: "AutoresponderBlackLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderCells",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Value = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false),
                    ColumnId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderCells_AutoresponderColumns_ColumnId",
                        column: x => x.ColumnId,
                        principalTable: "AutoresponderColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderColumnBindPositions",
                columns: table => new
                {
                    Position = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    ColumnId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderColumnBindPositions", x => new { x.Position, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_AutoresponderColumnBindPositions_AutoresponderColumns_Colum~",
                        column: x => x.ColumnId,
                        principalTable: "AutoresponderColumns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AutoresponderColumnBindPositions_AutoresponderTemplates_Tem~",
                        column: x => x.TemplateId,
                        principalTable: "AutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderTemplateArticles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Article = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderTemplateArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AutoresponderTemplateArticles_AutoresponderTemplates_Templa~",
                        column: x => x.TemplateId,
                        principalTable: "AutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderTemplateSettings",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    IsSkipWithTextFeedbacks = table.Column<bool>(type: "boolean", nullable: false),
                    IsSkipEmptyFeedbacks = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderTemplateSettings", x => x.TemplateId);
                    table.ForeignKey(
                        name: "FK_AutoresponderTemplateSettings_AutoresponderTemplates_Templa~",
                        column: x => x.TemplateId,
                        principalTable: "AutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderConnections",
                columns: table => new
                {
                    SellerConnectionId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderConnections", x => x.SellerConnectionId);
                    table.ForeignKey(
                        name: "FK_AutoresponderConnections_SellerConnections_SellerConnection~",
                        column: x => x.SellerConnectionId,
                        principalTable: "SellerConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderConnectionRatings",
                columns: table => new
                {
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ConnectionId = table.Column<int>(type: "integer", nullable: false),
                    BindAutoresponerBlackListId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderConnectionRatings", x => new { x.Rating, x.ConnectionId });
                    table.ForeignKey(
                        name: "FK_AutoresponderConnectionRatings_AutoresponderBlackLists_Bind~",
                        column: x => x.BindAutoresponerBlackListId,
                        principalTable: "AutoresponderBlackLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AutoresponderConnectionRatings_AutoresponderConnections_Con~",
                        column: x => x.ConnectionId,
                        principalTable: "AutoresponderConnections",
                        principalColumn: "SellerConnectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AutoresponderConnectionRatingAutoresponderTemplate",
                columns: table => new
                {
                    TemplatesId = table.Column<int>(type: "integer", nullable: false),
                    RatingsRating = table.Column<int>(type: "integer", nullable: false),
                    RatingsConnectionId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AutoresponderConnectionRatingAutoresponderTemplate", x => new { x.TemplatesId, x.RatingsRating, x.RatingsConnectionId });
                    table.ForeignKey(
                        name: "FK_AutoresponderConnectionRatingAutoresponderTemplate_Autoresp~",
                        column: x => x.TemplatesId,
                        principalTable: "AutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AutoresponderConnectionRatingAutoresponderTemplate_Autores~1",
                        columns: x => new { x.RatingsRating, x.RatingsConnectionId },
                        principalTable: "AutoresponderConnectionRatings",
                        principalColumns: new[] { "Rating", "ConnectionId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderBanWords_BlackListId",
                table: "AutoresponderBanWords",
                column: "BlackListId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderBlackLists_UserId",
                table: "AutoresponderBlackLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderCells_ColumnId",
                table: "AutoresponderCells",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderColumnBindPositions_ColumnId",
                table: "AutoresponderColumnBindPositions",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderColumnBindPositions_TemplateId",
                table: "AutoresponderColumnBindPositions",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderColumns_UserId",
                table: "AutoresponderColumns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderConnectionRatingAutoresponderTemplate_RatingsR~",
                table: "AutoresponderConnectionRatingAutoresponderTemplate",
                columns: new[] { "RatingsRating", "RatingsConnectionId" });

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderConnectionRatings_BindAutoresponerBlackListId",
                table: "AutoresponderConnectionRatings",
                column: "BindAutoresponerBlackListId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderConnectionRatings_ConnectionId",
                table: "AutoresponderConnectionRatings",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderRecommendationProducts_UserId",
                table: "AutoresponderRecommendationProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderTemplateArticles_TemplateId",
                table: "AutoresponderTemplateArticles",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_AutoresponderTemplates_UserId",
                table: "AutoresponderTemplates",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_SellerConnections_UserId",
                table: "SellerConnections",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AutoresponderBanWords");

            migrationBuilder.DropTable(
                name: "AutoresponderCells");

            migrationBuilder.DropTable(
                name: "AutoresponderColumnBindPositions");

            migrationBuilder.DropTable(
                name: "AutoresponderConnectionRatingAutoresponderTemplate");

            migrationBuilder.DropTable(
                name: "AutoresponderRecommendationProducts");

            migrationBuilder.DropTable(
                name: "AutoresponderTemplateArticles");

            migrationBuilder.DropTable(
                name: "AutoresponderTemplateSettings");

            migrationBuilder.DropTable(
                name: "AutoresponderColumns");

            migrationBuilder.DropTable(
                name: "AutoresponderConnectionRatings");

            migrationBuilder.DropTable(
                name: "AutoresponderTemplates");

            migrationBuilder.DropTable(
                name: "AutoresponderBlackLists");

            migrationBuilder.DropTable(
                name: "AutoresponderConnections");

            migrationBuilder.DropTable(
                name: "SellerConnections");

            migrationBuilder.DropColumn(
                name: "CreateDate",
                table: "AspNetUsers");
        }
    }
}
