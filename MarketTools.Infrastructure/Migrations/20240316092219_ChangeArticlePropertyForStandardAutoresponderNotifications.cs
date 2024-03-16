using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeArticlePropertyForStandardAutoresponderNotifications : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Article",
                table: "StandardAutoresponderNotifications",
                type: "text",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "integer");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Article",
                table: "StandardAutoresponderNotifications",
                type: "integer",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "text");
        }
    }
}
