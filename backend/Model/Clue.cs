namespace Backend.Model
{
    public class Clue
    {
        public int ClueId { get; set; }
        public string ClueName { get; set; }
        public int Point { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
