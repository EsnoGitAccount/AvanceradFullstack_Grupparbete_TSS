using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCityModelAndBlob : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "ClueName",
                table: "Clues",
                newName: "ClueText");

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Questions",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuestionId1",
                table: "Options",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CityId1",
                table: "Clues",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityPicture",
                table: "Cities",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10,
                column: "CityPicture",
                value: "f9909f24fbcd664a0418738594ec3ef2");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 1,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 2,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 3,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 4,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 5,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 6,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 7,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 8,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 9,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 10,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 11,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 12,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 13,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 14,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 15,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 16,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 17,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 18,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 19,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 20,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 21,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Här finns både gravhögen Anundshög och det obskyra lilla Utter Inn." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 22,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 23,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "I staden ligger Erik XIV begravd, i en för kort sarkofag, varför hans fötter fick huggas av." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 24,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Staden har en vänskaplig rivalitet med Örebro." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 25,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Vi söker staden som ofta kallas Gurkstaden." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 26,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Vår resa går till en stad i landskapet Närke." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 27,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 28,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 29,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Mitt i staden ligger ett slott på en ö" });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 30,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 31,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 32,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 33,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 34,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 35,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 36,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 37,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 38,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 39,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 40,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Staden kallas ibland för ''Sundets Pärla''." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 41,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Vi reser till en stad i norra Sverige, ibland kallad ''Norra Sveriges Huvudstad''." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 42,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 43,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 44,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 45,
                columns: new[] { "CityId1", "ClueText" },
                values: new object[] { null, "Staden kallas ibland för ''Nordens Kulturhuvudstad''." });

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 46,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 47,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 48,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 49,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 50,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 1,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 2,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 4,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 5,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 6,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 7,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 26,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 27,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 28,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 29,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 30,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 31,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 32,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 33,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 34,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 35,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 36,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 37,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 38,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 39,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 40,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 41,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 42,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 43,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 44,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 45,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 46,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 47,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 48,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 49,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 50,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 51,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 52,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 53,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 54,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 55,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 56,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 57,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 58,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 59,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 60,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 61,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 62,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 63,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 64,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 65,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 66,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 67,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 68,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 69,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 70,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 71,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 72,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 73,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 74,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 75,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 76,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 77,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 78,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 79,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 80,
                column: "QuestionId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 7,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 8,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 9,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 10,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 11,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 12,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 13,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 14,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 15,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 16,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 17,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 18,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 19,
                column: "CityId1",
                value: null);

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 20,
                column: "CityId1",
                value: null);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_CityId1",
                table: "Questions",
                column: "CityId1");

            migrationBuilder.CreateIndex(
                name: "IX_Options_QuestionId1",
                table: "Options",
                column: "QuestionId1");

            migrationBuilder.CreateIndex(
                name: "IX_Clues_CityId1",
                table: "Clues",
                column: "CityId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Clues_Cities_CityId1",
                table: "Clues",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Options_Questions_QuestionId1",
                table: "Options",
                column: "QuestionId1",
                principalTable: "Questions",
                principalColumn: "QuestionId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Cities_CityId1",
                table: "Questions",
                column: "CityId1",
                principalTable: "Cities",
                principalColumn: "CityId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Clues_Cities_CityId1",
                table: "Clues");

            migrationBuilder.DropForeignKey(
                name: "FK_Options_Questions_QuestionId1",
                table: "Options");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Cities_CityId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_CityId1",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Options_QuestionId1",
                table: "Options");

            migrationBuilder.DropIndex(
                name: "IX_Clues_CityId1",
                table: "Clues");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionId1",
                table: "Options");

            migrationBuilder.DropColumn(
                name: "CityId1",
                table: "Clues");

            migrationBuilder.DropColumn(
                name: "CityPicture",
                table: "Cities");

            migrationBuilder.RenameColumn(
                name: "ClueText",
                table: "Clues",
                newName: "ClueName");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 21,
                column: "ClueName",
                value: "Här finns både gravhögen Anundshög och det obskyra lilla Utter Inn");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 23,
                column: "ClueName",
                value: "I staden ligger Erik XIV begravd, i en för kort sarkofag, varför hans fötter fick huggas av");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 24,
                column: "ClueName",
                value: "Staden har en vänskaplig rivalitet med Örebro");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 25,
                column: "ClueName",
                value: "Vi söker staden som ofta kallas Gurkstaden, eller pulverstaden.");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 26,
                column: "ClueName",
                value: "Vår resa går till en stad mitt i det så kallade gnällbätet.");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 29,
                column: "ClueName",
                value: "Mitt i staden ligger ett slott på en ö.");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 40,
                column: "ClueName",
                value: "Staden kallas ibland för ''Sundets Pärla''");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 41,
                column: "ClueName",
                value: "Vi reser till en stad i norra Sverige, iblan kallad ''Norra Sveriges Huvudstad''.");

            migrationBuilder.UpdateData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 45,
                column: "ClueName",
                value: "Staden kallas ibland för ''Nordens Kulturhuvudstad''");

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
        }
    }
}
