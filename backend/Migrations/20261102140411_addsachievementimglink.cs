using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class addsachievementimglink : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageKey",
                table: "Achievements",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 1,
                column: "ImageKey",
                value: "3Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 2,
                column: "ImageKey",
                value: "7Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 3,
                column: "ImageKey",
                value: "14Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 4,
                column: "ImageKey",
                value: "31Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 5,
                column: "ImageKey",
                value: "50Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 6,
                column: "ImageKey",
                value: "80Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 7,
                column: "ImageKey",
                value: "100Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 8,
                column: "ImageKey",
                value: "140Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 9,
                column: "ImageKey",
                value: "180Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 10,
                column: "ImageKey",
                value: "250Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 11,
                column: "ImageKey",
                value: "307Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 12,
                column: "ImageKey",
                value: "365Day");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 13,
                column: "ImageKey",
                value: "Register");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 14,
                column: "ImageKey",
                value: "100Points");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 15,
                column: "ImageKey",
                value: "500Points");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 16,
                column: "ImageKey",
                value: "1000Points");

            migrationBuilder.UpdateData(
                table: "Achievements",
                keyColumn: "AchievementId",
                keyValue: 17,
                column: "ImageKey",
                value: "Vasa");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageKey",
                table: "Achievements");
        }
    }
}
