using Backend.Model;
using Microsoft.EntityFrameworkCore;

namespace Backend.Data
{
    public static class DatabaseSeed
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            // STÄDER

            modelBuilder.Entity<City>().HasData(
                new City { CityId = 1, Name = "Stockholm", CityPicture = "41129676e3fb41ae9f287989c6904000" },
                new City { CityId = 2, Name = "Göteborg", CityPicture = "3b6542dbf1804eee8f520f46184d87e1" },
                new City { CityId = 3, Name = "Malmö", CityPicture = "7212fad885c543a5a0af470f7b78dd3e" },
                new City { CityId = 4, Name = "Uppsala", CityPicture = "1c48e9c49fc3400faf75c46913027233" },
                new City { CityId = 5, Name = "Västerås", CityPicture = "a6f7bb4bb7e7441d8c52bdb470d3a1b2" },
                new City { CityId = 6, Name = "Örebro", CityPicture = "e54618d05ef54921b854f73084da9849" },
                new City { CityId = 7, Name = "Linköping", CityPicture = "91ccf98d23fa4cdea0d068436ab53fb2" },
                new City { CityId = 8, Name = "Helsingborg", CityPicture = "07c12c24dbe44af0871863e52d76b97a" },
                new City { CityId = 9, Name = "Umeå", CityPicture = "9bba3fbbc73c49998de534f2c9191505" },
                new City { CityId = 10, Name = "Lund", CityPicture = "1e1ecf1082394d5e91b59c5ca38dcb4b" }
            );


            // FRÅGOR: TVÅ PER STAD

            modelBuilder.Entity<Question>().HasData(
                new Question
                {
                    QuestionId = 1,
                    CityId = 1,
                    QuestionText = "Vad heter museet som visar upp ett gammalt krigsskepp, namgett efter en känd Svensk kung"
                },
                new Question
                {
                    QuestionId = 2,
                    CityId = 1,
                    QuestionText = "Vilken sjö ligger väster om Stockholm?"
                },
                new Question
                {
                    QuestionId = 3,
                    CityId = 2,
                    QuestionText = "Vad heter alla i Göteborg, enligt den humoristiska sången?"
                },
                new Question
                {
                    QuestionId = 4,
                    CityId = 2,
                    QuestionText = "Vad kallas det ikoniska rödvita höghuset i Göteborg?"
                },
                new Question
                {
                    QuestionId = 5,
                    CityId = 3,
                    QuestionText = "När invigdes den vridna skyskrapan Turning Torso?"
                },
                new Question
                {
                    QuestionId = 6,
                    CityId = 3,
                    QuestionText = "Vad heter ön som ansluter Öresundsbron med Malmö?"
                },
                new Question
                {
                    QuestionId = 7,
                    CityId = 4,
                    QuestionText = "Vart pluggar spelutvecklarstudenter och antikvariestudenter vid Uppsala Universitet?"
                },
                new Question
                {
                    QuestionId = 8,
                    CityId = 4,
                    QuestionText = "Vilken känd, fiktiv, katt förknippas med Uppsala?"
                },
                new Question
                {
                    QuestionId = 9,
                    CityId = 5,
                    QuestionText = "Vilken matvarujätte grundades i Västerås?"
                },
                new Question
                {
                    QuestionId = 10,
                    CityId = 5,
                    QuestionText = "Sveriges första gymnasie grundades i Västerås, när?"
                },
                new Question
                {
                    QuestionId = 11,
                    CityId = 6,
                    QuestionText = "Vad kallas det välkända vattentornet i Örebro?"
                },
                new Question
                {
                    QuestionId = 12,
                    CityId = 6,
                    QuestionText = "I vilket landskap ligger Örebro?"
                },
                new Question
                {
                    QuestionId = 13,
                    CityId = 7,
                    QuestionText = "Vilken å rinner genom Linköping?"
                },
                new Question
                {
                    QuestionId = 14,
                    CityId = 7,
                    QuestionText = "Vilket känt rockband kommer från Linköping?"
                },
                new Question
                {
                    QuestionId = 15,
                    CityId = 8,
                    QuestionText = "Vilket kaffemärke kommer från Helsingborg?"
                },
                new Question
                {
                    QuestionId = 16,
                    CityId = 8,
                    QuestionText = "Till vilken dansk stad går färjorna från Helsingborg?"
                },
                new Question
                {
                    QuestionId = 17,
                    CityId = 9,
                    QuestionText = "Vilket smeknamn har Umeå?"
                },
                new Question
                {
                    QuestionId = 18,
                    CityId = 9,
                    QuestionText = "Vad heter den älv som rinner genom Umeå?"
                },
                new Question
                {
                    QuestionId = 19,
                    CityId = 10,
                    QuestionText = "Vilken tradition uppstod på Lunds universitet som lösning på studenternas oförmåga att hålla tiden"
                },
                new Question
                {
                    QuestionId = 20,
                    CityId = 10,
                    QuestionText = "Vad kallas en person kommer från Lund?"
                }
            );

            // SVARSALTERNATIV: FYRA PER FRÅGA

            modelBuilder.Entity<Option>().HasData(
                // Fråga 1
                new Option { OptionId = 1, QuestionId = 1, OptionText = "Vasamuseet", IsCorrect = true },
                new Option { OptionId = 2, QuestionId = 1, OptionText = "Sjöhistoriska museet", IsCorrect = false },
                new Option { OptionId = 3, QuestionId = 1, OptionText = "Nordiska museet", IsCorrect = false },
                new Option { OptionId = 4, QuestionId = 1, OptionText = "Tekniska museet", IsCorrect = false },

                // Fråga 2
                new Option { OptionId = 5, QuestionId = 2, OptionText = "Vättern", IsCorrect = false },
                new Option { OptionId = 6, QuestionId = 2, OptionText = "Mälaren", IsCorrect = true },
                new Option { OptionId = 7, QuestionId = 2, OptionText = "Vänern", IsCorrect = false },
                new Option { OptionId = 8, QuestionId = 2, OptionText = "Siljan", IsCorrect = false },

                // Fråga 3
                new Option { OptionId = 9, QuestionId = 3, OptionText = "Göran", IsCorrect = false },
                new Option { OptionId = 10, QuestionId = 3, OptionText = "Sven", IsCorrect = false },
                new Option { OptionId = 11, QuestionId = 3, OptionText = "Glenn", IsCorrect = true },
                new Option { OptionId = 12, QuestionId = 3, OptionText = "Gösta", IsCorrect = false },

                // Fråga 4
                new Option { OptionId = 13, QuestionId = 4, OptionText = "Turning Torso", IsCorrect = false },
                new Option { OptionId = 14, QuestionId = 4, OptionText = "Mässan", IsCorrect = false },
                new Option { OptionId = 15, QuestionId = 4, OptionText = "Göta Älvsskrapan", IsCorrect = false },
                new Option { OptionId = 16, QuestionId = 4, OptionText = "Läppstiftet", IsCorrect = true },

                // Fråga 5
                new Option { OptionId = 17, QuestionId = 5, OptionText = "2005", IsCorrect = true },
                new Option { OptionId = 18, QuestionId = 5, OptionText = "1999", IsCorrect = false },
                new Option { OptionId = 19, QuestionId = 5, OptionText = "2003", IsCorrect = false },
                new Option { OptionId = 20, QuestionId = 5, OptionText = "2006", IsCorrect = false },

                // Fråga 6
                new Option { OptionId = 21, QuestionId = 6, OptionText = "Saltön", IsCorrect = false },
                new Option { OptionId = 22, QuestionId = 6, OptionText = "Pepparholmen", IsCorrect = true },
                new Option { OptionId = 23, QuestionId = 6, OptionText = "Stenö", IsCorrect = false },
                new Option { OptionId = 24, QuestionId = 6, OptionText = "Zlatansholme", IsCorrect = false },

                // Fråga 7
                new Option { OptionId = 25, QuestionId = 7, OptionText = "Uppsala", IsCorrect = false },
                new Option { OptionId = 26, QuestionId = 7, OptionText = "Skellefteå", IsCorrect = false },
                new Option { OptionId = 27, QuestionId = 7, OptionText = "Visby", IsCorrect = true },
                new Option { OptionId = 28, QuestionId = 7, OptionText = "Skövde", IsCorrect = false },

                // Fråga 8
                new Option { OptionId = 29, QuestionId = 8, OptionText = "Luffar-Lasse", IsCorrect = false },
                new Option { OptionId = 30, QuestionId = 8, OptionText = "Katten Gustaf", IsCorrect = false },
                new Option { OptionId = 31, QuestionId = 8, OptionText = "Tom från Tom och Jerry", IsCorrect = false },
                new Option { OptionId = 32, QuestionId = 8, OptionText = "Pelle Svanslös", IsCorrect = true },

                // Fråga 9
                new Option { OptionId = 33, QuestionId = 9, OptionText = "ICA", IsCorrect = true },
                new Option { OptionId = 34, QuestionId = 9, OptionText = "COOP", IsCorrect = false },
                new Option { OptionId = 35, QuestionId = 9, OptionText = "WILLYs", IsCorrect = false },
                new Option { OptionId = 36, QuestionId = 9, OptionText = "Hemköp", IsCorrect = false },

                // Fråga 10
                new Option { OptionId = 37, QuestionId = 10, OptionText = "1637", IsCorrect = false },
                new Option { OptionId = 38, QuestionId = 10, OptionText = "1623", IsCorrect = true },
                new Option { OptionId = 39, QuestionId = 10, OptionText = "1723", IsCorrect = false },
                new Option { OptionId = 40, QuestionId = 10, OptionText = "1758", IsCorrect = false },

                // Fråga 11
                new Option { OptionId = 41, QuestionId = 11, OptionText = "Kronan", IsCorrect = false },
                new Option { OptionId = 42, QuestionId = 11, OptionText = "Koppen", IsCorrect = false },
                new Option { OptionId = 43, QuestionId = 11, OptionText = "Svampen", IsCorrect = true },
                new Option { OptionId = 44, QuestionId = 11, OptionText = "Fyren", IsCorrect = false },

                // Fråga 12
                new Option { OptionId = 45, QuestionId = 12, OptionText = "Dalarna", IsCorrect = false },
                new Option { OptionId = 46, QuestionId = 12, OptionText = "Bohuslän", IsCorrect = false },
                new Option { OptionId = 47, QuestionId = 12, OptionText = "Blekinge", IsCorrect = false },
                new Option { OptionId = 48, QuestionId = 12, OptionText = "Närke", IsCorrect = true },

                // Fråga 13
                new Option { OptionId = 49, QuestionId = 13, OptionText = "Stångån", IsCorrect = true },
                new Option { OptionId = 50, QuestionId = 13, OptionText = "Fyrisån", IsCorrect = false },
                new Option { OptionId = 51, QuestionId = 13, OptionText = "Rönne å", IsCorrect = false },
                new Option { OptionId = 52, QuestionId = 13, OptionText = "Nissan", IsCorrect = false },

                // Fråga 14
                new Option { OptionId = 53, QuestionId = 14, OptionText = "Europe", IsCorrect = false },
                new Option { OptionId = 54, QuestionId = 14, OptionText = "Ghost", IsCorrect = true },
                new Option { OptionId = 55, QuestionId = 14, OptionText = "The Cardigans", IsCorrect = false },
                new Option { OptionId = 56, QuestionId = 14, OptionText = "Sabaton", IsCorrect = false },

                // Fråga 15
                new Option { OptionId = 57, QuestionId = 15, OptionText = "Gevalia", IsCorrect = false },
                new Option { OptionId = 58, QuestionId = 15, OptionText = "Nescafe", IsCorrect = false },
                new Option { OptionId = 59, QuestionId = 15, OptionText = "Zoégas", IsCorrect = true },
                new Option { OptionId = 60, QuestionId = 15, OptionText = "Löfbergs", IsCorrect = false },

                // Fråga 16
                new Option { OptionId = 61, QuestionId = 16, OptionText = "Köpenhamn", IsCorrect = false },
                new Option { OptionId = 62, QuestionId = 16, OptionText = "Århus", IsCorrect = false },
                new Option { OptionId = 63, QuestionId = 16, OptionText = "Odense", IsCorrect = false },
                new Option { OptionId = 64, QuestionId = 16, OptionText = "Helsingör", IsCorrect = true },

                // Fråga 17
                new Option { OptionId = 65, QuestionId = 17, OptionText = "Björkarnas stad", IsCorrect = true },
                new Option { OptionId = 66, QuestionId = 17, OptionText = "Gurkstaden", IsCorrect = false },
                new Option { OptionId = 67, QuestionId = 17, OptionText = "Solstaden", IsCorrect = false },
                new Option { OptionId = 68, QuestionId = 17, OptionText = "Lilla London", IsCorrect = false },

                // Fråga 18
                new Option { OptionId = 69, QuestionId = 18, OptionText = "Luleälven", IsCorrect = false },
                new Option { OptionId = 70, QuestionId = 18, OptionText = "Umeälven", IsCorrect = true },
                new Option { OptionId = 71, QuestionId = 18, OptionText = "Dalälven", IsCorrect = false },
                new Option { OptionId = 72, QuestionId = 18, OptionText = "Göta älv", IsCorrect = false },

                // Fråga 19
                new Option { OptionId = 73, QuestionId = 19, OptionText = "Akademisk timme", IsCorrect = false },
                new Option { OptionId = 74, QuestionId = 19, OptionText = "Akademisk halvtimme", IsCorrect = false },
                new Option { OptionId = 75, QuestionId = 19, OptionText = "Akademisk kvart", IsCorrect = true },
                new Option { OptionId = 76, QuestionId = 19, OptionText = "Akademisk minut", IsCorrect = false },

                // Fråga 20
                new Option { OptionId = 77, QuestionId = 20, OptionText = "Lundin", IsCorrect = false },
                new Option { OptionId = 78, QuestionId = 20, OptionText = "Lundapåg", IsCorrect = false },
                new Option { OptionId = 79, QuestionId = 20, OptionText = "Lundare", IsCorrect = false },
                new Option { OptionId = 80, QuestionId = 20, OptionText = "Lundensare", IsCorrect = true }
            );

            // LEDTRÅDAR: FEM PER STAD

            modelBuilder.Entity<Clue>().HasData(
                // Stockholm
                new Clue { ClueId = 1, CityId = 1, Point = 10m, ClueText = "Vi reser till en stad mellan en stor insjö och Östersjön." },
                new Clue { ClueId = 2, CityId = 1, Point = 8m, ClueText = "Här finns en kunglig bostad och byggnaden där Nobelbanketten hålls." },
                new Clue { ClueId = 3, CityId = 1, Point = 6m, ClueText = "Ett välbevarat krigsskepp från 1600-talet finns på ett museum här." },
                new Clue { ClueId = 4, CityId = 1, Point = 4m, ClueText = "Gamla stan och Djurgården är välkända delar av staden." },
                new Clue { ClueId = 5, CityId = 1, Point = 2m, ClueText = "Vi söker Sveriges huvudstad." },

                // Göteborg
                new Clue { ClueId = 6, CityId = 2, Point = 10m, ClueText = "Vi reser till en stad vid västkusten med en lång sjöfartshistoria." },
                new Clue { ClueId = 7, CityId = 2, Point = 8m, ClueText = "Staden grundades av Gustav II Adolf år 1621." },
                new Clue { ClueId = 8, CityId = 2, Point = 6m, ClueText = "Här finns Avenyn och Feskekörka." },
                new Clue { ClueId = 9, CityId = 2, Point = 4m, ClueText = "Nöjesparken Liseberg ligger här." },
                new Clue { ClueId = 10, CityId = 2, Point = 2m, ClueText = "Vi söker Sveriges näst största stad, vid Göta älvs mynning." },

                // Malmö
                new Clue { ClueId = 11, CityId = 3, Point = 10m, ClueText = "Vi reser till en stad i ett landskap som länge tillhörde Danmark." },
                new Clue { ClueId = 12, CityId = 3, Point = 8m, ClueText = "Här finns både ett gammalt slott och en vriden skyskrapa." },
                new Clue { ClueId = 13, CityId = 3, Point = 6m, ClueText = "Staden har en broförbindelse över Öresund till Danmark." },
                new Clue { ClueId = 14, CityId = 3, Point = 4m, ClueText = "År 2024 stod staden värd för Eurovision Song Contest" },
                new Clue { ClueId = 15, CityId = 3, Point = 2m, ClueText = "Vi söker Skånes största stad." },

                // Uppsala
                new Clue { ClueId = 16, CityId = 4, Point = 10m, ClueText = "Vi reser till en stad där vetenskap och kyrkohistoria möts." },
                new Clue { ClueId = 17, CityId = 4, Point = 8m, ClueText = "Carl von Linné bodde och arbetade här." },
                new Clue { ClueId = 18, CityId = 4, Point = 6m, ClueText = "Stadens universitet grundades år 1477." },
                new Clue { ClueId = 19, CityId = 4, Point = 4m, ClueText = "Fyrisån rinner genom staden, som har en stor domkyrka." },
                new Clue { ClueId = 20, CityId = 4, Point = 2m, ClueText = "Vi söker universitetsstaden norr om Stockholm." },

                // Västerås
                new Clue { ClueId = 21, CityId = 5, Point = 10m, ClueText = "Här finns både gravhögen Anundshög och det obskyra lilla Utter Inn." },
                new Clue { ClueId = 22, CityId = 5, Point = 8m, ClueText = "Staden har en lång historia inom svensk elektroteknisk industri." },
                new Clue { ClueId = 23, CityId = 5, Point = 6m, ClueText = "I staden ligger Erik XIV begravd, i en för kort sarkofag, varför hans fötter fick huggas av." },
                new Clue { ClueId = 24, CityId = 5, Point = 4m, ClueText = "Staden har en vänskaplig rivalitet med Örebro." },
                new Clue { ClueId = 25, CityId = 5, Point = 2m, ClueText = "Vi söker staden som ofta kallas Gurkstaden." },

                // Örebro
                new Clue { ClueId = 26, CityId = 6, Point = 10m, ClueText = "Vår resa går till en stad i landskapet Närke." },
                new Clue { ClueId = 27, CityId = 6, Point = 8m, ClueText = "Här finns ett välkänt vattentorn som också är ett besöksmål." },
                new Clue { ClueId = 28, CityId = 6, Point = 6m, ClueText = "Svartån rinner genom stadens centrum." },
                new Clue { ClueId = 29, CityId = 6, Point = 4m, ClueText = "Mitt i staden ligger ett slott på en ö" },
                new Clue { ClueId = 30, CityId = 6, Point = 2m, ClueText = "Staden hyser besöksmålet Wadköping" },

                // Linköping
                new Clue { ClueId = 31, CityId = 7, Point = 10m, ClueText = "Vi reser till en universitetsstad i sydöstra Sverige." },
                new Clue { ClueId = 32, CityId = 7, Point = 8m, ClueText = "Staden är känd för ett stort konvent tillägnat Japansk kultur." },
                new Clue { ClueId = 33, CityId = 7, Point = 6m, ClueText = "I luften över staden flyger tidvis Gripar, men Drakarna är sedan länge borta." },
                new Clue { ClueId = 34, CityId = 7, Point = 4m, ClueText = "Staden huserar den näst största kyrkan i Sverige." },
                new Clue { ClueId = 35, CityId = 7, Point = 2m, ClueText = "Staden slogan är den klämchecka ''Där ideér blir verklighet''." },

                // Helsingborg
                new Clue { ClueId = 36, CityId = 8, Point = 10m, ClueText = "Vi reser till en stad vid vattnet i Södra Sverige." },
                new Clue { ClueId = 37, CityId = 8, Point = 8m, ClueText = "Här finns slottet Sofiero med sina trädgårdar." },
                new Clue { ClueId = 38, CityId = 8, Point = 6m, ClueText = "Från staden går färjor till Danmark." },
                new Clue { ClueId = 39, CityId = 8, Point = 4m, ClueText = "Det medeltida tornet Kärnan ligger i staden." },
                new Clue { ClueId = 40, CityId = 8, Point = 2m, ClueText = "Staden kallas ibland för ''Sundets Pärla''." },

                // Umeå
                new Clue { ClueId = 41, CityId = 9, Point = 10m, ClueText = "Vi reser till en stad i norra Sverige, ibland kallad ''Norra Sveriges Huvudstad''." },
                new Clue { ClueId = 42, CityId = 9, Point = 8m, ClueText = "Efter en stor brand 1888 planterades många träd här." },
                new Clue { ClueId = 43, CityId = 9, Point = 6m, ClueText = "Staden var Europas kulturhuvudstad år 2014." },
                new Clue { ClueId = 44, CityId = 9, Point = 4m, ClueText = "I staden finns ett univeristet." },
                new Clue { ClueId = 45, CityId = 9, Point = 2m, ClueText = "Staden kallas ibland för ''Nordens Kulturhuvudstad''." },

                // Lund
                new Clue { ClueId = 46, CityId = 10, Point = 10m, ClueText = "Vi reser till en skånsk stad med en lång akademisk historia." },
                new Clue { ClueId = 47, CityId = 10, Point = 8m, ClueText = "Universitetet här grundades år 1666." },
                new Clue { ClueId = 48, CityId = 10, Point = 6m, ClueText = "Staden har en medeltida domkyrka med ett astronomiskt ur." },
                new Clue { ClueId = 49, CityId = 10, Point = 4m, ClueText = "Friluftsmuseet Kulturen finns i denna stad." },
                new Clue { ClueId = 50, CityId = 10, Point = 2m, ClueText = "Staden är en av Sveriges äldsta, och grundades år 990." }
            );

            modelBuilder.Entity<City>().HasData(
                new City { CityId = 11, Name = "Karlstad", CityPicture = "ef7ad527345a436ab0074e50f2467262" },
                new City { CityId = 12, Name = "Östersund", CityPicture = "f6b74ed4d8e54cc8bed5e1048d1f41f2" },
                new City { CityId = 13, Name = "Sundsvall", CityPicture = "29ed87ccb7214cfd96db0991eafa7e6a" },
                new City { CityId = 14, Name = "Luleå", CityPicture = "c9104aade1be4cf98ef7d7ad335f8a8c" },
                new City { CityId = 15, Name = "Kiruna", CityPicture = "eb8c51d163eb4f5eb5a8131c7822860b" },
                new City { CityId = 16, Name = "Gävle", CityPicture = "b8531fc4114b40f2b38cb9de426168b3" },
                new City { CityId = 17, Name = "Falun", CityPicture = "c775c43beb10482e8764522ccfa5d0e6" },
                new City { CityId = 18, Name = "Borlänge", CityPicture = "5a96bb6ab3f144ce8125684e738055b1" },
                new City { CityId = 19, Name = "Mora", CityPicture = "38dc7ea7913d45e6bd272aced8de72bc" },
                new City { CityId = 20, Name = "Visby", CityPicture = "683a42cd701d4916b1af4859a4141dda" },
                new City { CityId = 21, Name = "Kalmar", CityPicture = "f1123269ba81429993953a54e14beca1" },
                new City { CityId = 22, Name = "Karlskrona", CityPicture = "a51b7da93e1b4a7099e1778e3e8c2da0" },
                new City { CityId = 23, Name = "Växjö", CityPicture = "8f6aa14c666f4340a131b4b6de9dbd57" },
                new City { CityId = 24, Name = "Halmstad", CityPicture = "d9f0186187aa4bd7befcfbfc33c6b07a" },
                new City { CityId = 25, Name = "Borås", CityPicture = "bb50eba8343b403e9cfaabb207640c86" },
                new City { CityId = 26, Name = "Trollhättan", CityPicture = "66013b45f450453fbfdbe0a2e462f3df" },
                new City { CityId = 27, Name = "Uddevalla", CityPicture = "d33cc860c2274573adc81448021b497f" },
                new City { CityId = 28, Name = "Skövde", CityPicture = "1e231efb9a8a4769b742a0b2aaa3f200" },
                new City { CityId = 29, Name = "Eskilstuna", CityPicture = "be520cd1ba3d42168f81a76b3db5960e" },
                new City { CityId = 30, Name = "Nyköping", CityPicture = "e0a6d72ab0e94937994574a761d09291" },
                new City { CityId = 31, Name = "Norrköping", CityPicture = "7cc28bdafb154050a93e542a23815b60" },
                new City { CityId = 32, Name = "Jönköping", CityPicture = "f26b39f34ce148b08a6cf0b8cca07ae4" },
                new City { CityId = 33, Name = "Kristianstad", CityPicture = "cb97185072bd4c0f976e3f74abf6d671" },
                new City { CityId = 34, Name = "Ystad", CityPicture = "d0a6c80414a84854bde949025c453c61" },
                new City { CityId = 35, Name = "Trelleborg", CityPicture = "3e9bcc7658b44c498c3cc1b4f3a4fac7" },
                new City { CityId = 36, Name = "Landskrona", CityPicture = "0fdae2802ba34aeeaa4064a9f86189cc" },
                new City { CityId = 37, Name = "Varberg", CityPicture = "c3c507d7952f4d2d833c3944eb138bab" },
                new City { CityId = 38, Name = "Falkenberg", CityPicture = "13a0d5c7252342ceb5fef50703330c65" },
                new City { CityId = 39, Name = "Örnsköldsvik", CityPicture = "0e8a82b234e245578b53ac8fa4b51a3e" },
                new City { CityId = 40, Name = "Skellefteå", CityPicture = "cae60760b3384fe88a6c9761aa474511" }
            );

            modelBuilder.Entity<Question>().HasData(
                // Karlstad
                new Question { QuestionId = 21, CityId = 11, QuestionText = "Vilken konstnär är huvudpersonen bakom den permanenta samlingen på Sandgrund i Karlstad?" },
                // Karlstad
                new Question { QuestionId = 22, CityId = 11, QuestionText = "Vilken målningsteknik är särskilt förknippad med samlingen på Sandgrund i Karlstad?" },
                // Östersund
                new Question { QuestionId = 23, CityId = 12, QuestionText = "Vilket lag besegrade Östersunds FK i herrfinalen i Svenska cupen 2017?" },
                // Östersund
                new Question { QuestionId = 24, CityId = 12, QuestionText = "Med vilket resultat vann Östersunds FK herrfinalen i Svenska cupen 2017?" },
                // Sundsvall
                new Question { QuestionId = 25, CityId = 13, QuestionText = "Under vilken svensk kung grundades Sundsvall?" },
                // Sundsvall
                new Question { QuestionId = 26, CityId = 13, QuestionText = "Vilket år räknas som Sundsvalls grundande?" },
                // Luleå
                new Question { QuestionId = 27, CityId = 14, QuestionText = "Vilket år invigdes Kulturens hus i Luleå?" },
                // Luleå
                new Question { QuestionId = 28, CityId = 14, QuestionText = "Vilken av dessa verksamheter finns i Kulturens hus i Luleå?" },
                // Kiruna
                new Question { QuestionId = 29, CityId = 15, QuestionText = "Vad heter forskningsanläggningen nära Kiruna som invigdes 1966?" },
                // Kiruna
                new Question { QuestionId = 30, CityId = 15, QuestionText = "Vilken typ av raketer har använts vid Esrange för att studera atmosfären?" },
                // Gävle
                new Question { QuestionId = 31, CityId = 16, QuestionText = "Vilken protestsångare och facklig aktivist föddes i Gävle 1879?" },
                // Gävle
                new Question { QuestionId = 32, CityId = 16, QuestionText = "I vilken amerikansk delstat avrättades den Gävlefödde Joe Hill 1915?" },
                // Falun
                new Question { QuestionId = 33, CityId = 17, QuestionText = "Vilken författare skrev Nils Holgerssons underbara resa genom Sverige under sin tid i Falun?" },
                // Falun
                new Question { QuestionId = 34, CityId = 17, QuestionText = "Vilket Nobelpris fick Selma Lagerlöf, som under en period bodde i Falun?" },
                // Borlänge
                new Question { QuestionId = 35, CityId = 18, QuestionText = "Vilken internationellt känd operasångare kom från Borlänge?" },
                // Borlänge
                new Question { QuestionId = 36, CityId = 18, QuestionText = "Vilket röstläge hade den Borlängefödde operasångaren Jussi Björling?" },
                // Mora
                new Question { QuestionId = 37, CityId = 19, QuestionText = "Vad heter sagoparken utanför Mora där besökare kan möta tomtar och troll?" },
                // Mora
                new Question { QuestionId = 38, CityId = 19, QuestionText = "Vad heter området i Tomteland nära Mora där Trollkungen och stortrollen håller till?" },
                // Visby
                new Question { QuestionId = 39, CityId = 20, QuestionText = "Vilket museum i Visby har en utställning som heter Bildstenshallen?" },
                // Visby
                new Question { QuestionId = 40, CityId = 20, QuestionText = "Vilken historisk period är de gotländska bildstenarna särskilt förknippade med?" },
                // Kalmar
                new Question { QuestionId = 41, CityId = 21, QuestionText = "Vilket regalskepp står i centrum för en stor utställning på Kalmar läns museum?" },
                // Kalmar
                new Question { QuestionId = 42, CityId = 21, QuestionText = "Vilket år sjönk regalskeppet Kronan, vars fynd visas på Kalmar läns museum?" },
                // Karlskrona
                new Question { QuestionId = 43, CityId = 22, QuestionText = "Vad heter det välkända kolonistugeområdet på en holme vid Dragsö i Karlskrona?" },
                // Karlskrona
                new Question { QuestionId = 44, CityId = 22, QuestionText = "Hur många små röda kolonistugor finns i Brändaholm i Karlskrona?" },
                // Växjö
                new Question { QuestionId = 45, CityId = 23, QuestionText = "Vilken Nobelpristagare skrev Dvärgen och föddes i Växjö?" },
                // Växjö
                new Question { QuestionId = 46, CityId = 23, QuestionText = "Vilket år fick den Växjöfödde Pär Lagerkvist Nobelpriset i litteratur?" },
                // Halmstad
                new Question { QuestionId = 47, CityId = 24, QuestionText = "Vilken popgrupp från Halmstad bildades 1978?" },
                // Halmstad
                new Question { QuestionId = 48, CityId = 24, QuestionText = "Vem är sångare i den Halmstadsförknippade gruppen Gyllene Tider?" },
                // Borås
                new Question { QuestionId = 49, CityId = 25, QuestionText = "Vilken sagofigur föreställer skulpturen Walking to Borås?" },
                // Borås
                new Question { QuestionId = 50, CityId = 25, QuestionText = "Vilken konstnär skapade skulpturen Walking to Borås?" },
                // Trollhättan
                new Question { QuestionId = 51, CityId = 26, QuestionText = "I vilken idrott tog Trollhätteprofilen Nils van der Poel OS-guld 2022?" },
                // Trollhättan
                new Question { QuestionId = 52, CityId = 26, QuestionText = "Hur många OS-guld tog Trollhätteprofilen Nils van der Poel i Peking 2022?" },
                // Uddevalla
                new Question { QuestionId = 53, CityId = 27, QuestionText = "Vad heter den historiska havsbadorten strax söder om Uddevalla?" },
                // Uddevalla
                new Question { QuestionId = 54, CityId = 27, QuestionText = "Vilken typ av skola grundades i Gustafsberg vid Uddevalla 1774?" },
                // Skövde
                new Question { QuestionId = 55, CityId = 28, QuestionText = "Vad heter Skövdes science center med experiment för besökare?" },
                // Skövde
                new Question { QuestionId = 56, CityId = 28, QuestionText = "Vilka ämnesområden står i centrum på Balthazar Science Center i Skövde?" },
                // Eskilstuna
                new Question { QuestionId = 57, CityId = 29, QuestionText = "Vad heter Eskilstunas galleria som är inriktad på återbruk?" },
                // Eskilstuna
                new Question { QuestionId = 58, CityId = 29, QuestionText = "Vilket år öppnade återbruksgallerian ReTuna i Eskilstuna?" },
                // Nyköping
                new Question { QuestionId = 59, CityId = 30, QuestionText = "Vilket varuhus hade egna möbelverkstäder i Nyköping under 1900-talet?" },
                // Nyköping
                new Question { QuestionId = 60, CityId = 30, QuestionText = "Vilken typ av produkter tillverkades i NK:s verkstäder i Nyköping?" },
                // Norrköping
                new Question { QuestionId = 61, CityId = 31, QuestionText = "Vilket namn hade föreningen som blev Norrköping Dolphins vid starten?" },
                // Norrköping
                new Question { QuestionId = 62, CityId = 31, QuestionText = "Vilket år bildades Hageby Basket, föregångaren till Norrköping Dolphins?" },
                // Jönköping
                new Question { QuestionId = 63, CityId = 32, QuestionText = "Vilka föreningars hockeyverksamheter slogs samman när HV71 bildades?" },
                // Jönköping
                new Question { QuestionId = 64, CityId = 32, QuestionText = "Vilket år bildades Jönköpingsklubben HV71?" },
                // Kristianstad
                new Question { QuestionId = 65, CityId = 33, QuestionText = "Vilket år bildades idrottsföreningen IFK Kristianstad?" },
                // Kristianstad
                new Question { QuestionId = 66, CityId = 33, QuestionText = "Vilken färg är särskilt förknippad med IFK Kristianstads handbollslag?" },
                // Ystad
                new Question { QuestionId = 67, CityId = 34, QuestionText = "Vilken pianist var med och grundade Ystad Sweden Jazz Festival 2010?" },
                // Ystad
                new Question { QuestionId = 68, CityId = 34, QuestionText = "Vilket instrument spelar Ystad Sweden Jazz Festivals medgrundare Jan Lundgren?" },
                // Trelleborg
                new Question { QuestionId = 69, CityId = 35, QuestionText = "Vilken konstnär har gett namn åt konsthallen intill stadsparken i Trelleborg?" },
                // Trelleborg
                new Question { QuestionId = 70, CityId = 35, QuestionText = "Vilket år uppfördes Axel Ebbes konsthall i Trelleborg?" },
                // Landskrona
                new Question { QuestionId = 71, CityId = 36, QuestionText = "Vilket år bildades Landskrona BoIS?" },
                // Landskrona
                new Question { QuestionId = 72, CityId = 36, QuestionText = "Vilka två föreningar slogs samman när Landskrona BoIS bildades?" },
                // Varberg
                new Question { QuestionId = 73, CityId = 37, QuestionText = "Vad heter den historiska radiostationen utanför Varberg?" },
                // Varberg
                new Question { QuestionId = 74, CityId = 37, QuestionText = "Vilken anropssignal har den historiska långvågssändaren i Grimeton?" },
                // Falkenberg
                new Question { QuestionId = 75, CityId = 38, QuestionText = "Vem grundade Bryggeri AB Falken i Falkenberg?" },
                // Falkenberg
                new Question { QuestionId = 76, CityId = 38, QuestionText = "Vilket år grundades Bryggeri AB Falken i Falkenberg?" },
                // Örnsköldsvik
                new Question { QuestionId = 77, CityId = 39, QuestionText = "Vem grundade friluftsföretaget Fjällräven i Örnsköldsvik?" },
                // Örnsköldsvik
                new Question { QuestionId = 78, CityId = 39, QuestionText = "Vilket år grundades Fjällräven i Örnsköldsvik?" },
                // Skellefteå
                new Question { QuestionId = 79, CityId = 40, QuestionText = "Vilken uppfinnare grundade Alimak i Skellefteå 1948?" },
                // Skellefteå
                new Question { QuestionId = 80, CityId = 40, QuestionText = "Vilken typ av produkter är Skellefteåföretaget Alimak särskilt känt för?" }
            );

            modelBuilder.Entity<Option>().HasData(
                new Option { OptionId = 81, QuestionId = 21, OptionText = "Lars Lerin", IsCorrect = true },
                new Option { OptionId = 82, QuestionId = 21, OptionText = "Anders Zorn", IsCorrect = false },
                new Option { OptionId = 83, QuestionId = 21, OptionText = "Carl Larsson", IsCorrect = false },
                new Option { OptionId = 84, QuestionId = 21, OptionText = "Bruno Liljefors", IsCorrect = false },
                new Option { OptionId = 85, QuestionId = 22, OptionText = "Glasmåleri", IsCorrect = false },
                new Option { OptionId = 86, QuestionId = 22, OptionText = "Akvarell", IsCorrect = true },
                new Option { OptionId = 87, QuestionId = 22, OptionText = "Freskomåleri", IsCorrect = false },
                new Option { OptionId = 88, QuestionId = 22, OptionText = "Enkaustik", IsCorrect = false },
                new Option { OptionId = 89, QuestionId = 23, OptionText = "Malmö FF", IsCorrect = false },
                new Option { OptionId = 90, QuestionId = 23, OptionText = "IFK Göteborg", IsCorrect = false },
                new Option { OptionId = 91, QuestionId = 23, OptionText = "IFK Norrköping", IsCorrect = true },
                new Option { OptionId = 92, QuestionId = 23, OptionText = "AIK", IsCorrect = false },
                new Option { OptionId = 93, QuestionId = 24, OptionText = "1–0", IsCorrect = false },
                new Option { OptionId = 94, QuestionId = 24, OptionText = "2–1", IsCorrect = false },
                new Option { OptionId = 95, QuestionId = 24, OptionText = "3–2", IsCorrect = false },
                new Option { OptionId = 96, QuestionId = 24, OptionText = "4–1", IsCorrect = true },
                new Option { OptionId = 97, QuestionId = 25, OptionText = "Gustav II Adolf", IsCorrect = true },
                new Option { OptionId = 98, QuestionId = 25, OptionText = "Gustav Vasa", IsCorrect = false },
                new Option { OptionId = 99, QuestionId = 25, OptionText = "Karl XII", IsCorrect = false },
                new Option { OptionId = 100, QuestionId = 25, OptionText = "Gustav III", IsCorrect = false },
                new Option { OptionId = 101, QuestionId = 26, OptionText = "1786", IsCorrect = false },
                new Option { OptionId = 102, QuestionId = 26, OptionText = "1621", IsCorrect = true },
                new Option { OptionId = 103, QuestionId = 26, OptionText = "1523", IsCorrect = false },
                new Option { OptionId = 104, QuestionId = 26, OptionText = "1680", IsCorrect = false },
                new Option { OptionId = 105, QuestionId = 27, OptionText = "1997", IsCorrect = false },
                new Option { OptionId = 106, QuestionId = 27, OptionText = "2017", IsCorrect = false },
                new Option { OptionId = 107, QuestionId = 27, OptionText = "2007", IsCorrect = true },
                new Option { OptionId = 108, QuestionId = 27, OptionText = "1987", IsCorrect = false },
                new Option { OptionId = 109, QuestionId = 28, OptionText = "Tingsrätt", IsCorrect = false },
                new Option { OptionId = 110, QuestionId = 28, OptionText = "Akutmottagning", IsCorrect = false },
                new Option { OptionId = 111, QuestionId = 28, OptionText = "Simhall", IsCorrect = false },
                new Option { OptionId = 112, QuestionId = 28, OptionText = "Stadsbibliotek", IsCorrect = true },
                new Option { OptionId = 113, QuestionId = 29, OptionText = "Esrange", IsCorrect = true },
                new Option { OptionId = 114, QuestionId = 29, OptionText = "MAX IV", IsCorrect = false },
                new Option { OptionId = 115, QuestionId = 29, OptionText = "Onsala rymdobservatorium", IsCorrect = false },
                new Option { OptionId = 116, QuestionId = 29, OptionText = "SciLifeLab", IsCorrect = false },
                new Option { OptionId = 117, QuestionId = 30, OptionText = "Nödraketer", IsCorrect = false },
                new Option { OptionId = 118, QuestionId = 30, OptionText = "Sondraketer", IsCorrect = true },
                new Option { OptionId = 119, QuestionId = 30, OptionText = "Signalraketer", IsCorrect = false },
                new Option { OptionId = 120, QuestionId = 30, OptionText = "Fyrverkeriraketer", IsCorrect = false },
                new Option { OptionId = 121, QuestionId = 31, OptionText = "Pete Seeger", IsCorrect = false },
                new Option { OptionId = 122, QuestionId = 31, OptionText = "Bob Dylan", IsCorrect = false },
                new Option { OptionId = 123, QuestionId = 31, OptionText = "Joe Hill", IsCorrect = true },
                new Option { OptionId = 124, QuestionId = 31, OptionText = "Woody Guthrie", IsCorrect = false },
                new Option { OptionId = 125, QuestionId = 32, OptionText = "Texas", IsCorrect = false },
                new Option { OptionId = 126, QuestionId = 32, OptionText = "Kalifornien", IsCorrect = false },
                new Option { OptionId = 127, QuestionId = 32, OptionText = "Florida", IsCorrect = false },
                new Option { OptionId = 128, QuestionId = 32, OptionText = "Utah", IsCorrect = true },
                new Option { OptionId = 129, QuestionId = 33, OptionText = "Selma Lagerlöf", IsCorrect = true },
                new Option { OptionId = 130, QuestionId = 33, OptionText = "Astrid Lindgren", IsCorrect = false },
                new Option { OptionId = 131, QuestionId = 33, OptionText = "Elsa Beskow", IsCorrect = false },
                new Option { OptionId = 132, QuestionId = 33, OptionText = "Karin Boye", IsCorrect = false },
                new Option { OptionId = 133, QuestionId = 34, OptionText = "Kemi", IsCorrect = false },
                new Option { OptionId = 134, QuestionId = 34, OptionText = "Litteratur", IsCorrect = true },
                new Option { OptionId = 135, QuestionId = 34, OptionText = "Fred", IsCorrect = false },
                new Option { OptionId = 136, QuestionId = 34, OptionText = "Fysik", IsCorrect = false },
                new Option { OptionId = 137, QuestionId = 35, OptionText = "Nicolai Gedda", IsCorrect = false },
                new Option { OptionId = 138, QuestionId = 35, OptionText = "Peter Mattei", IsCorrect = false },
                new Option { OptionId = 139, QuestionId = 35, OptionText = "Jussi Björling", IsCorrect = true },
                new Option { OptionId = 140, QuestionId = 35, OptionText = "Birgit Nilsson", IsCorrect = false },
                new Option { OptionId = 141, QuestionId = 36, OptionText = "Bas", IsCorrect = false },
                new Option { OptionId = 142, QuestionId = 36, OptionText = "Baryton", IsCorrect = false },
                new Option { OptionId = 143, QuestionId = 36, OptionText = "Kontratenor", IsCorrect = false },
                new Option { OptionId = 144, QuestionId = 36, OptionText = "Tenor", IsCorrect = true },
                new Option { OptionId = 145, QuestionId = 37, OptionText = "Tomteland", IsCorrect = true },
                new Option { OptionId = 146, QuestionId = 37, OptionText = "Astrid Lindgrens Värld", IsCorrect = false },
                new Option { OptionId = 147, QuestionId = 37, OptionText = "High Chaparral", IsCorrect = false },
                new Option { OptionId = 148, QuestionId = 37, OptionText = "Sagostigen", IsCorrect = false },
                new Option { OptionId = 149, QuestionId = 38, OptionText = "Älvornas rike", IsCorrect = false },
                new Option { OptionId = 150, QuestionId = 38, OptionText = "Trollrike", IsCorrect = true },
                new Option { OptionId = 151, QuestionId = 38, OptionText = "Drakland", IsCorrect = false },
                new Option { OptionId = 152, QuestionId = 38, OptionText = "Skogstomtebyn", IsCorrect = false },
                new Option { OptionId = 153, QuestionId = 39, OptionText = "Historiska museet", IsCorrect = false },
                new Option { OptionId = 154, QuestionId = 39, OptionText = "Bohusläns museum", IsCorrect = false },
                new Option { OptionId = 155, QuestionId = 39, OptionText = "Gotlands Museum", IsCorrect = true },
                new Option { OptionId = 156, QuestionId = 39, OptionText = "Nordiska museet", IsCorrect = false },
                new Option { OptionId = 157, QuestionId = 40, OptionText = "Bronsåldern", IsCorrect = false },
                new Option { OptionId = 158, QuestionId = 40, OptionText = "Renässansen", IsCorrect = false },
                new Option { OptionId = 159, QuestionId = 40, OptionText = "Industrialiseringen", IsCorrect = false },
                new Option { OptionId = 160, QuestionId = 40, OptionText = "Järnåldern", IsCorrect = true },
                new Option { OptionId = 161, QuestionId = 41, OptionText = "Kronan", IsCorrect = true },
                new Option { OptionId = 162, QuestionId = 41, OptionText = "Vasa", IsCorrect = false },
                new Option { OptionId = 163, QuestionId = 41, OptionText = "Äpplet", IsCorrect = false },
                new Option { OptionId = 164, QuestionId = 41, OptionText = "Riksäpplet", IsCorrect = false },
                new Option { OptionId = 165, QuestionId = 42, OptionText = "1809", IsCorrect = false },
                new Option { OptionId = 166, QuestionId = 42, OptionText = "1676", IsCorrect = true },
                new Option { OptionId = 167, QuestionId = 42, OptionText = "1628", IsCorrect = false },
                new Option { OptionId = 168, QuestionId = 42, OptionText = "1718", IsCorrect = false },
                new Option { OptionId = 169, QuestionId = 43, OptionText = "Slottsskogen", IsCorrect = false },
                new Option { OptionId = 170, QuestionId = 43, OptionText = "Pildammsparken", IsCorrect = false },
                new Option { OptionId = 171, QuestionId = 43, OptionText = "Brändaholm", IsCorrect = true },
                new Option { OptionId = 172, QuestionId = 43, OptionText = "Tantolunden", IsCorrect = false },
                new Option { OptionId = 173, QuestionId = 44, OptionText = "15", IsCorrect = false },
                new Option { OptionId = 174, QuestionId = 44, OptionText = "75", IsCorrect = false },
                new Option { OptionId = 175, QuestionId = 44, OptionText = "105", IsCorrect = false },
                new Option { OptionId = 176, QuestionId = 44, OptionText = "45", IsCorrect = true },
                new Option { OptionId = 177, QuestionId = 45, OptionText = "Pär Lagerkvist", IsCorrect = true },
                new Option { OptionId = 178, QuestionId = 45, OptionText = "Tomas Tranströmer", IsCorrect = false },
                new Option { OptionId = 179, QuestionId = 45, OptionText = "Harry Martinson", IsCorrect = false },
                new Option { OptionId = 180, QuestionId = 45, OptionText = "Eyvind Johnson", IsCorrect = false },
                new Option { OptionId = 181, QuestionId = 46, OptionText = "1974", IsCorrect = false },
                new Option { OptionId = 182, QuestionId = 46, OptionText = "1951", IsCorrect = true },
                new Option { OptionId = 183, QuestionId = 46, OptionText = "1909", IsCorrect = false },
                new Option { OptionId = 184, QuestionId = 46, OptionText = "1931", IsCorrect = false },
                new Option { OptionId = 185, QuestionId = 47, OptionText = "Europe", IsCorrect = false },
                new Option { OptionId = 186, QuestionId = 47, OptionText = "The Cardigans", IsCorrect = false },
                new Option { OptionId = 187, QuestionId = 47, OptionText = "Gyllene Tider", IsCorrect = true },
                new Option { OptionId = 188, QuestionId = 47, OptionText = "ABBA", IsCorrect = false },
                new Option { OptionId = 189, QuestionId = 48, OptionText = "Joey Tempest", IsCorrect = false },
                new Option { OptionId = 190, QuestionId = 48, OptionText = "Magnus Uggla", IsCorrect = false },
                new Option { OptionId = 191, QuestionId = 48, OptionText = "Tomas Ledin", IsCorrect = false },
                new Option { OptionId = 192, QuestionId = 48, OptionText = "Per Gessle", IsCorrect = true },
                new Option { OptionId = 193, QuestionId = 49, OptionText = "Pinocchio", IsCorrect = true },
                new Option { OptionId = 194, QuestionId = 49, OptionText = "Peter Pan", IsCorrect = false },
                new Option { OptionId = 195, QuestionId = 49, OptionText = "Nalle Puh", IsCorrect = false },
                new Option { OptionId = 196, QuestionId = 49, OptionText = "Pippi Långstrump", IsCorrect = false },
                new Option { OptionId = 197, QuestionId = 50, OptionText = "Niki de Saint Phalle", IsCorrect = false },
                new Option { OptionId = 198, QuestionId = 50, OptionText = "Jim Dine", IsCorrect = true },
                new Option { OptionId = 199, QuestionId = 50, OptionText = "Carl Milles", IsCorrect = false },
                new Option { OptionId = 200, QuestionId = 50, OptionText = "Claes Oldenburg", IsCorrect = false },
                new Option { OptionId = 201, QuestionId = 51, OptionText = "Skidskytte", IsCorrect = false },
                new Option { OptionId = 202, QuestionId = 51, OptionText = "Längdskidåkning", IsCorrect = false },
                new Option { OptionId = 203, QuestionId = 51, OptionText = "Hastighetsåkning på skridskor", IsCorrect = true },
                new Option { OptionId = 204, QuestionId = 51, OptionText = "Konståkning", IsCorrect = false },
                new Option { OptionId = 205, QuestionId = 52, OptionText = "Ett", IsCorrect = false },
                new Option { OptionId = 206, QuestionId = 52, OptionText = "Tre", IsCorrect = false },
                new Option { OptionId = 207, QuestionId = 52, OptionText = "Fyra", IsCorrect = false },
                new Option { OptionId = 208, QuestionId = 52, OptionText = "Två", IsCorrect = true },
                new Option { OptionId = 209, QuestionId = 53, OptionText = "Gustafsberg", IsCorrect = true },
                new Option { OptionId = 210, QuestionId = 53, OptionText = "Marstrand", IsCorrect = false },
                new Option { OptionId = 211, QuestionId = 53, OptionText = "Lysekil", IsCorrect = false },
                new Option { OptionId = 212, QuestionId = 53, OptionText = "Fiskebäckskil", IsCorrect = false },
                new Option { OptionId = 213, QuestionId = 54, OptionText = "Universitet", IsCorrect = false },
                new Option { OptionId = 214, QuestionId = 54, OptionText = "Internatskola", IsCorrect = true },
                new Option { OptionId = 215, QuestionId = 54, OptionText = "Folkhögskola", IsCorrect = false },
                new Option { OptionId = 216, QuestionId = 54, OptionText = "Yrkeshögskola", IsCorrect = false },
                new Option { OptionId = 217, QuestionId = 55, OptionText = "Universeum", IsCorrect = false },
                new Option { OptionId = 218, QuestionId = 55, OptionText = "Teknikens Hus", IsCorrect = false },
                new Option { OptionId = 219, QuestionId = 55, OptionText = "Balthazar", IsCorrect = true },
                new Option { OptionId = 220, QuestionId = 55, OptionText = "Tom Tits Experiment", IsCorrect = false },
                new Option { OptionId = 221, QuestionId = 56, OptionText = "Juridik och ekonomi", IsCorrect = false },
                new Option { OptionId = 222, QuestionId = 56, OptionText = "Militärhistoria och heraldik", IsCorrect = false },
                new Option { OptionId = 223, QuestionId = 56, OptionText = "Arkeologi och antika språk", IsCorrect = false },
                new Option { OptionId = 224, QuestionId = 56, OptionText = "Naturvetenskap och teknik", IsCorrect = true },
                new Option { OptionId = 225, QuestionId = 57, OptionText = "ReTuna", IsCorrect = true },
                new Option { OptionId = 226, QuestionId = 57, OptionText = "Emporia", IsCorrect = false },
                new Option { OptionId = 227, QuestionId = 57, OptionText = "Nordstan", IsCorrect = false },
                new Option { OptionId = 228, QuestionId = 57, OptionText = "Kupolen", IsCorrect = false },
                new Option { OptionId = 229, QuestionId = 58, OptionText = "2020", IsCorrect = false },
                new Option { OptionId = 230, QuestionId = 58, OptionText = "2015", IsCorrect = true },
                new Option { OptionId = 231, QuestionId = 58, OptionText = "1995", IsCorrect = false },
                new Option { OptionId = 232, QuestionId = 58, OptionText = "2005", IsCorrect = false },
                new Option { OptionId = 233, QuestionId = 59, OptionText = "PUB", IsCorrect = false },
                new Option { OptionId = 234, QuestionId = 59, OptionText = "Gekås", IsCorrect = false },
                new Option { OptionId = 235, QuestionId = 59, OptionText = "Nordiska Kompaniet", IsCorrect = true },
                new Option { OptionId = 236, QuestionId = 59, OptionText = "Åhléns", IsCorrect = false },
                new Option { OptionId = 237, QuestionId = 60, OptionText = "Järnvägslok", IsCorrect = false },
                new Option { OptionId = 238, QuestionId = 60, OptionText = "Glasflaskor", IsCorrect = false },
                new Option { OptionId = 239, QuestionId = 60, OptionText = "Musikinstrument", IsCorrect = false },
                new Option { OptionId = 240, QuestionId = 60, OptionText = "Möbler och inredningar", IsCorrect = true },
                new Option { OptionId = 241, QuestionId = 61, OptionText = "Hageby Basket", IsCorrect = true },
                new Option { OptionId = 242, QuestionId = 61, OptionText = "Södertälje Kings", IsCorrect = false },
                new Option { OptionId = 243, QuestionId = 61, OptionText = "Solna Vikings", IsCorrect = false },
                new Option { OptionId = 244, QuestionId = 61, OptionText = "Alvik Basket", IsCorrect = false },
                new Option { OptionId = 245, QuestionId = 62, OptionText = "1983", IsCorrect = false },
                new Option { OptionId = 246, QuestionId = 62, OptionText = "1963", IsCorrect = true },
                new Option { OptionId = 247, QuestionId = 62, OptionText = "1913", IsCorrect = false },
                new Option { OptionId = 248, QuestionId = 62, OptionText = "1943", IsCorrect = false },
                new Option { OptionId = 249, QuestionId = 63, OptionText = "Nässjö IF och Tranås AIF", IsCorrect = false },
                new Option { OptionId = 250, QuestionId = 63, OptionText = "Skillingaryds IS och Värnamo GIK", IsCorrect = false },
                new Option { OptionId = 251, QuestionId = 63, OptionText = "Husqvarna IF och Vätterstads IF", IsCorrect = true },
                new Option { OptionId = 252, QuestionId = 63, OptionText = "IFK Jönköping och Jönköpings Södra", IsCorrect = false },
                new Option { OptionId = 253, QuestionId = 64, OptionText = "1951", IsCorrect = false },
                new Option { OptionId = 254, QuestionId = 64, OptionText = "1961", IsCorrect = false },
                new Option { OptionId = 255, QuestionId = 64, OptionText = "1981", IsCorrect = false },
                new Option { OptionId = 256, QuestionId = 64, OptionText = "1971", IsCorrect = true },
                new Option { OptionId = 257, QuestionId = 65, OptionText = "1899", IsCorrect = true },
                new Option { OptionId = 258, QuestionId = 65, OptionText = "1919", IsCorrect = false },
                new Option { OptionId = 259, QuestionId = 65, OptionText = "1939", IsCorrect = false },
                new Option { OptionId = 260, QuestionId = 65, OptionText = "1959", IsCorrect = false },
                new Option { OptionId = 261, QuestionId = 66, OptionText = "Gul", IsCorrect = false },
                new Option { OptionId = 262, QuestionId = 66, OptionText = "Orange", IsCorrect = true },
                new Option { OptionId = 263, QuestionId = 66, OptionText = "Lila", IsCorrect = false },
                new Option { OptionId = 264, QuestionId = 66, OptionText = "Grön", IsCorrect = false },
                new Option { OptionId = 265, QuestionId = 67, OptionText = "Esbjörn Svensson", IsCorrect = false },
                new Option { OptionId = 266, QuestionId = 67, OptionText = "Bengt Hallberg", IsCorrect = false },
                new Option { OptionId = 267, QuestionId = 67, OptionText = "Jan Lundgren", IsCorrect = true },
                new Option { OptionId = 268, QuestionId = 67, OptionText = "Jan Johansson", IsCorrect = false },
                new Option { OptionId = 269, QuestionId = 68, OptionText = "Trumpet", IsCorrect = false },
                new Option { OptionId = 270, QuestionId = 68, OptionText = "Saxofon", IsCorrect = false },
                new Option { OptionId = 271, QuestionId = 68, OptionText = "Trummor", IsCorrect = false },
                new Option { OptionId = 272, QuestionId = 68, OptionText = "Piano", IsCorrect = true },
                new Option { OptionId = 273, QuestionId = 69, OptionText = "Axel Ebbe", IsCorrect = true },
                new Option { OptionId = 274, QuestionId = 69, OptionText = "Carl Larsson", IsCorrect = false },
                new Option { OptionId = 275, QuestionId = 69, OptionText = "Anders Zorn", IsCorrect = false },
                new Option { OptionId = 276, QuestionId = 69, OptionText = "Isaac Grünewald", IsCorrect = false },
                new Option { OptionId = 277, QuestionId = 70, OptionText = "1985", IsCorrect = false },
                new Option { OptionId = 278, QuestionId = 70, OptionText = "1935", IsCorrect = true },
                new Option { OptionId = 279, QuestionId = 70, OptionText = "1835", IsCorrect = false },
                new Option { OptionId = 280, QuestionId = 70, OptionText = "1885", IsCorrect = false },
                new Option { OptionId = 281, QuestionId = 71, OptionText = "1935", IsCorrect = false },
                new Option { OptionId = 282, QuestionId = 71, OptionText = "1955", IsCorrect = false },
                new Option { OptionId = 283, QuestionId = 71, OptionText = "1915", IsCorrect = true },
                new Option { OptionId = 284, QuestionId = 71, OptionText = "1895", IsCorrect = false },
                new Option { OptionId = 285, QuestionId = 72, OptionText = "Landskrona IF och Olympia", IsCorrect = false },
                new Option { OptionId = 286, QuestionId = 72, OptionText = "Ven IF och BK Fram", IsCorrect = false },
                new Option { OptionId = 287, QuestionId = 72, OptionText = "Helsingborgs IF och Råå IF", IsCorrect = false },
                new Option { OptionId = 288, QuestionId = 72, OptionText = "IFK Landskrona och Diana", IsCorrect = true },
                new Option { OptionId = 289, QuestionId = 73, OptionText = "Grimeton", IsCorrect = true },
                new Option { OptionId = 290, QuestionId = 73, OptionText = "Esrange", IsCorrect = false },
                new Option { OptionId = 291, QuestionId = 73, OptionText = "Onsala", IsCorrect = false },
                new Option { OptionId = 292, QuestionId = 73, OptionText = "Motala", IsCorrect = false },
                new Option { OptionId = 293, QuestionId = 74, OptionText = "SR", IsCorrect = false },
                new Option { OptionId = 294, QuestionId = 74, OptionText = "SAQ", IsCorrect = true },
                new Option { OptionId = 295, QuestionId = 74, OptionText = "SOS", IsCorrect = false },
                new Option { OptionId = 296, QuestionId = 74, OptionText = "SVT", IsCorrect = false },
                new Option { OptionId = 297, QuestionId = 75, OptionText = "Alfred Nobel", IsCorrect = false },
                new Option { OptionId = 298, QuestionId = 75, OptionText = "Gustaf Dalén", IsCorrect = false },
                new Option { OptionId = 299, QuestionId = 75, OptionText = "John L. Skantze", IsCorrect = true },
                new Option { OptionId = 300, QuestionId = 75, OptionText = "Lars Olsson Smith", IsCorrect = false },
                new Option { OptionId = 301, QuestionId = 76, OptionText = "1796", IsCorrect = false },
                new Option { OptionId = 302, QuestionId = 76, OptionText = "1846", IsCorrect = false },
                new Option { OptionId = 303, QuestionId = 76, OptionText = "1946", IsCorrect = false },
                new Option { OptionId = 304, QuestionId = 76, OptionText = "1896", IsCorrect = true },
                new Option { OptionId = 305, QuestionId = 77, OptionText = "Åke Nordin", IsCorrect = true },
                new Option { OptionId = 306, QuestionId = 77, OptionText = "Ingvar Kamprad", IsCorrect = false },
                new Option { OptionId = 307, QuestionId = 77, OptionText = "Erling Persson", IsCorrect = false },
                new Option { OptionId = 308, QuestionId = 77, OptionText = "Bertil Hult", IsCorrect = false },
                new Option { OptionId = 309, QuestionId = 78, OptionText = "1980", IsCorrect = false },
                new Option { OptionId = 310, QuestionId = 78, OptionText = "1960", IsCorrect = true },
                new Option { OptionId = 311, QuestionId = 78, OptionText = "1920", IsCorrect = false },
                new Option { OptionId = 312, QuestionId = 78, OptionText = "1940", IsCorrect = false },
                new Option { OptionId = 313, QuestionId = 79, OptionText = "Alfred Nobel", IsCorrect = false },
                new Option { OptionId = 314, QuestionId = 79, OptionText = "Johan Petter Johansson", IsCorrect = false },
                new Option { OptionId = 315, QuestionId = 79, OptionText = "Alvar Lindmark", IsCorrect = true },
                new Option { OptionId = 316, QuestionId = 79, OptionText = "Gustaf Dalén", IsCorrect = false },
                new Option { OptionId = 317, QuestionId = 80, OptionText = "Personbilar", IsCorrect = false },
                new Option { OptionId = 318, QuestionId = 80, OptionText = "Mobiltelefoner", IsCorrect = false },
                new Option { OptionId = 319, QuestionId = 80, OptionText = "Pappersmassa", IsCorrect = false },
                new Option { OptionId = 320, QuestionId = 80, OptionText = "Industrihissar och bygghissar", IsCorrect = true }
            );

            modelBuilder.Entity<Clue>().HasData(
                new Clue { ClueId = 51, CityId = 11, Point = 10m, ClueText = "Vi reser till en stad där en stor älv möter Sveriges största sjö." },
                new Clue { ClueId = 52, CityId = 11, Point = 8m, ClueText = "Staden ligger i landskapet Värmland." },
                new Clue { ClueId = 53, CityId = 11, Point = 6m, ClueText = "Här finns Värmlands Museum och stadsdelen Haga." },
                new Clue { ClueId = 54, CityId = 11, Point = 4m, ClueText = "Klarälven delar sig i flera grenar i staden." },
                new Clue { ClueId = 55, CityId = 11, Point = 2m, ClueText = "Vi söker Värmlands residensstad vid Vänern." },
                new Clue { ClueId = 56, CityId = 12, Point = 10m, ClueText = "Vi reser till en stad med närhet till både fjäll och en stor insjö." },
                new Clue { ClueId = 57, CityId = 12, Point = 8m, ClueText = "Staden grundades år 1786." },
                new Clue { ClueId = 58, CityId = 12, Point = 6m, ClueText = "Här finns friluftsmuseet Jamtli." },
                new Clue { ClueId = 59, CityId = 12, Point = 4m, ClueText = "På andra sidan en bro ligger Frösön." },
                new Clue { ClueId = 60, CityId = 12, Point = 2m, ClueText = "Vi söker Jämtlands residensstad vid Storsjön." },
                new Clue { ClueId = 61, CityId = 13, Point = 10m, ClueText = "Vi reser till en stad där skogsindustrin har satt tydliga spår." },
                new Clue { ClueId = 62, CityId = 13, Point = 8m, ClueText = "Efter en stor brand 1888 byggdes centrum upp med många stenhus." },
                new Clue { ClueId = 63, CityId = 13, Point = 6m, ClueText = "Staden ligger i landskapet Medelpad." },
                new Clue { ClueId = 64, CityId = 13, Point = 4m, ClueText = "Centrum kallas Stenstan och ligger mellan Norra och Södra berget." },
                new Clue { ClueId = 65, CityId = 13, Point = 2m, ClueText = "Vi söker staden vid Selångersåns mynning där Birsta ligger i närheten." },
                new Clue { ClueId = 66, CityId = 14, Point = 10m, ClueText = "Vi reser till en kuststad långt uppe i Sverige." },
                new Clue { ClueId = 67, CityId = 14, Point = 8m, ClueText = "Här finns ett tekniskt universitet." },
                new Clue { ClueId = 68, CityId = 14, Point = 6m, ClueText = "Gammelstads kyrkstad i kommunen är ett världsarv." },
                new Clue { ClueId = 69, CityId = 14, Point = 4m, ClueText = "Staden ligger vid Luleälvens mynning." },
                new Clue { ClueId = 70, CityId = 14, Point = 2m, ClueText = "Vi söker Norrbottens residensstad." },
                new Clue { ClueId = 71, CityId = 15, Point = 10m, ClueText = "Vi reser till en stad norr om polcirkeln." },
                new Clue { ClueId = 72, CityId = 15, Point = 8m, ClueText = "Gruvdriften har gjort att delar av staden har behövt flyttas." },
                new Clue { ClueId = 73, CityId = 15, Point = 6m, ClueText = "Här bryter LKAB järnmalm." },
                new Clue { ClueId = 74, CityId = 15, Point = 4m, ClueText = "I närliggande Jukkasjärvi finns ett känt ishotell." },
                new Clue { ClueId = 75, CityId = 15, Point = 2m, ClueText = "Vi söker gruvstaden vid berget Kiirunavaara." },
                new Clue { ClueId = 76, CityId = 16, Point = 10m, ClueText = "Vi reser till en kuststad med lång sjöfartshistoria." },
                new Clue { ClueId = 77, CityId = 16, Point = 8m, ClueText = "Här finns Sveriges Järnvägsmuseum." },
                new Clue { ClueId = 78, CityId = 16, Point = 6m, ClueText = "Gavleån rinner genom staden." },
                new Clue { ClueId = 79, CityId = 16, Point = 4m, ClueText = "En stor julbock av halm har blivit stadens välkända symbol." },
                new Clue { ClueId = 80, CityId = 16, Point = 2m, ClueText = "Vi söker Gästriklands stad som gett namn åt Gävlebocken." },
                new Clue { ClueId = 81, CityId = 17, Point = 10m, ClueText = "Vi reser till en stad där gruvhistorien präglar både marken och husens färg." },
                new Clue { ClueId = 82, CityId = 17, Point = 8m, ClueText = "Staden ligger i Dalarna." },
                new Clue { ClueId = 83, CityId = 17, Point = 6m, ClueText = "Här finns skidområdet Lugnet." },
                new Clue { ClueId = 84, CityId = 17, Point = 4m, ClueText = "Den stora koppargruvan är en del av ett världsarv." },
                new Clue { ClueId = 85, CityId = 17, Point = 2m, ClueText = "Vi söker staden som gett namn åt Falu rödfärg." },
                new Clue { ClueId = 86, CityId = 18, Point = 10m, ClueText = "Vi reser till en stad där järnväg och industri haft stor betydelse." },
                new Clue { ClueId = 87, CityId = 18, Point = 8m, ClueText = "Staden ligger i Dalarna." },
                new Clue { ClueId = 88, CityId = 18, Point = 6m, ClueText = "Här finns köpcentrumet Kupolen." },
                new Clue { ClueId = 89, CityId = 18, Point = 4m, ClueText = "Dalälven rinner genom staden och Romme Alpin ligger i närheten." },
                new Clue { ClueId = 90, CityId = 18, Point = 2m, ClueText = "Vi söker dalastaden söder om Falun." },
                new Clue { ClueId = 91, CityId = 19, Point = 10m, ClueText = "Vi reser till en stad där konst och skidåkning möts." },
                new Clue { ClueId = 92, CityId = 19, Point = 8m, ClueText = "Staden ligger i Dalarna vid Siljan." },
                new Clue { ClueId = 93, CityId = 19, Point = 6m, ClueText = "Konstnären Anders Zorn bodde här." },
                new Clue { ClueId = 94, CityId = 19, Point = 4m, ClueText = "Hit går målgången i Vasaloppet." },
                new Clue { ClueId = 95, CityId = 19, Point = 2m, ClueText = "Vi söker orten där skidåkarna går i mål efter starten i Sälen." },
                new Clue { ClueId = 96, CityId = 20, Point = 10m, ClueText = "Vi reser till en stad på en ö i Östersjön." },
                new Clue { ClueId = 97, CityId = 20, Point = 8m, ClueText = "Staden har en stark medeltida prägel." },
                new Clue { ClueId = 98, CityId = 20, Point = 6m, ClueText = "Här arrangeras Almedalsveckan." },
                new Clue { ClueId = 99, CityId = 20, Point = 4m, ClueText = "En välbevarad ringmur omger stora delar av den äldre staden." },
                new Clue { ClueId = 100, CityId = 20, Point = 2m, ClueText = "Vi söker Gotlands största stad." },
                new Clue { ClueId = 101, CityId = 21, Point = 10m, ClueText = "Vi reser till en kuststad med ett välkänt renässansslott." },
                new Clue { ClueId = 102, CityId = 21, Point = 8m, ClueText = "En union mellan nordiska riken har fått sitt namn efter staden." },
                new Clue { ClueId = 103, CityId = 21, Point = 6m, ClueText = "Staden ligger i Småland." },
                new Clue { ClueId = 104, CityId = 21, Point = 4m, ClueText = "Härifrån går Ölandsbron över Kalmarsund." },
                new Clue { ClueId = 105, CityId = 21, Point = 2m, ClueText = "Vi söker staden med Kalmar slott." },
                new Clue { ClueId = 106, CityId = 22, Point = 10m, ClueText = "Vi reser till en stad som anlades som en flottbas." },
                new Clue { ClueId = 107, CityId = 22, Point = 8m, ClueText = "Staden grundades år 1680." },
                new Clue { ClueId = 108, CityId = 22, Point = 6m, ClueText = "Örlogsstaden finns på världsarvslistan." },
                new Clue { ClueId = 109, CityId = 22, Point = 4m, ClueText = "Här finns Marinmuseum på Stumholmen." },
                new Clue { ClueId = 110, CityId = 22, Point = 2m, ClueText = "Vi söker Blekinges residensstad i skärgården." },
                new Clue { ClueId = 111, CityId = 23, Point = 10m, ClueText = "Vi reser till en stad omgiven av sjöar och småländska skogar." },
                new Clue { ClueId = 112, CityId = 23, Point = 8m, ClueText = "Här finns Sveriges glasmuseum." },
                new Clue { ClueId = 113, CityId = 23, Point = 6m, ClueText = "Staden har en domkyrka med två höga spiror." },
                new Clue { ClueId = 114, CityId = 23, Point = 4m, ClueText = "Här finns en del av Linnéuniversitetet." },
                new Clue { ClueId = 115, CityId = 23, Point = 2m, ClueText = "Vi söker Kronobergs läns residensstad." },
                new Clue { ClueId = 116, CityId = 24, Point = 10m, ClueText = "Vi reser till en kuststad där en å möter havet." },
                new Clue { ClueId = 117, CityId = 24, Point = 8m, ClueText = "Staden ligger i Halland." },
                new Clue { ClueId = 118, CityId = 24, Point = 6m, ClueText = "Här finns konstverket Europa och tjuren på Stora torg." },
                new Clue { ClueId = 119, CityId = 24, Point = 4m, ClueText = "Nissan rinner genom staden och Tylösand ligger i närheten." },
                new Clue { ClueId = 120, CityId = 24, Point = 2m, ClueText = "Vi söker Hallands residensstad." },
                new Clue { ClueId = 121, CityId = 25, Point = 10m, ClueText = "Vi reser till en stad som är starkt förknippad med textil och handel." },
                new Clue { ClueId = 122, CityId = 25, Point = 8m, ClueText = "Staden ligger i Västergötland." },
                new Clue { ClueId = 123, CityId = 25, Point = 6m, ClueText = "Här finns Textilmuseet och en textilhögskola." },
                new Clue { ClueId = 124, CityId = 25, Point = 4m, ClueText = "Viskan rinner genom staden, som också har en djurpark." },
                new Clue { ClueId = 125, CityId = 25, Point = 2m, ClueText = "Vi söker textilstaden öster om Göteborg." },
                new Clue { ClueId = 126, CityId = 26, Point = 10m, ClueText = "Vi reser till en stad där vattenkraft och industri möts." },
                new Clue { ClueId = 127, CityId = 26, Point = 8m, ClueText = "Här har Saab tillverkat bilar." },
                new Clue { ClueId = 128, CityId = 26, Point = 6m, ClueText = "Staden är också känd för filmproduktion." },
                new Clue { ClueId = 129, CityId = 26, Point = 4m, ClueText = "Göta älv, slussarna och fallen är viktiga delar av stadens historia." },
                new Clue { ClueId = 130, CityId = 26, Point = 2m, ClueText = "Vi söker staden som gett namn åt Trollhättefallen." },
                new Clue { ClueId = 131, CityId = 27, Point = 10m, ClueText = "Vi reser till en stad i Bohuslän." },
                new Clue { ClueId = 132, CityId = 27, Point = 8m, ClueText = "Här finns Bohusläns museum." },
                new Clue { ClueId = 133, CityId = 27, Point = 6m, ClueText = "Staden ligger vid Byfjorden." },
                new Clue { ClueId = 134, CityId = 27, Point = 4m, ClueText = "En välkänd bro över fjorden har samma namn som staden." },
                new Clue { ClueId = 135, CityId = 27, Point = 2m, ClueText = "Vi söker staden med Uddevallabron." },
                new Clue { ClueId = 136, CityId = 28, Point = 10m, ClueText = "Vi reser till en stad där industri och militär verksamhet har stor betydelse." },
                new Clue { ClueId = 137, CityId = 28, Point = 8m, ClueText = "Staden ligger i Västergötland." },
                new Clue { ClueId = 138, CityId = 28, Point = 6m, ClueText = "Här finns en högskola med utbildningar inom bland annat spelutveckling." },
                new Clue { ClueId = 139, CityId = 28, Point = 4m, ClueText = "Platåberget Billingen ligger intill staden." },
                new Clue { ClueId = 140, CityId = 28, Point = 2m, ClueText = "Vi söker staden öster om Billingen, mellan Skara och Tibro." },
                new Clue { ClueId = 141, CityId = 29, Point = 10m, ClueText = "Vi reser till en stad med lång tradition av metallhantverk." },
                new Clue { ClueId = 142, CityId = 29, Point = 8m, ClueText = "Här finns Rademachersmedjorna." },
                new Clue { ClueId = 143, CityId = 29, Point = 6m, ClueText = "Staden ligger i Södermanland." },
                new Clue { ClueId = 144, CityId = 29, Point = 4m, ClueText = "Parken Zoo och Eskilstunaån är välkända inslag." },
                new Clue { ClueId = 145, CityId = 29, Point = 2m, ClueText = "Vi söker staden som har fått sitt namn efter helgonet Eskil." },
                new Clue { ClueId = 146, CityId = 30, Point = 10m, ClueText = "Vi reser till en stad där ett medeltida gästabud fick ett dramatiskt slut." },
                new Clue { ClueId = 147, CityId = 30, Point = 8m, ClueText = "Staden ligger i Södermanland." },
                new Clue { ClueId = 148, CityId = 30, Point = 6m, ClueText = "Nyköpingsån rinner genom staden." },
                new Clue { ClueId = 149, CityId = 30, Point = 4m, ClueText = "Här finns slottsruinen Nyköpingshus." },
                new Clue { ClueId = 150, CityId = 30, Point = 2m, ClueText = "Vi söker staden som gett namn åt Nyköpings gästabud." },
                new Clue { ClueId = 151, CityId = 31, Point = 10m, ClueText = "Vi reser till en stad vars centrum berättar om textilindustrins historia." },
                new Clue { ClueId = 152, CityId = 31, Point = 8m, ClueText = "Staden ligger i Östergötland." },
                new Clue { ClueId = 153, CityId = 31, Point = 6m, ClueText = "Här finns Industrilandskapet och Arbetets museum." },
                new Clue { ClueId = 154, CityId = 31, Point = 4m, ClueText = "Motala ström rinner genom staden." },
                new Clue { ClueId = 155, CityId = 31, Point = 2m, ClueText = "Vi söker staden där museibyggnaden Strykjärnet står i strömmen." },
                new Clue { ClueId = 156, CityId = 32, Point = 10m, ClueText = "Vi reser till en stad där handel och tillverkning har en lång historia." },
                new Clue { ClueId = 157, CityId = 32, Point = 8m, ClueText = "Här finns Tändsticksmuseet." },
                new Clue { ClueId = 158, CityId = 32, Point = 6m, ClueText = "Mässområdet Elmia ligger här." },
                new Clue { ClueId = 159, CityId = 32, Point = 4m, ClueText = "Staden ligger vid Vätterns södra spets." },
                new Clue { ClueId = 160, CityId = 32, Point = 2m, ClueText = "Vi söker den småländska staden intill Huskvarna." },
                new Clue { ClueId = 161, CityId = 33, Point = 10m, ClueText = "Vi reser till en stad grundad av en dansk kung." },
                new Clue { ClueId = 162, CityId = 33, Point = 8m, ClueText = "Staden grundades av Kristian IV år 1614." },
                new Clue { ClueId = 163, CityId = 33, Point = 6m, ClueText = "Helge å rinner genom staden." },
                new Clue { ClueId = 164, CityId = 33, Point = 4m, ClueText = "Här finns biosfärområdet Kristianstads Vattenrike." },
                new Clue { ClueId = 165, CityId = 33, Point = 2m, ClueText = "Vi söker den skånska staden med Heliga Trefaldighets kyrka." },
                new Clue { ClueId = 166, CityId = 34, Point = 10m, ClueText = "Vi reser till en stad vid Sveriges sydkust." },
                new Clue { ClueId = 167, CityId = 34, Point = 8m, ClueText = "Staden är känd för sina korsvirkeshus." },
                new Clue { ClueId = 168, CityId = 34, Point = 6m, ClueText = "Härifrån går färjor till bland annat Bornholm." },
                new Clue { ClueId = 169, CityId = 34, Point = 4m, ClueText = "Henning Mankells berättelser om Kurt Wallander utspelar sig här." },
                new Clue { ClueId = 170, CityId = 34, Point = 2m, ClueText = "Vi söker den skånska staden där Wallander arbetar." },
                new Clue { ClueId = 171, CityId = 35, Point = 10m, ClueText = "Vi reser till en hamnstad på Skånes sydkust." },
                new Clue { ClueId = 172, CityId = 35, Point = 8m, ClueText = "Staden har färjeförbindelser med kontinenten." },
                new Clue { ClueId = 173, CityId = 35, Point = 6m, ClueText = "Här finns en rekonstruerad vikingaborg." },
                new Clue { ClueId = 174, CityId = 35, Point = 4m, ClueText = "Palmer har blivit ett välkänt inslag i stadens sommarbild." },
                new Clue { ClueId = 175, CityId = 35, Point = 2m, ClueText = "Vi söker Sveriges sydligaste stad." },
                new Clue { ClueId = 176, CityId = 36, Point = 10m, ClueText = "Vi reser till en stad vid Öresund." },
                new Clue { ClueId = 177, CityId = 36, Point = 8m, ClueText = "Här finns ett välbevarat citadell omgivet av vallgravar." },
                new Clue { ClueId = 178, CityId = 36, Point = 6m, ClueText = "Författaren Selma Lagerlöf arbetade som lärare här." },
                new Clue { ClueId = 179, CityId = 36, Point = 4m, ClueText = "Från staden går båtar till Ven." },
                new Clue { ClueId = 180, CityId = 36, Point = 2m, ClueText = "Vi söker den skånska staden med Landskrona citadell." },
                new Clue { ClueId = 181, CityId = 37, Point = 10m, ClueText = "Vi reser till en kuststad med en lång tradition av bad och kurorter." },
                new Clue { ClueId = 182, CityId = 37, Point = 8m, ClueText = "Staden ligger i Halland." },
                new Clue { ClueId = 183, CityId = 37, Point = 6m, ClueText = "Här finns ett välkänt kallbadhus." },
                new Clue { ClueId = 184, CityId = 37, Point = 4m, ClueText = "En stor fästning ligger vid havet och inrymmer Bockstensmannen." },
                new Clue { ClueId = 185, CityId = 37, Point = 2m, ClueText = "Vi söker den halländska staden med Varbergs fästning." },
                new Clue { ClueId = 186, CityId = 38, Point = 10m, ClueText = "Vi reser till en kuststad där en gammal stenbro korsar en å." },
                new Clue { ClueId = 187, CityId = 38, Point = 8m, ClueText = "Staden ligger i Halland." },
                new Clue { ClueId = 188, CityId = 38, Point = 6m, ClueText = "Den välkända bron heter Tullbron." },
                new Clue { ClueId = 189, CityId = 38, Point = 4m, ClueText = "Ätran rinner genom staden och Skrea strand ligger i närheten." },
                new Clue { ClueId = 190, CityId = 38, Point = 2m, ClueText = "Vi söker den halländska staden mellan Varberg och Halmstad." },
                new Clue { ClueId = 191, CityId = 39, Point = 10m, ClueText = "Vi reser till en kuststad i norra Sverige." },
                new Clue { ClueId = 192, CityId = 39, Point = 8m, ClueText = "Staden ligger i landskapet Ångermanland." },
                new Clue { ClueId = 193, CityId = 39, Point = 6m, ClueText = "Här har ishockeyklubben Modo sitt hem." },
                new Clue { ClueId = 194, CityId = 39, Point = 4m, ClueText = "Staden har fått sitt namn efter landshövdingen Per Abraham Örnsköld." },
                new Clue { ClueId = 195, CityId = 39, Point = 2m, ClueText = "Vi söker staden som ofta kallas Ö-vik." },
                new Clue { ClueId = 196, CityId = 40, Point = 10m, ClueText = "Vi reser till en stad där träbyggande och industri möts." },
                new Clue { ClueId = 197, CityId = 40, Point = 8m, ClueText = "Här finns kyrkstaden Bonnstan." },
                new Clue { ClueId = 198, CityId = 40, Point = 6m, ClueText = "Sara kulturhus är uppkallat efter författaren Sara Lidman." },
                new Clue { ClueId = 199, CityId = 40, Point = 4m, ClueText = "Skellefteälven rinner genom staden." },
                new Clue { ClueId = 200, CityId = 40, Point = 2m, ClueText = "Vi söker den västerbottniska stad som har gett namn åt Skellefteå AIK." }
            );

            modelBuilder.Entity<Achievement>().HasData(
                new Achievement { AchievementId = 1, Name = "Nyfiken resenär", Description = "Uppnå en streak av minst 3 dagar."},
                new Achievement { AchievementId = 2, Name = "Veckopendlare", Description = "Uppnå en streak av minst 7 dagar."},
                new Achievement { AchievementId = 3, Name = "Stadsälskare", Description = "Uppnå en streak av minst 14 dagar."},
                new Achievement { AchievementId = 4, Name = "Månadskort", Description = "uppnå en streak av minst 31 dagar."},
                new Achievement { AchievementId = 5, Name = "Rutinerad resenär", Description = "Uppnå en streak av minst 50 dagar." },
                new Achievement { AchievementId = 6, Name = "Sverige runt på 80 dagar", Description = "Uppnå en streak av minst 80 dagar." },
                new Achievement { AchievementId = 7, Name = "100% resglädje", Description = "Uppnå en streak av minst 100 dagar." },
                new Achievement { AchievementId = 8, Name = "Lokföraraspirant", Description = "Uppnå en streak av minst 140 dagar." },
                new Achievement { AchievementId = 9, Name = "Halvårskort", Description = "Uppnå en streak av minst 180 dagar." },
                new Achievement { AchievementId = 10, Name = "Går som tåget", Description = "Uppnå en streak av minst 250 dagar." },
                new Achievement { AchievementId = 11, Name = "Årskort", Description = "Uppnå en streak av minst 365 dagar." },
                new Achievement { AchievementId = 13, Name = "Biljettkontroll", Description = "Registrera ett konto." },
                new Achievement { AchievementId = 14, Name = "Resvana 1", Description = "Tjäna minst 100 poäng totalt." },
                new Achievement { AchievementId = 15, Name = "Resvana 2", Description = "Tjäna minst 500 poäng totalt." },
                new Achievement { AchievementId = 16, Name = "ResVasa 3", Description = "Tjäna minst 1000 poäng totalt." },
                new Achievement { AchievementId = 17, Name = "Mora Träsk och Vasaloppet", Description = "Besök Mora" }
            );
        }
    }
}