using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class Achievemnts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CurrentStreak",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LongestStreak",
                table: "AspNetUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "TotalScore",
                table: "AspNetUsers",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "Achievement",
                columns: table => new
                {
                    AchievementId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achievement", x => x.AchievementId);
                    table.ForeignKey(
                        name: "FK_Achievement_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Achievement",
                columns: new[] { "AchievementId", "Description", "Name", "UserId" },
                values: new object[,]
                {
                    { 1, "Uppnå en streak av minst 3 dagar.", "Nyfiken resenär", null },
                    { 2, "Uppnå en streak av minst 7 dagar.", "Veckopendlare", null },
                    { 3, "Uppnå en streak av minst 14 dagar.", "Stadsälskare", null },
                    { 4, "uppnå en streak av minst 31 dagar.", "Månadskort", null },
                    { 5, "Uppnå en streak av minst 50 dagar.", "Rutinerad resenär", null },
                    { 6, "Uppnå en streak av minst 80 dagar.", "Sverige runt på 80 dagar", null },
                    { 7, "Uppnå en streak av minst 100 dagar.", "100% resglädje", null },
                    { 8, "Uppnå en streak av minst 140 dagar.", "Lokföraraspirant", null },
                    { 9, "Uppnå en streak av minst 180 dagar.", "Halvårskort", null },
                    { 10, "Uppnå en streak av minst 250 dagar.", "Går som tåget", null },
                    { 11, "Uppnå en streak av minst 365 dagar.", "Årskort", null },
                    { 13, "Registrera ett konto.", "Biljettkontroll", null },
                    { 14, "Tjäna minst 100 poäng totalt.", "Resvana 1", null },
                    { 15, "Tjäna minst 500 poäng totalt.", "Resvana 2", null },
                    { 16, "Tjäna minst 1000 poäng totalt.", "ResVasa 3", null },
                    { 17, "Besök Mora", "Mora Träsk och Vasaloppet", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achievement_UserId",
                table: "Achievement",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achievement");

            migrationBuilder.DropColumn(
                name: "CurrentStreak",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LongestStreak",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "AspNetUsers");
        }
    }
}
