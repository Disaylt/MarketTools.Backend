using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RenameAutoresponderTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "WbOpenApiSellerConnection_Token",
                table: "SellerConnections",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "SellerConnections",
                type: "character varying(1000)",
                maxLength: 1000,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "SellerConnections",
                type: "character varying(300)",
                maxLength: 300,
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastBadConnectDate",
                table: "SellerConnections",
                type: "timestamp with time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "NumConnectionsAttempt",
                table: "SellerConnections",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderBlackLists",
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
                    table.PrimaryKey("PK_StandardAutoresponderBlackLists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderBlackLists_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderColumns",
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
                    table.PrimaryKey("PK_StandardAutoresponderColumns", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderColumns_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderConnections",
                columns: table => new
                {
                    SellerConnectionId = table.Column<int>(type: "integer", nullable: false),
                    IsActive = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderConnections", x => x.SellerConnectionId);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnections_SellerConnections_SellerCo~",
                        column: x => x.SellerConnectionId,
                        principalTable: "SellerConnections",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderRecommendationProducts",
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
                    table.PrimaryKey("PK_StandardAutoresponderRecommendationProducts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderRecommendationProducts_AspNetUsers_Use~",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderTemplates",
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
                    table.PrimaryKey("PK_StandardAutoresponderTemplates", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderTemplates_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderBanWords",
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
                    table.PrimaryKey("PK_StandardAutoresponderBanWords", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderBanWords_StandardAutoresponderBlackLis~",
                        column: x => x.BlackListId,
                        principalTable: "StandardAutoresponderBlackLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderCells",
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
                    table.PrimaryKey("PK_StandardAutoresponderCells", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderCells_StandardAutoresponderColumns_Col~",
                        column: x => x.ColumnId,
                        principalTable: "StandardAutoresponderColumns",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderConnectionRatings",
                columns: table => new
                {
                    Rating = table.Column<int>(type: "integer", nullable: false),
                    ConnectionId = table.Column<int>(type: "integer", nullable: false),
                    BindAutoresponerBlackListId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderConnectionRatings", x => new { x.Rating, x.ConnectionId });
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnectionRatings_StandardAutoresponde~",
                        column: x => x.BindAutoresponerBlackListId,
                        principalTable: "StandardAutoresponderBlackLists",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderConnectionRatings_StandardAutorespond~1",
                        column: x => x.ConnectionId,
                        principalTable: "StandardAutoresponderConnections",
                        principalColumn: "SellerConnectionId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderColumnBindPositions",
                columns: table => new
                {
                    Position = table.Column<int>(type: "integer", nullable: false),
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    ColumnId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderColumnBindPositions", x => new { x.Position, x.TemplateId });
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespon~",
                        column: x => x.ColumnId,
                        principalTable: "StandardAutoresponderColumns",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderColumnBindPositions_StandardAutorespo~1",
                        column: x => x.TemplateId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderTemplateArticles",
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
                    table.PrimaryKey("PK_StandardAutoresponderTemplateArticles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderTemplateArticles_StandardAutoresponder~",
                        column: x => x.TemplateId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StandardAutoresponderTemplateSettings",
                columns: table => new
                {
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    IsSkipWithTextFeedbacks = table.Column<bool>(type: "boolean", nullable: false),
                    IsSkipEmptyFeedbacks = table.Column<bool>(type: "boolean", nullable: false),
                    AsMainTemplate = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StandardAutoresponderTemplateSettings", x => x.TemplateId);
                    table.ForeignKey(
                        name: "FK_StandardAutoresponderTemplateSettings_StandardAutoresponder~",
                        column: x => x.TemplateId,
                        principalTable: "StandardAutoresponderTemplates",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "IX_StandardAutoresponderBanWords_BlackListId",
                table: "StandardAutoresponderBanWords",
                column: "BlackListId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderBlackLists_UserId",
                table: "StandardAutoresponderBlackLists",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderCells_ColumnId",
                table: "StandardAutoresponderCells",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderColumnBindPositions_ColumnId",
                table: "StandardAutoresponderColumnBindPositions",
                column: "ColumnId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderColumnBindPositions_TemplateId",
                table: "StandardAutoresponderColumnBindPositions",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderColumns_UserId",
                table: "StandardAutoresponderColumns",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderConnectionRatingStandardAutoresponderT~",
                table: "StandardAutoresponderConnectionRatingStandardAutoresponderTemp~",
                columns: new[] { "RatingsRating", "RatingsConnectionId" });

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderConnectionRatings_BindAutoresponerBlac~",
                table: "StandardAutoresponderConnectionRatings",
                column: "BindAutoresponerBlackListId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderConnectionRatings_ConnectionId",
                table: "StandardAutoresponderConnectionRatings",
                column: "ConnectionId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderRecommendationProducts_UserId",
                table: "StandardAutoresponderRecommendationProducts",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderTemplateArticles_TemplateId",
                table: "StandardAutoresponderTemplateArticles",
                column: "TemplateId");

            migrationBuilder.CreateIndex(
                name: "IX_StandardAutoresponderTemplates_UserId",
                table: "StandardAutoresponderTemplates",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StandardAutoresponderBanWords");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderCells");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderColumnBindPositions");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderConnectionRatingStandardAutoresponderTemp~");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderRecommendationProducts");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderTemplateArticles");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderTemplateSettings");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderColumns");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderConnectionRatings");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderTemplates");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderBlackLists");

            migrationBuilder.DropTable(
                name: "StandardAutoresponderConnections");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "SellerConnections");

            migrationBuilder.DropColumn(
                name: "LastBadConnectDate",
                table: "SellerConnections");

            migrationBuilder.DropColumn(
                name: "NumConnectionsAttempt",
                table: "SellerConnections");

            migrationBuilder.AlterColumn<string>(
                name: "WbOpenApiSellerConnection_Token",
                table: "SellerConnections",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Token",
                table: "SellerConnections",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(1000)",
                oldMaxLength: 1000,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "AutoresponderBlackLists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
                    Type = table.Column<int>(type: "integer", nullable: false),
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
                name: "AutoresponderRecommendationProducts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    FeedbackArticle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: false),
                    FeedbackProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    MarketplaceName = table.Column<int>(type: "integer", nullable: false),
                    RecommendationArticle = table.Column<string>(type: "character varying(25)", maxLength: 25, nullable: true),
                    RecommendationProductName = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
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
                    UserId = table.Column<string>(type: "text", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Name = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false),
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
                name: "AutoresponderBanWords",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    BlackListId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: false)
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
                    ColumnId = table.Column<int>(type: "integer", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Value = table.Column<string>(type: "character varying(1000)", maxLength: 1000, nullable: false)
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
                    TemplateId = table.Column<int>(type: "integer", nullable: false),
                    Article = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
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
                    AsMainTemplate = table.Column<bool>(type: "boolean", nullable: false),
                    IsSkipEmptyFeedbacks = table.Column<bool>(type: "boolean", nullable: false),
                    IsSkipWithTextFeedbacks = table.Column<bool>(type: "boolean", nullable: false)
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
        }
    }
}
