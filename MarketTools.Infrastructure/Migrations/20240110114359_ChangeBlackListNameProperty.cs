using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MarketTools.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ChangeBlackListNameProperty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BindAutoresponerBlackListId",
                table: "StandardAutoresponderTemplates",
                newName: "BlackListId");

            migrationBuilder.RenameIndex(
                name: "IX_StandardAutoresponderTemplates_BindAutoresponerBlackListId",
                table: "StandardAutoresponderTemplates",
                newName: "IX_StandardAutoresponderTemplates_BlackListId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlackListId",
                table: "StandardAutoresponderTemplates",
                newName: "BindAutoresponerBlackListId");

            migrationBuilder.RenameIndex(
                name: "IX_StandardAutoresponderTemplates_BlackListId",
                table: "StandardAutoresponderTemplates",
                newName: "IX_StandardAutoresponderTemplates_BindAutoresponerBlackListId");
        }
    }
}
