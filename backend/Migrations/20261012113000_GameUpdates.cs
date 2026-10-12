using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class GameUpdates : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_UserId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Games",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "DailyChallanges",
                columns: new[] { "DailyChallangeId", "ChallangeDate", "CityId" },
                values: new object[,]
                {
                    { 1, new DateOnly(2024, 6, 1), 1 },
                    { 2, new DateOnly(2024, 6, 2), 2 },
                    { 3, new DateOnly(2024, 6, 3), 3 },
                    { 4, new DateOnly(2024, 6, 4), 4 },
                    { 5, new DateOnly(2024, 6, 5), 5 },
                    { 6, new DateOnly(2024, 6, 6), 6 },
                    { 7, new DateOnly(2024, 6, 7), 7 },
                    { 8, new DateOnly(2024, 6, 8), 8 },
                    { 9, new DateOnly(2024, 6, 9), 9 },
                    { 10, new DateOnly(2024, 6, 10), 10 }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_AspNetUsers_UserId",
                table: "Games");

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "DailyChallanges",
                keyColumn: "DailyChallangeId",
                keyValue: 10);

            migrationBuilder.AlterColumn<int>(
                name: "UserId",
                table: "Games",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_AspNetUsers_UserId",
                table: "Games",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
