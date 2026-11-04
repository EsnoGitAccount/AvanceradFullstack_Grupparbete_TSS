using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddUniqueUserDailyChallengeIndex : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_UserId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId_DailyChallangeId",
                table: "Games",
                columns: new[] { "UserId", "DailyChallangeId" },
                unique: true,
                filter: "[UserId] IS NOT NULL AND [DailyChallangeId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Games_UserId_DailyChallangeId",
                table: "Games");

            migrationBuilder.CreateIndex(
                name: "IX_Games_UserId",
                table: "Games",
                column: "UserId");
        }
    }
}
