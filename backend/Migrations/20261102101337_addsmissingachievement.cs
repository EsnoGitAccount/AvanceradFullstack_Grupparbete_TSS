using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class addsmissingachievement : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Uppnå en streak av minst 307 dagar.", "Permanent Spårändrat" });

            migrationBuilder.InsertData(
                table: "Achievements",
                columns: new[] { "AchievementId", "Description", "Name" },
                values: new object[] { 12, "Uppnå en streak av minst 365 dagar.", "Årskort" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 11,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Uppnå en streak av minst 365 dagar.", "Årskort" });
        }
    }
}
