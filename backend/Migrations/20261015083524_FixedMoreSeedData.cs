using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Backend.Migrations
{
    /// <inheritdoc />
    public partial class FixedMoreSeedData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cities",
                columns: new[] { "CityId", "CityPicture", "Name" },
                values: new object[,]
                {
                    { 11, "f9909f24fbcd664a0418738594ec3ef2", "Karlstad" },
                    { 12, "f9909f24fbcd664a0418738594ec3ef2", "Östersund" },
                    { 13, "f9909f24fbcd664a0418738594ec3ef2", "Sundsvall" },
                    { 14, "f9909f24fbcd664a0418738594ec3ef2", "Luleå" },
                    { 15, "f9909f24fbcd664a0418738594ec3ef2", "Kiruna" },
                    { 16, "f9909f24fbcd664a0418738594ec3ef2", "Gävle" },
                    { 17, "f9909f24fbcd664a0418738594ec3ef2", "Falun" },
                    { 18, "f9909f24fbcd664a0418738594ec3ef2", "Borlänge" },
                    { 19, "f9909f24fbcd664a0418738594ec3ef2", "Mora" },
                    { 20, "f9909f24fbcd664a0418738594ec3ef2", "Visby" },
                    { 21, "f9909f24fbcd664a0418738594ec3ef2", "Kalmar" },
                    { 22, "f9909f24fbcd664a0418738594ec3ef2", "Karlskrona" },
                    { 23, "f9909f24fbcd664a0418738594ec3ef2", "Växjö" },
                    { 24, "f9909f24fbcd664a0418738594ec3ef2", "Halmstad" },
                    { 25, "f9909f24fbcd664a0418738594ec3ef2", "Borås" },
                    { 26, "f9909f24fbcd664a0418738594ec3ef2", "Trollhättan" },
                    { 27, "f9909f24fbcd664a0418738594ec3ef2", "Uddevalla" },
                    { 28, "f9909f24fbcd664a0418738594ec3ef2", "Skövde" },
                    { 29, "f9909f24fbcd664a0418738594ec3ef2", "Eskilstuna" },
                    { 30, "f9909f24fbcd664a0418738594ec3ef2", "Nyköping" },
                    { 31, "f9909f24fbcd664a0418738594ec3ef2", "Norrköping" },
                    { 32, "f9909f24fbcd664a0418738594ec3ef2", "Jönköping" },
                    { 33, "f9909f24fbcd664a0418738594ec3ef2", "Kristianstad" },
                    { 34, "f9909f24fbcd664a0418738594ec3ef2", "Ystad" },
                    { 35, "f9909f24fbcd664a0418738594ec3ef2", "Trelleborg" },
                    { 36, "f9909f24fbcd664a0418738594ec3ef2", "Landskrona" },
                    { 37, "f9909f24fbcd664a0418738594ec3ef2", "Varberg" },
                    { 38, "f9909f24fbcd664a0418738594ec3ef2", "Falkenberg" },
                    { 39, "f9909f24fbcd664a0418738594ec3ef2", "Örnsköldsvik" },
                    { 40, "f9909f24fbcd664a0418738594ec3ef2", "Skellefteå" }
                });

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                column: "OptionText",
                value: "Saltön");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                column: "OptionText",
                value: "Pepparholmen");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                column: "OptionText",
                value: "Stenö");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                column: "OptionText",
                value: "Zlatansholme");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "QuestionText",
                value: "Vad heter ön som ansluter Öresundsbron med Malmö?");

            migrationBuilder.InsertData(
                table: "Clues",
                columns: new[] { "ClueId", "CityId", "ClueText", "Point" },
                values: new object[,]
                {
                    { 51, 11, "Vi reser till en stad där en stor älv möter Sveriges största sjö.", 10m },
                    { 52, 11, "Staden ligger i landskapet Värmland.", 8m },
                    { 53, 11, "Här finns Värmlands Museum och stadsdelen Haga.", 6m },
                    { 54, 11, "Klarälven delar sig i flera grenar i staden.", 4m },
                    { 55, 11, "Vi söker Värmlands residensstad vid Vänern.", 2m },
                    { 56, 12, "Vi reser till en stad med närhet till både fjäll och en stor insjö.", 10m },
                    { 57, 12, "Staden grundades år 1786.", 8m },
                    { 58, 12, "Här finns friluftsmuseet Jamtli.", 6m },
                    { 59, 12, "På andra sidan en bro ligger Frösön.", 4m },
                    { 60, 12, "Vi söker Jämtlands residensstad vid Storsjön.", 2m },
                    { 61, 13, "Vi reser till en stad där skogsindustrin har satt tydliga spår.", 10m },
                    { 62, 13, "Efter en stor brand 1888 byggdes centrum upp med många stenhus.", 8m },
                    { 63, 13, "Staden ligger i landskapet Medelpad.", 6m },
                    { 64, 13, "Centrum kallas Stenstan och ligger mellan Norra och Södra berget.", 4m },
                    { 65, 13, "Vi söker staden vid Selångersåns mynning där Birsta ligger i närheten.", 2m },
                    { 66, 14, "Vi reser till en kuststad långt uppe i Sverige.", 10m },
                    { 67, 14, "Här finns ett tekniskt universitet.", 8m },
                    { 68, 14, "Gammelstads kyrkstad i kommunen är ett världsarv.", 6m },
                    { 69, 14, "Staden ligger vid Luleälvens mynning.", 4m },
                    { 70, 14, "Vi söker Norrbottens residensstad.", 2m },
                    { 71, 15, "Vi reser till en stad norr om polcirkeln.", 10m },
                    { 72, 15, "Gruvdriften har gjort att delar av staden har behövt flyttas.", 8m },
                    { 73, 15, "Här bryter LKAB järnmalm.", 6m },
                    { 74, 15, "I närliggande Jukkasjärvi finns ett känt ishotell.", 4m },
                    { 75, 15, "Vi söker gruvstaden vid berget Kiirunavaara.", 2m },
                    { 76, 16, "Vi reser till en kuststad med lång sjöfartshistoria.", 10m },
                    { 77, 16, "Här finns Sveriges Järnvägsmuseum.", 8m },
                    { 78, 16, "Gavleån rinner genom staden.", 6m },
                    { 79, 16, "En stor julbock av halm har blivit stadens välkända symbol.", 4m },
                    { 80, 16, "Vi söker Gästriklands stad som gett namn åt Gävlebocken.", 2m },
                    { 81, 17, "Vi reser till en stad där gruvhistorien präglar både marken och husens färg.", 10m },
                    { 82, 17, "Staden ligger i Dalarna.", 8m },
                    { 83, 17, "Här finns skidområdet Lugnet.", 6m },
                    { 84, 17, "Den stora koppargruvan är en del av ett världsarv.", 4m },
                    { 85, 17, "Vi söker staden som gett namn åt Falu rödfärg.", 2m },
                    { 86, 18, "Vi reser till en stad där järnväg och industri haft stor betydelse.", 10m },
                    { 87, 18, "Staden ligger i Dalarna.", 8m },
                    { 88, 18, "Här finns köpcentrumet Kupolen.", 6m },
                    { 89, 18, "Dalälven rinner genom staden och Romme Alpin ligger i närheten.", 4m },
                    { 90, 18, "Vi söker dalastaden söder om Falun.", 2m },
                    { 91, 19, "Vi reser till en stad där konst och skidåkning möts.", 10m },
                    { 92, 19, "Staden ligger i Dalarna vid Siljan.", 8m },
                    { 93, 19, "Konstnären Anders Zorn bodde här.", 6m },
                    { 94, 19, "Hit går målgången i Vasaloppet.", 4m },
                    { 95, 19, "Vi söker orten där skidåkarna går i mål efter starten i Sälen.", 2m },
                    { 96, 20, "Vi reser till en stad på en ö i Östersjön.", 10m },
                    { 97, 20, "Staden har en stark medeltida prägel.", 8m },
                    { 98, 20, "Här arrangeras Almedalsveckan.", 6m },
                    { 99, 20, "En välbevarad ringmur omger stora delar av den äldre staden.", 4m },
                    { 100, 20, "Vi söker Gotlands största stad.", 2m },
                    { 101, 21, "Vi reser till en kuststad med ett välkänt renässansslott.", 10m },
                    { 102, 21, "En union mellan nordiska riken har fått sitt namn efter staden.", 8m },
                    { 103, 21, "Staden ligger i Småland.", 6m },
                    { 104, 21, "Härifrån går Ölandsbron över Kalmarsund.", 4m },
                    { 105, 21, "Vi söker staden med Kalmar slott.", 2m },
                    { 106, 22, "Vi reser till en stad som anlades som en flottbas.", 10m },
                    { 107, 22, "Staden grundades år 1680.", 8m },
                    { 108, 22, "Örlogsstaden finns på världsarvslistan.", 6m },
                    { 109, 22, "Här finns Marinmuseum på Stumholmen.", 4m },
                    { 110, 22, "Vi söker Blekinges residensstad i skärgården.", 2m },
                    { 111, 23, "Vi reser till en stad omgiven av sjöar och småländska skogar.", 10m },
                    { 112, 23, "Här finns Sveriges glasmuseum.", 8m },
                    { 113, 23, "Staden har en domkyrka med två höga spiror.", 6m },
                    { 114, 23, "Här finns en del av Linnéuniversitetet.", 4m },
                    { 115, 23, "Vi söker Kronobergs läns residensstad.", 2m },
                    { 116, 24, "Vi reser till en kuststad där en å möter havet.", 10m },
                    { 117, 24, "Staden ligger i Halland.", 8m },
                    { 118, 24, "Här finns konstverket Europa och tjuren på Stora torg.", 6m },
                    { 119, 24, "Nissan rinner genom staden och Tylösand ligger i närheten.", 4m },
                    { 120, 24, "Vi söker Hallands residensstad.", 2m },
                    { 121, 25, "Vi reser till en stad som är starkt förknippad med textil och handel.", 10m },
                    { 122, 25, "Staden ligger i Västergötland.", 8m },
                    { 123, 25, "Här finns Textilmuseet och en textilhögskola.", 6m },
                    { 124, 25, "Viskan rinner genom staden, som också har en djurpark.", 4m },
                    { 125, 25, "Vi söker textilstaden öster om Göteborg.", 2m },
                    { 126, 26, "Vi reser till en stad där vattenkraft och industri möts.", 10m },
                    { 127, 26, "Här har Saab tillverkat bilar.", 8m },
                    { 128, 26, "Staden är också känd för filmproduktion.", 6m },
                    { 129, 26, "Göta älv, slussarna och fallen är viktiga delar av stadens historia.", 4m },
                    { 130, 26, "Vi söker staden som gett namn åt Trollhättefallen.", 2m },
                    { 131, 27, "Vi reser till en stad i Bohuslän.", 10m },
                    { 132, 27, "Här finns Bohusläns museum.", 8m },
                    { 133, 27, "Staden ligger vid Byfjorden.", 6m },
                    { 134, 27, "En välkänd bro över fjorden har samma namn som staden.", 4m },
                    { 135, 27, "Vi söker staden med Uddevallabron.", 2m },
                    { 136, 28, "Vi reser till en stad där industri och militär verksamhet har stor betydelse.", 10m },
                    { 137, 28, "Staden ligger i Västergötland.", 8m },
                    { 138, 28, "Här finns en högskola med utbildningar inom bland annat spelutveckling.", 6m },
                    { 139, 28, "Platåberget Billingen ligger intill staden.", 4m },
                    { 140, 28, "Vi söker staden öster om Billingen, mellan Skara och Tibro.", 2m },
                    { 141, 29, "Vi reser till en stad med lång tradition av metallhantverk.", 10m },
                    { 142, 29, "Här finns Rademachersmedjorna.", 8m },
                    { 143, 29, "Staden ligger i Södermanland.", 6m },
                    { 144, 29, "Parken Zoo och Eskilstunaån är välkända inslag.", 4m },
                    { 145, 29, "Vi söker staden som har fått sitt namn efter helgonet Eskil.", 2m },
                    { 146, 30, "Vi reser till en stad där ett medeltida gästabud fick ett dramatiskt slut.", 10m },
                    { 147, 30, "Staden ligger i Södermanland.", 8m },
                    { 148, 30, "Nyköpingsån rinner genom staden.", 6m },
                    { 149, 30, "Här finns slottsruinen Nyköpingshus.", 4m },
                    { 150, 30, "Vi söker staden som gett namn åt Nyköpings gästabud.", 2m },
                    { 151, 31, "Vi reser till en stad vars centrum berättar om textilindustrins historia.", 10m },
                    { 152, 31, "Staden ligger i Östergötland.", 8m },
                    { 153, 31, "Här finns Industrilandskapet och Arbetets museum.", 6m },
                    { 154, 31, "Motala ström rinner genom staden.", 4m },
                    { 155, 31, "Vi söker staden där museibyggnaden Strykjärnet står i strömmen.", 2m },
                    { 156, 32, "Vi reser till en stad där handel och tillverkning har en lång historia.", 10m },
                    { 157, 32, "Här finns Tändsticksmuseet.", 8m },
                    { 158, 32, "Mässområdet Elmia ligger här.", 6m },
                    { 159, 32, "Staden ligger vid Vätterns södra spets.", 4m },
                    { 160, 32, "Vi söker den småländska staden intill Huskvarna.", 2m },
                    { 161, 33, "Vi reser till en stad grundad av en dansk kung.", 10m },
                    { 162, 33, "Staden grundades av Kristian IV år 1614.", 8m },
                    { 163, 33, "Helge å rinner genom staden.", 6m },
                    { 164, 33, "Här finns biosfärområdet Kristianstads Vattenrike.", 4m },
                    { 165, 33, "Vi söker den skånska staden med Heliga Trefaldighets kyrka.", 2m },
                    { 166, 34, "Vi reser till en stad vid Sveriges sydkust.", 10m },
                    { 167, 34, "Staden är känd för sina korsvirkeshus.", 8m },
                    { 168, 34, "Härifrån går färjor till bland annat Bornholm.", 6m },
                    { 169, 34, "Henning Mankells berättelser om Kurt Wallander utspelar sig här.", 4m },
                    { 170, 34, "Vi söker den skånska staden där Wallander arbetar.", 2m },
                    { 171, 35, "Vi reser till en hamnstad på Skånes sydkust.", 10m },
                    { 172, 35, "Staden har färjeförbindelser med kontinenten.", 8m },
                    { 173, 35, "Här finns en rekonstruerad vikingaborg.", 6m },
                    { 174, 35, "Palmer har blivit ett välkänt inslag i stadens sommarbild.", 4m },
                    { 175, 35, "Vi söker Sveriges sydligaste stad.", 2m },
                    { 176, 36, "Vi reser till en stad vid Öresund.", 10m },
                    { 177, 36, "Här finns ett välbevarat citadell omgivet av vallgravar.", 8m },
                    { 178, 36, "Författaren Selma Lagerlöf arbetade som lärare här.", 6m },
                    { 179, 36, "Från staden går båtar till Ven.", 4m },
                    { 180, 36, "Vi söker den skånska staden med Landskrona citadell.", 2m },
                    { 181, 37, "Vi reser till en kuststad med en lång tradition av bad och kurorter.", 10m },
                    { 182, 37, "Staden ligger i Halland.", 8m },
                    { 183, 37, "Här finns ett välkänt kallbadhus.", 6m },
                    { 184, 37, "En stor fästning ligger vid havet och inrymmer Bockstensmannen.", 4m },
                    { 185, 37, "Vi söker den halländska staden med Varbergs fästning.", 2m },
                    { 186, 38, "Vi reser till en kuststad där en gammal stenbro korsar en å.", 10m },
                    { 187, 38, "Staden ligger i Halland.", 8m },
                    { 188, 38, "Den välkända bron heter Tullbron.", 6m },
                    { 189, 38, "Ätran rinner genom staden och Skrea strand ligger i närheten.", 4m },
                    { 190, 38, "Vi söker den halländska staden mellan Varberg och Halmstad.", 2m },
                    { 191, 39, "Vi reser till en kuststad i norra Sverige.", 10m },
                    { 192, 39, "Staden ligger i landskapet Ångermanland.", 8m },
                    { 193, 39, "Här har ishockeyklubben Modo sitt hem.", 6m },
                    { 194, 39, "Staden har fått sitt namn efter landshövdingen Per Abraham Örnsköld.", 4m },
                    { 195, 39, "Vi söker staden som ofta kallas Ö-vik.", 2m },
                    { 196, 40, "Vi reser till en stad där träbyggande och industri möts.", 10m },
                    { 197, 40, "Här finns kyrkstaden Bonnstan.", 8m },
                    { 198, 40, "Sara kulturhus är uppkallat efter författaren Sara Lidman.", 6m },
                    { 199, 40, "Skellefteälven rinner genom staden.", 4m },
                    { 200, 40, "Vi söker den västerbottniska stad som har gett namn åt Skellefteå AIK.", 2m }
                });

            migrationBuilder.InsertData(
                table: "Questions",
                columns: new[] { "QuestionId", "CityId", "QuestionText" },
                values: new object[,]
                {
                    { 21, 11, "Vilken konstnär är huvudpersonen bakom den permanenta samlingen på Sandgrund i Karlstad?" },
                    { 22, 11, "Vilken målningsteknik är särskilt förknippad med samlingen på Sandgrund i Karlstad?" },
                    { 23, 12, "Vilket lag besegrade Östersunds FK i herrfinalen i Svenska cupen 2017?" },
                    { 24, 12, "Med vilket resultat vann Östersunds FK herrfinalen i Svenska cupen 2017?" },
                    { 25, 13, "Under vilken svensk kung grundades Sundsvall?" },
                    { 26, 13, "Vilket år räknas som Sundsvalls grundande?" },
                    { 27, 14, "Vilket år invigdes Kulturens hus i Luleå?" },
                    { 28, 14, "Vilken av dessa verksamheter finns i Kulturens hus i Luleå?" },
                    { 29, 15, "Vad heter forskningsanläggningen nära Kiruna som invigdes 1966?" },
                    { 30, 15, "Vilken typ av raketer har använts vid Esrange för att studera atmosfären?" },
                    { 31, 16, "Vilken protestsångare och facklig aktivist föddes i Gävle 1879?" },
                    { 32, 16, "I vilken amerikansk delstat avrättades den Gävlefödde Joe Hill 1915?" },
                    { 33, 17, "Vilken författare skrev Nils Holgerssons underbara resa genom Sverige under sin tid i Falun?" },
                    { 34, 17, "Vilket Nobelpris fick Selma Lagerlöf, som under en period bodde i Falun?" },
                    { 35, 18, "Vilken internationellt känd operasångare kom från Borlänge?" },
                    { 36, 18, "Vilket röstläge hade den Borlängefödde operasångaren Jussi Björling?" },
                    { 37, 19, "Vad heter sagoparken utanför Mora där besökare kan möta tomtar och troll?" },
                    { 38, 19, "Vad heter området i Tomteland nära Mora där Trollkungen och stortrollen håller till?" },
                    { 39, 20, "Vilket museum i Visby har en utställning som heter Bildstenshallen?" },
                    { 40, 20, "Vilken historisk period är de gotländska bildstenarna särskilt förknippade med?" },
                    { 41, 21, "Vilket regalskepp står i centrum för en stor utställning på Kalmar läns museum?" },
                    { 42, 21, "Vilket år sjönk regalskeppet Kronan, vars fynd visas på Kalmar läns museum?" },
                    { 43, 22, "Vad heter det välkända kolonistugeområdet på en holme vid Dragsö i Karlskrona?" },
                    { 44, 22, "Hur många små röda kolonistugor finns i Brändaholm i Karlskrona?" },
                    { 45, 23, "Vilken Nobelpristagare skrev Dvärgen och föddes i Växjö?" },
                    { 46, 23, "Vilket år fick den Växjöfödde Pär Lagerkvist Nobelpriset i litteratur?" },
                    { 47, 24, "Vilken popgrupp från Halmstad bildades 1978?" },
                    { 48, 24, "Vem är sångare i den Halmstadsförknippade gruppen Gyllene Tider?" },
                    { 49, 25, "Vilken sagofigur föreställer skulpturen Walking to Borås?" },
                    { 50, 25, "Vilken konstnär skapade skulpturen Walking to Borås?" },
                    { 51, 26, "I vilken idrott tog Trollhätteprofilen Nils van der Poel OS-guld 2022?" },
                    { 52, 26, "Hur många OS-guld tog Trollhätteprofilen Nils van der Poel i Peking 2022?" },
                    { 53, 27, "Vad heter den historiska havsbadorten strax söder om Uddevalla?" },
                    { 54, 27, "Vilken typ av skola grundades i Gustafsberg vid Uddevalla 1774?" },
                    { 55, 28, "Vad heter Skövdes science center med experiment för besökare?" },
                    { 56, 28, "Vilka ämnesområden står i centrum på Balthazar Science Center i Skövde?" },
                    { 57, 29, "Vad heter Eskilstunas galleria som är inriktad på återbruk?" },
                    { 58, 29, "Vilket år öppnade återbruksgallerian ReTuna i Eskilstuna?" },
                    { 59, 30, "Vilket varuhus hade egna möbelverkstäder i Nyköping under 1900-talet?" },
                    { 60, 30, "Vilken typ av produkter tillverkades i NK:s verkstäder i Nyköping?" },
                    { 61, 31, "Vilket namn hade föreningen som blev Norrköping Dolphins vid starten?" },
                    { 62, 31, "Vilket år bildades Hageby Basket, föregångaren till Norrköping Dolphins?" },
                    { 63, 32, "Vilka föreningars hockeyverksamheter slogs samman när HV71 bildades?" },
                    { 64, 32, "Vilket år bildades Jönköpingsklubben HV71?" },
                    { 65, 33, "Vilket år bildades idrottsföreningen IFK Kristianstad?" },
                    { 66, 33, "Vilken färg är särskilt förknippad med IFK Kristianstads handbollslag?" },
                    { 67, 34, "Vilken pianist var med och grundade Ystad Sweden Jazz Festival 2010?" },
                    { 68, 34, "Vilket instrument spelar Ystad Sweden Jazz Festivals medgrundare Jan Lundgren?" },
                    { 69, 35, "Vilken konstnär har gett namn åt konsthallen intill stadsparken i Trelleborg?" },
                    { 70, 35, "Vilket år uppfördes Axel Ebbes konsthall i Trelleborg?" },
                    { 71, 36, "Vilket år bildades Landskrona BoIS?" },
                    { 72, 36, "Vilka två föreningar slogs samman när Landskrona BoIS bildades?" },
                    { 73, 37, "Vad heter den historiska radiostationen utanför Varberg?" },
                    { 74, 37, "Vilken anropssignal har den historiska långvågssändaren i Grimeton?" },
                    { 75, 38, "Vem grundade Bryggeri AB Falken i Falkenberg?" },
                    { 76, 38, "Vilket år grundades Bryggeri AB Falken i Falkenberg?" },
                    { 77, 39, "Vem grundade friluftsföretaget Fjällräven i Örnsköldsvik?" },
                    { 78, 39, "Vilket år grundades Fjällräven i Örnsköldsvik?" },
                    { 79, 40, "Vilken uppfinnare grundade Alimak i Skellefteå 1948?" },
                    { 80, 40, "Vilken typ av produkter är Skellefteåföretaget Alimak särskilt känt för?" }
                });

            migrationBuilder.InsertData(
                table: "Options",
                columns: new[] { "OptionId", "IsCorrect", "OptionText", "QuestionId" },
                values: new object[,]
                {
                    { 81, true, "Lars Lerin", 21 },
                    { 82, false, "Anders Zorn", 21 },
                    { 83, false, "Carl Larsson", 21 },
                    { 84, false, "Bruno Liljefors", 21 },
                    { 85, false, "Glasmåleri", 22 },
                    { 86, true, "Akvarell", 22 },
                    { 87, false, "Freskomåleri", 22 },
                    { 88, false, "Enkaustik", 22 },
                    { 89, false, "Malmö FF", 23 },
                    { 90, false, "IFK Göteborg", 23 },
                    { 91, true, "IFK Norrköping", 23 },
                    { 92, false, "AIK", 23 },
                    { 93, false, "1–0", 24 },
                    { 94, false, "2–1", 24 },
                    { 95, false, "3–2", 24 },
                    { 96, true, "4–1", 24 },
                    { 97, true, "Gustav II Adolf", 25 },
                    { 98, false, "Gustav Vasa", 25 },
                    { 99, false, "Karl XII", 25 },
                    { 100, false, "Gustav III", 25 },
                    { 101, false, "1786", 26 },
                    { 102, true, "1621", 26 },
                    { 103, false, "1523", 26 },
                    { 104, false, "1680", 26 },
                    { 105, false, "1997", 27 },
                    { 106, false, "2017", 27 },
                    { 107, true, "2007", 27 },
                    { 108, false, "1987", 27 },
                    { 109, false, "Tingsrätt", 28 },
                    { 110, false, "Akutmottagning", 28 },
                    { 111, false, "Simhall", 28 },
                    { 112, true, "Stadsbibliotek", 28 },
                    { 113, true, "Esrange", 29 },
                    { 114, false, "MAX IV", 29 },
                    { 115, false, "Onsala rymdobservatorium", 29 },
                    { 116, false, "SciLifeLab", 29 },
                    { 117, false, "Nödraketer", 30 },
                    { 118, true, "Sondraketer", 30 },
                    { 119, false, "Signalraketer", 30 },
                    { 120, false, "Fyrverkeriraketer", 30 },
                    { 121, false, "Pete Seeger", 31 },
                    { 122, false, "Bob Dylan", 31 },
                    { 123, true, "Joe Hill", 31 },
                    { 124, false, "Woody Guthrie", 31 },
                    { 125, false, "Texas", 32 },
                    { 126, false, "Kalifornien", 32 },
                    { 127, false, "Florida", 32 },
                    { 128, true, "Utah", 32 },
                    { 129, true, "Selma Lagerlöf", 33 },
                    { 130, false, "Astrid Lindgren", 33 },
                    { 131, false, "Elsa Beskow", 33 },
                    { 132, false, "Karin Boye", 33 },
                    { 133, false, "Kemi", 34 },
                    { 134, true, "Litteratur", 34 },
                    { 135, false, "Fred", 34 },
                    { 136, false, "Fysik", 34 },
                    { 137, false, "Nicolai Gedda", 35 },
                    { 138, false, "Peter Mattei", 35 },
                    { 139, true, "Jussi Björling", 35 },
                    { 140, false, "Birgit Nilsson", 35 },
                    { 141, false, "Bas", 36 },
                    { 142, false, "Baryton", 36 },
                    { 143, false, "Kontratenor", 36 },
                    { 144, true, "Tenor", 36 },
                    { 145, true, "Tomteland", 37 },
                    { 146, false, "Astrid Lindgrens Värld", 37 },
                    { 147, false, "High Chaparral", 37 },
                    { 148, false, "Sagostigen", 37 },
                    { 149, false, "Älvornas rike", 38 },
                    { 150, true, "Trollrike", 38 },
                    { 151, false, "Drakland", 38 },
                    { 152, false, "Skogstomtebyn", 38 },
                    { 153, false, "Historiska museet", 39 },
                    { 154, false, "Bohusläns museum", 39 },
                    { 155, true, "Gotlands Museum", 39 },
                    { 156, false, "Nordiska museet", 39 },
                    { 157, false, "Bronsåldern", 40 },
                    { 158, false, "Renässansen", 40 },
                    { 159, false, "Industrialiseringen", 40 },
                    { 160, true, "Järnåldern", 40 },
                    { 161, true, "Kronan", 41 },
                    { 162, false, "Vasa", 41 },
                    { 163, false, "Äpplet", 41 },
                    { 164, false, "Riksäpplet", 41 },
                    { 165, false, "1809", 42 },
                    { 166, true, "1676", 42 },
                    { 167, false, "1628", 42 },
                    { 168, false, "1718", 42 },
                    { 169, false, "Slottsskogen", 43 },
                    { 170, false, "Pildammsparken", 43 },
                    { 171, true, "Brändaholm", 43 },
                    { 172, false, "Tantolunden", 43 },
                    { 173, false, "15", 44 },
                    { 174, false, "75", 44 },
                    { 175, false, "105", 44 },
                    { 176, true, "45", 44 },
                    { 177, true, "Pär Lagerkvist", 45 },
                    { 178, false, "Tomas Tranströmer", 45 },
                    { 179, false, "Harry Martinson", 45 },
                    { 180, false, "Eyvind Johnson", 45 },
                    { 181, false, "1974", 46 },
                    { 182, true, "1951", 46 },
                    { 183, false, "1909", 46 },
                    { 184, false, "1931", 46 },
                    { 185, false, "Europe", 47 },
                    { 186, false, "The Cardigans", 47 },
                    { 187, true, "Gyllene Tider", 47 },
                    { 188, false, "ABBA", 47 },
                    { 189, false, "Joey Tempest", 48 },
                    { 190, false, "Magnus Uggla", 48 },
                    { 191, false, "Tomas Ledin", 48 },
                    { 192, true, "Per Gessle", 48 },
                    { 193, true, "Pinocchio", 49 },
                    { 194, false, "Peter Pan", 49 },
                    { 195, false, "Nalle Puh", 49 },
                    { 196, false, "Pippi Långstrump", 49 },
                    { 197, false, "Niki de Saint Phalle", 50 },
                    { 198, true, "Jim Dine", 50 },
                    { 199, false, "Carl Milles", 50 },
                    { 200, false, "Claes Oldenburg", 50 },
                    { 201, false, "Skidskytte", 51 },
                    { 202, false, "Längdskidåkning", 51 },
                    { 203, true, "Hastighetsåkning på skridskor", 51 },
                    { 204, false, "Konståkning", 51 },
                    { 205, false, "Ett", 52 },
                    { 206, false, "Tre", 52 },
                    { 207, false, "Fyra", 52 },
                    { 208, true, "Två", 52 },
                    { 209, true, "Gustafsberg", 53 },
                    { 210, false, "Marstrand", 53 },
                    { 211, false, "Lysekil", 53 },
                    { 212, false, "Fiskebäckskil", 53 },
                    { 213, false, "Universitet", 54 },
                    { 214, true, "Internatskola", 54 },
                    { 215, false, "Folkhögskola", 54 },
                    { 216, false, "Yrkeshögskola", 54 },
                    { 217, false, "Universeum", 55 },
                    { 218, false, "Teknikens Hus", 55 },
                    { 219, true, "Balthazar", 55 },
                    { 220, false, "Tom Tits Experiment", 55 },
                    { 221, false, "Juridik och ekonomi", 56 },
                    { 222, false, "Militärhistoria och heraldik", 56 },
                    { 223, false, "Arkeologi och antika språk", 56 },
                    { 224, true, "Naturvetenskap och teknik", 56 },
                    { 225, true, "ReTuna", 57 },
                    { 226, false, "Emporia", 57 },
                    { 227, false, "Nordstan", 57 },
                    { 228, false, "Kupolen", 57 },
                    { 229, false, "2020", 58 },
                    { 230, true, "2015", 58 },
                    { 231, false, "1995", 58 },
                    { 232, false, "2005", 58 },
                    { 233, false, "PUB", 59 },
                    { 234, false, "Gekås", 59 },
                    { 235, true, "Nordiska Kompaniet", 59 },
                    { 236, false, "Åhléns", 59 },
                    { 237, false, "Järnvägslok", 60 },
                    { 238, false, "Glasflaskor", 60 },
                    { 239, false, "Musikinstrument", 60 },
                    { 240, true, "Möbler och inredningar", 60 },
                    { 241, true, "Hageby Basket", 61 },
                    { 242, false, "Södertälje Kings", 61 },
                    { 243, false, "Solna Vikings", 61 },
                    { 244, false, "Alvik Basket", 61 },
                    { 245, false, "1983", 62 },
                    { 246, true, "1963", 62 },
                    { 247, false, "1913", 62 },
                    { 248, false, "1943", 62 },
                    { 249, false, "Nässjö IF och Tranås AIF", 63 },
                    { 250, false, "Skillingaryds IS och Värnamo GIK", 63 },
                    { 251, true, "Husqvarna IF och Vätterstads IF", 63 },
                    { 252, false, "IFK Jönköping och Jönköpings Södra", 63 },
                    { 253, false, "1951", 64 },
                    { 254, false, "1961", 64 },
                    { 255, false, "1981", 64 },
                    { 256, true, "1971", 64 },
                    { 257, true, "1899", 65 },
                    { 258, false, "1919", 65 },
                    { 259, false, "1939", 65 },
                    { 260, false, "1959", 65 },
                    { 261, false, "Gul", 66 },
                    { 262, true, "Orange", 66 },
                    { 263, false, "Lila", 66 },
                    { 264, false, "Grön", 66 },
                    { 265, false, "Esbjörn Svensson", 67 },
                    { 266, false, "Bengt Hallberg", 67 },
                    { 267, true, "Jan Lundgren", 67 },
                    { 268, false, "Jan Johansson", 67 },
                    { 269, false, "Trumpet", 68 },
                    { 270, false, "Saxofon", 68 },
                    { 271, false, "Trummor", 68 },
                    { 272, true, "Piano", 68 },
                    { 273, true, "Axel Ebbe", 69 },
                    { 274, false, "Carl Larsson", 69 },
                    { 275, false, "Anders Zorn", 69 },
                    { 276, false, "Isaac Grünewald", 69 },
                    { 277, false, "1985", 70 },
                    { 278, true, "1935", 70 },
                    { 279, false, "1835", 70 },
                    { 280, false, "1885", 70 },
                    { 281, false, "1935", 71 },
                    { 282, false, "1955", 71 },
                    { 283, true, "1915", 71 },
                    { 284, false, "1895", 71 },
                    { 285, false, "Landskrona IF och Olympia", 72 },
                    { 286, false, "Ven IF och BK Fram", 72 },
                    { 287, false, "Helsingborgs IF och Råå IF", 72 },
                    { 288, true, "IFK Landskrona och Diana", 72 },
                    { 289, true, "Grimeton", 73 },
                    { 290, false, "Esrange", 73 },
                    { 291, false, "Onsala", 73 },
                    { 292, false, "Motala", 73 },
                    { 293, false, "SR", 74 },
                    { 294, true, "SAQ", 74 },
                    { 295, false, "SOS", 74 },
                    { 296, false, "SVT", 74 },
                    { 297, false, "Alfred Nobel", 75 },
                    { 298, false, "Gustaf Dalén", 75 },
                    { 299, true, "John L. Skantze", 75 },
                    { 300, false, "Lars Olsson Smith", 75 },
                    { 301, false, "1796", 76 },
                    { 302, false, "1846", 76 },
                    { 303, false, "1946", 76 },
                    { 304, true, "1896", 76 },
                    { 305, true, "Åke Nordin", 77 },
                    { 306, false, "Ingvar Kamprad", 77 },
                    { 307, false, "Erling Persson", 77 },
                    { 308, false, "Bertil Hult", 77 },
                    { 309, false, "1980", 78 },
                    { 310, true, "1960", 78 },
                    { 311, false, "1920", 78 },
                    { 312, false, "1940", 78 },
                    { 313, false, "Alfred Nobel", 79 },
                    { 314, false, "Johan Petter Johansson", 79 },
                    { 315, true, "Alvar Lindmark", 79 },
                    { 316, false, "Gustaf Dalén", 79 },
                    { 317, false, "Personbilar", 80 },
                    { 318, false, "Mobiltelefoner", 80 },
                    { 319, false, "Pappersmassa", 80 },
                    { 320, true, "Industrihissar och bygghissar", 80 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Clues",
                keyColumn: "ClueId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 81);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 82);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 83);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 84);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 85);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 86);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 87);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 88);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 89);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 90);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 91);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 92);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 93);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 94);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 95);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 96);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 97);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 98);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 99);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 100);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 101);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 102);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 103);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 104);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 105);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 106);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 107);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 108);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 109);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 110);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 111);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 112);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 113);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 114);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 115);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 116);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 117);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 118);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 119);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 120);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 121);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 122);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 123);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 124);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 125);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 126);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 127);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 128);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 129);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 130);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 131);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 132);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 133);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 134);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 135);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 136);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 137);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 138);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 139);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 140);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 141);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 142);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 143);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 144);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 145);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 146);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 147);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 148);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 149);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 150);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 151);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 152);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 153);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 154);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 155);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 156);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 157);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 158);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 159);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 160);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 161);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 162);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 163);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 164);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 165);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 166);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 167);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 168);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 169);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 170);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 171);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 172);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 173);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 174);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 175);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 176);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 177);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 178);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 179);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 180);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 181);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 182);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 183);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 184);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 185);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 186);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 187);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 188);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 189);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 190);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 191);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 192);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 193);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 194);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 195);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 196);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 197);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 198);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 199);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 200);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 201);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 202);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 203);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 204);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 205);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 206);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 207);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 208);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 209);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 210);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 211);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 212);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 213);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 214);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 215);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 216);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 217);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 218);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 219);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 220);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 221);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 222);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 223);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 224);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 225);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 226);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 227);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 228);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 229);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 230);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 231);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 232);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 233);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 234);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 235);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 236);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 237);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 238);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 239);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 240);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 241);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 242);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 243);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 244);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 245);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 246);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 247);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 248);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 249);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 250);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 251);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 252);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 253);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 254);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 255);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 256);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 257);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 258);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 259);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 260);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 261);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 262);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 263);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 264);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 265);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 266);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 267);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 268);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 269);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 270);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 271);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 272);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 273);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 274);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 275);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 276);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 277);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 278);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 279);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 280);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 281);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 282);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 283);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 284);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 285);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 286);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 287);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 288);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 289);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 290);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 291);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 292);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 293);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 294);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 295);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 296);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 297);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 298);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 299);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 300);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 301);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 302);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 303);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 304);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 305);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 306);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 307);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 308);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 309);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 310);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 311);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 312);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 313);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 314);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 315);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 316);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 317);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 318);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 319);

            migrationBuilder.DeleteData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 320);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 66);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 67);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 68);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 69);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 70);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 71);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 72);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 73);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 74);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 75);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 76);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 77);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 78);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 79);

            migrationBuilder.DeleteData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 80);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Cities",
                keyColumn: "CityId",
                keyValue: 40);

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 21,
                column: "OptionText",
                value: "Århus");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 22,
                column: "OptionText",
                value: "Köpenhamn");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 23,
                column: "OptionText",
                value: "Odense");

            migrationBuilder.UpdateData(
                table: "Options",
                keyColumn: "OptionId",
                keyValue: 24,
                column: "OptionText",
                value: "Ålborg");

            migrationBuilder.UpdateData(
                table: "Questions",
                keyColumn: "QuestionId",
                keyValue: 6,
                column: "QuestionText",
                value: "Vilken dansk stad förbinder Öresundsbron Malmö med?");
        }
    }
}
