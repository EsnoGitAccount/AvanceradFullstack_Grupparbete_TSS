using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class AddData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "Name" },
                values: new object[,]
                {
                    { 1, "Stockholm" },
                    { 2, "Göteborg" },
                    { 3, "Malmö" },
                    { 4, "Uppsala" },
                    { 5, "Västerås" },
                    { 6, "Örebro" },
                    { 7, "Linköping" },
                    { 8, "Helsingborg" },
                    { 9, "Umeå" },
                    { 10, "Lund" }
                });

            migrationBuilder.InsertData(
                table: "Clues",
                columns: new[] { "ClueId", "CityId", "ClueName", "Point" },
                values: new object[,]
                {
                    { 1, 1, "Vi reser till en stad mellan en stor insjö och Östersjön.", 10m },
                    { 2, 1, "Här finns en kunglig bostad och byggnaden där Nobelbanketten hålls.", 8m },
                    { 3, 1, "Ett välbevarat krigsskepp från 1600-talet finns på ett museum här.", 6m },
                    { 4, 1, "Gamla stan och Djurgården är välkända delar av staden.", 4m },
                    { 5, 1, "Vi söker Sveriges huvudstad.", 2m },
                    { 6, 2, "Vi reser till en stad vid västkusten med en lång sjöfartshistoria.", 10m },
                    { 7, 2, "Staden grundades av Gustav II Adolf år 1621.", 8m },
                    { 8, 2, "Här finns Avenyn och Feskekörka.", 6m },
                    { 9, 2, "Nöjesparken Liseberg ligger här.", 4m },
                    { 10, 2, "Vi söker Sveriges näst största stad, vid Göta älvs mynning.", 2m },
                    { 11, 3, "Vi reser till en stad i ett landskap som länge tillhörde Danmark.", 10m },
                    { 12, 3, "Här finns både ett gammalt slott och en vriden skyskrapa.", 8m },
                    { 13, 3, "Staden har en broförbindelse över Öresund till Danmark.", 6m },
                    { 14, 3, "Här finns Turning Torso och Västra Hamnen.", 4m },
                    { 15, 3, "Vi söker Skånes största stad.", 2m },
                    { 16, 4, "Vi reser till en stad där vetenskap och kyrkohistoria möts.", 10m },
                    { 17, 4, "Carl von Linné bodde och arbetade här.", 8m },
                    { 18, 4, "Stadens universitet grundades år 1477.", 6m },
                    { 19, 4, "Fyrisån rinner genom staden, som har en stor domkyrka.", 4m },
                    { 20, 4, "Vi söker universitetsstaden norr om Stockholm med Gamla Uppsala i närheten.", 2m },
                    { 21, 5, "Vi reser till en stad där industrihistoria möter en stor insjö.", 10m },
                    { 22, 5, "Staden har en lång historia inom svensk elektroteknisk industri.", 8m },
                    { 23, 5, "Här finns gravhögen Anundshög.", 6m },
                    { 24, 5, "Staden ligger vid Mälaren och har gett namn åt Västeråsgurkan.", 4m },
                    { 25, 5, "Vi söker staden som ofta kallas Gurkstaden.", 2m },
                    { 26, 6, "Vår resa går till en stad i landskapet Närke.", 10m },
                    { 27, 6, "Här finns ett välkänt vattentorn som också är ett besöksmål.", 8m },
                    { 28, 6, "Svartån rinner genom stadens centrum.", 6m },
                    { 29, 6, "Mitt i staden ligger ett slott på en ö, och vattentornet kallas Svampen.", 4m },
                    { 30, 6, "Vi söker staden med Örebro slott.", 2m },
                    { 31, 7, "Vi reser till en stad där flyghistoria och universitetsliv möts.", 10m },
                    { 32, 7, "Staden ligger i Östergötland.", 8m },
                    { 33, 7, "I närliggande Malmslätt finns Flygvapenmuseum.", 6m },
                    { 34, 7, "Här finns friluftsmuseet Gamla Linköping och Stångån.", 4m },
                    { 35, 7, "Vi söker staden som förknippas med Saab och flygplanet Gripen.", 2m },
                    { 36, 8, "Vi reser till en stad där avståndet till Danmark är kort.", 10m },
                    { 37, 8, "Här finns slottet Sofiero med sina trädgårdar.", 8m },
                    { 38, 8, "Från staden går färjor till Helsingör.", 6m },
                    { 39, 8, "Det medeltida tornet Kärnan blickar ut över Öresund.", 4m },
                    { 40, 8, "Vi söker den skånska staden mitt emot Helsingör.", 2m },
                    { 41, 9, "Vi reser till en stad i norra Sverige med ett rikt kulturliv.", 10m },
                    { 42, 9, "Efter en stor brand 1888 planterades många träd här.", 8m },
                    { 43, 9, "Staden var Europas kulturhuvudstad år 2014.", 6m },
                    { 44, 9, "Umeälven rinner genom staden, som kallas Björkarnas stad.", 4m },
                    { 45, 9, "Vi söker universitetsstaden Umeå.", 2m },
                    { 46, 10, "Vi reser till en skånsk stad med en lång akademisk historia.", 10m },
                    { 47, 10, "Universitetet här grundades år 1666.", 8m },
                    { 48, 10, "Staden har en medeltida domkyrka med ett astronomiskt ur.", 6m },
                    { 49, 10, "Här finns friluftsmuseet Kulturen och studenternas nationsliv.", 4m },
                    { 50, 10, "Vi söker universitetsstaden Lund, nära Malmö.", 2m }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "CityId", "QuestionText" },
                values: new object[,]
                {
                    { 1, 1, "Vad heter museet som visar krigsskeppet Vasa?" },
                    { 2, 1, "Vilken sjö ligger väster om Stockholm?" },
                    { 3, 2, "Vilken nöjespark ligger i Göteborg?" },
                    { 4, 2, "Vilken älv rinner genom Göteborg?" },
                    { 5, 3, "Vad heter den vridna skyskrapan i Malmö?" },
                    { 6, 3, "Vilken dansk stad förbinder Öresundsbron Malmö med?" },
                    { 7, 4, "Vilken å rinner genom Uppsala?" },
                    { 8, 4, "Vilken botaniker förknippas med Uppsala?" },
                    { 9, 5, "Vid vilken sjö ligger Västerås?" },
                    { 10, 5, "Vad heter den stora gravhögen i Västerås?" },
                    { 11, 6, "Vad kallas det välkända vattentornet i Örebro?" },
                    { 12, 6, "I vilket landskap ligger Örebro?" },
                    { 13, 7, "Vilken å rinner genom Linköping?" },
                    { 14, 7, "Vilket museum ligger i Malmslätt nära Linköping?" },
                    { 15, 8, "Vad heter det medeltida tornet i Helsingborg?" },
                    { 16, 8, "Till vilken dansk stad går färjorna från Helsingborg?" },
                    { 17, 9, "Vilket smeknamn har Umeå?" },
                    { 18, 9, "Vilken älv rinner genom Umeå?" },
                    { 19, 10, "Vilket år grundades Lunds universitet?" },
                    { 20, 10, "Vad heter friluftsmuseet i Lund?" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "IsCorrect", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 1, true, "Vasamuseet", 1 },
                    { 2, false, "Sjöhistoriska museet", 1 },
                    { 3, false, "Nordiska museet", 1 },
                    { 4, false, "Tekniska museet", 1 },
                    { 5, false, "Vättern", 2 },
                    { 6, true, "Mälaren", 2 },
                    { 7, false, "Vänern", 2 },
                    { 8, false, "Siljan", 2 },
                    { 9, false, "Gröna Lund", 3 },
                    { 10, false, "Furuvik", 3 },
                    { 11, true, "Liseberg", 3 },
                    { 12, false, "Skara Sommarland", 3 },
                    { 13, false, "Dalälven", 4 },
                    { 14, false, "Umeälven", 4 },
                    { 15, false, "Torne älv", 4 },
                    { 16, true, "Göta älv", 4 },
                    { 17, true, "Turning Torso", 5 },
                    { 18, false, "Kaknästornet", 5 },
                    { 19, false, "Karlatornet", 5 },
                    { 20, false, "Kista Science Tower", 5 },
                    { 21, false, "Århus", 6 },
                    { 22, true, "Köpenhamn", 6 },
                    { 23, false, "Odense", 6 },
                    { 24, false, "Ålborg", 6 },
                    { 25, false, "Svartån", 7 },
                    { 26, false, "Stångån", 7 },
                    { 27, true, "Fyrisån", 7 },
                    { 28, false, "Motala ström", 7 },
                    { 29, false, "Alfred Nobel", 8 },
                    { 30, false, "Anders Celsius", 8 },
                    { 31, false, "Gustaf Dalén", 8 },
                    { 32, true, "Carl von Linné", 8 },
                    { 33, true, "Mälaren", 9 },
                    { 34, false, "Vänern", 9 },
                    { 35, false, "Vättern", 9 },
                    { 36, false, "Hjälmaren", 9 },
                    { 37, false, "Hågahögen", 10 },
                    { 38, true, "Anundshög", 10 },
                    { 39, false, "Inglingehög", 10 },
                    { 40, false, "Kung Björns hög", 10 },
                    { 41, false, "Kronan", 11 },
                    { 42, false, "Koppen", 11 },
                    { 43, true, "Svampen", 11 },
                    { 44, false, "Fyren", 11 },
                    { 45, false, "Dalarna", 12 },
                    { 46, false, "Bohuslän", 12 },
                    { 47, false, "Blekinge", 12 },
                    { 48, true, "Närke", 12 },
                    { 49, true, "Stångån", 13 },
                    { 50, false, "Fyrisån", 13 },
                    { 51, false, "Rönne å", 13 },
                    { 52, false, "Nissan", 13 },
                    { 53, false, "Vasamuseet", 14 },
                    { 54, true, "Flygvapenmuseum", 14 },
                    { 55, false, "Järnvägsmuseet", 14 },
                    { 56, false, "Marinmuseum", 14 },
                    { 57, false, "Kaknästornet", 15 },
                    { 58, false, "Svampen", 15 },
                    { 59, true, "Kärnan", 15 },
                    { 60, false, "Jungfrutornet", 15 },
                    { 61, false, "Köpenhamn", 16 },
                    { 62, false, "Århus", 16 },
                    { 63, false, "Odense", 16 },
                    { 64, true, "Helsingör", 16 },
                    { 65, true, "Björkarnas stad", 17 },
                    { 66, false, "Gurkstaden", 17 },
                    { 67, false, "Solstaden", 17 },
                    { 68, false, "Lilla London", 17 },
                    { 69, false, "Luleälven", 18 },
                    { 70, true, "Umeälven", 18 },
                    { 71, false, "Dalälven", 18 },
                    { 72, false, "Göta älv", 18 },
                    { 73, false, "1477", 19 },
                    { 74, false, "1621", 19 },
                    { 75, true, "1666", 19 },
                    { 76, false, "1810", 19 },
                    { 77, false, "Skansen", 20 },
                    { 78, false, "Gamla Linköping", 20 },
                    { 79, false, "Wadköping", 20 },
                    { 80, true, "Kulturen", 20 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 10);
        }
    }
}
