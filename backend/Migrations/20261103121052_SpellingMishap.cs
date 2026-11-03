using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class SpellingMishap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 4,
                column: "Description",
                value: "Uppnå en streak av minst 31 dagar.");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 4,
                column: "Description",
                value: "uppnå en streak av minst 31 dagar.");
        }
    }
}
