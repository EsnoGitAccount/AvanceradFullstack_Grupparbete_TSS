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
                new City { CityId = 1, Name = "Stockholm" },
                new City { CityId = 2, Name = "Göteborg" },
                new City { CityId = 3, Name = "Malmö" },
                new City { CityId = 4, Name = "Uppsala" },
                new City { CityId = 5, Name = "Västerås" },
                new City { CityId = 6, Name = "Örebro" },
                new City { CityId = 7, Name = "Linköping" },
                new City { CityId = 8, Name = "Helsingborg" },
                new City { CityId = 9, Name = "Umeå" },
                new City { CityId = 10, Name = "Lund" }
            );

            // DAGENS UTMANING, skräpdata, deletea när challenge kan randomiseras

            modelBuilder.Entity<DailyChallange>().HasData(
                new DailyChallange { DailyChallangeId = 1, CityId = 1, ChallangeDate = new DateOnly(2024, 6, 1) },
                new DailyChallange { DailyChallangeId = 2, CityId = 2, ChallangeDate = new DateOnly(2024, 6, 2) },
                new DailyChallange { DailyChallangeId = 3, CityId = 3, ChallangeDate = new DateOnly(2024, 6, 3) },
                new DailyChallange { DailyChallangeId = 4, CityId = 4, ChallangeDate = new DateOnly(2024, 6, 4) },
                new DailyChallange { DailyChallangeId = 5, CityId = 5, ChallangeDate = new DateOnly(2024, 6, 5) },
                new DailyChallange { DailyChallangeId = 6, CityId = 6, ChallangeDate = new DateOnly(2024, 6, 6) },
                new DailyChallange { DailyChallangeId = 7, CityId = 7, ChallangeDate = new DateOnly(2024, 6, 7) },
                new DailyChallange { DailyChallangeId = 8, CityId = 8, ChallangeDate = new DateOnly(2024, 6, 8) },
                new DailyChallange { DailyChallangeId = 9, CityId = 9, ChallangeDate = new DateOnly(2024, 6, 9) },
                new DailyChallange { DailyChallangeId = 10, CityId = 10, ChallangeDate = new DateOnly(2024, 6, 10) }
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
                    QuestionText = "Vilken dansk stad förbinder Öresundsbron Malmö med?"
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
                new Option { OptionId = 21, QuestionId = 6, OptionText = "Århus", IsCorrect = false },
                new Option { OptionId = 22, QuestionId = 6, OptionText = "Köpenhamn", IsCorrect = true },
                new Option { OptionId = 23, QuestionId = 6, OptionText = "Odense", IsCorrect = false },
                new Option { OptionId = 24, QuestionId = 6, OptionText = "Ålborg", IsCorrect = false },

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
                new Clue { ClueId = 1, CityId = 1, Point = 10m, ClueName = "Vi reser till en stad mellan en stor insjö och Östersjön." },
                new Clue { ClueId = 2, CityId = 1, Point = 8m, ClueName = "Här finns en kunglig bostad och byggnaden där Nobelbanketten hålls." },
                new Clue { ClueId = 3, CityId = 1, Point = 6m, ClueName = "Ett välbevarat krigsskepp från 1600-talet finns på ett museum här." },
                new Clue { ClueId = 4, CityId = 1, Point = 4m, ClueName = "Gamla stan och Djurgården är välkända delar av staden." },
                new Clue { ClueId = 5, CityId = 1, Point = 2m, ClueName = "Vi söker Sveriges huvudstad." },

                // Göteborg
                new Clue { ClueId = 6, CityId = 2, Point = 10m, ClueName = "Vi reser till en stad vid västkusten med en lång sjöfartshistoria." },
                new Clue { ClueId = 7, CityId = 2, Point = 8m, ClueName = "Staden grundades av Gustav II Adolf år 1621." },
                new Clue { ClueId = 8, CityId = 2, Point = 6m, ClueName = "Här finns Avenyn och Feskekörka." },
                new Clue { ClueId = 9, CityId = 2, Point = 4m, ClueName = "Nöjesparken Liseberg ligger här." },
                new Clue { ClueId = 10, CityId = 2, Point = 2m, ClueName = "Vi söker Sveriges näst största stad, vid Göta älvs mynning." },

                // Malmö
                new Clue { ClueId = 11, CityId = 3, Point = 10m, ClueName = "Vi reser till en stad i ett landskap som länge tillhörde Danmark." },
                new Clue { ClueId = 12, CityId = 3, Point = 8m, ClueName = "Här finns både ett gammalt slott och en vriden skyskrapa." },
                new Clue { ClueId = 13, CityId = 3, Point = 6m, ClueName = "Staden har en broförbindelse över Öresund till Danmark." },
                new Clue { ClueId = 14, CityId = 3, Point = 4m, ClueName = "År 2024 stod staden värd för Eurovision Song Contest" },
                new Clue { ClueId = 15, CityId = 3, Point = 2m, ClueName = "Vi söker Skånes största stad." },

                // Uppsala
                new Clue { ClueId = 16, CityId = 4, Point = 10m, ClueName = "Vi reser till en stad där vetenskap och kyrkohistoria möts." },
                new Clue { ClueId = 17, CityId = 4, Point = 8m, ClueName = "Carl von Linné bodde och arbetade här." },
                new Clue { ClueId = 18, CityId = 4, Point = 6m, ClueName = "Stadens universitet grundades år 1477." },
                new Clue { ClueId = 19, CityId = 4, Point = 4m, ClueName = "Fyrisån rinner genom staden, som har en stor domkyrka." },
                new Clue { ClueId = 20, CityId = 4, Point = 2m, ClueName = "Vi söker universitetsstaden norr om Stockholm." },

                // Västerås
                new Clue { ClueId = 21, CityId = 5, Point = 10m, ClueName = "Här finns både gravhögen Anundshög och det obskyra lilla Utter Inn" },
                new Clue { ClueId = 22, CityId = 5, Point = 8m, ClueName = "Staden har en lång historia inom svensk elektroteknisk industri." },
                new Clue { ClueId = 23, CityId = 5, Point = 6m, ClueName = "I staden ligger Erik XIV begravd, i en för kort sarkofag, varför hans fötter fick huggas av" },
                new Clue { ClueId = 24, CityId = 5, Point = 4m, ClueName = "Staden har en vänskaplig rivalitet med Örebro" },
                new Clue { ClueId = 25, CityId = 5, Point = 2m, ClueName = "Vi söker staden som ofta kallas Gurkstaden, eller pulverstaden." },

                // Örebro
                new Clue { ClueId = 26, CityId = 6, Point = 10m, ClueName = "Vår resa går till en stad mitt i det så kallade gnällbätet." },
                new Clue { ClueId = 27, CityId = 6, Point = 8m, ClueName = "Här finns ett välkänt vattentorn som också är ett besöksmål." },
                new Clue { ClueId = 28, CityId = 6, Point = 6m, ClueName = "Svartån rinner genom stadens centrum." },
                new Clue { ClueId = 29, CityId = 6, Point = 4m, ClueName = "Mitt i staden ligger ett slott på en ö." },
                new Clue { ClueId = 30, CityId = 6, Point = 2m, ClueName = "Staden hyser besöksmålet Wadköping" },

                // Linköping
                new Clue { ClueId = 31, CityId = 7, Point = 10m, ClueName = "Vi reser till en universitetsstad i sydöstra Sverige." },
                new Clue { ClueId = 32, CityId = 7, Point = 8m, ClueName = "Staden är känd för ett stort konvent tillägnat Japansk kultur." },
                new Clue { ClueId = 33, CityId = 7, Point = 6m, ClueName = "I luften över staden flyger tidvis Gripar, men Drakarna är sedan länge borta." },
                new Clue { ClueId = 34, CityId = 7, Point = 4m, ClueName = "Staden huserar den näst största kyrkan i Sverige." },
                new Clue { ClueId = 35, CityId = 7, Point = 2m, ClueName = "Staden slogan är den klämchecka ''Där ideér blir verklighet''." },

                // Helsingborg
                new Clue { ClueId = 36, CityId = 8, Point = 10m, ClueName = "Vi reser till en stad vid vattnet i Södra Sverige." },
                new Clue { ClueId = 37, CityId = 8, Point = 8m, ClueName = "Här finns slottet Sofiero med sina trädgårdar." },
                new Clue { ClueId = 38, CityId = 8, Point = 6m, ClueName = "Från staden går färjor till Danmark." },
                new Clue { ClueId = 39, CityId = 8, Point = 4m, ClueName = "Det medeltida tornet Kärnan ligger i staden." },
                new Clue { ClueId = 40, CityId = 8, Point = 2m, ClueName = "Staden kallas ibland för ''Sundets Pärla''" },

                // Umeå
                new Clue { ClueId = 41, CityId = 9, Point = 10m, ClueName = "Vi reser till en stad i norra Sverige, iblan kallad ''Norra Sveriges Huvudstad''." },
                new Clue { ClueId = 42, CityId = 9, Point = 8m, ClueName = "Efter en stor brand 1888 planterades många träd här." },
                new Clue { ClueId = 43, CityId = 9, Point = 6m, ClueName = "Staden var Europas kulturhuvudstad år 2014." },
                new Clue { ClueId = 44, CityId = 9, Point = 4m, ClueName = "I staden finns ett univeristet." },
                new Clue { ClueId = 45, CityId = 9, Point = 2m, ClueName = "Staden kallas ibland för ''Nordens Kulturhuvudstad''" },

                // Lund
                new Clue { ClueId = 46, CityId = 10, Point = 10m, ClueName = "Vi reser till en skånsk stad med en lång akademisk historia." },
                new Clue { ClueId = 47, CityId = 10, Point = 8m, ClueName = "Universitetet här grundades år 1666." },
                new Clue { ClueId = 48, CityId = 10, Point = 6m, ClueName = "Staden har en medeltida domkyrka med ett astronomiskt ur." },
                new Clue { ClueId = 49, CityId = 10, Point = 4m, ClueName = "Friluftsmuseet Kulturen finns i denna stad." },
                new Clue { ClueId = 50, CityId = 10, Point = 2m, ClueName = "Staden är en av Sveriges äldsta, och grundades år 990." }
            );
        }
    }
}