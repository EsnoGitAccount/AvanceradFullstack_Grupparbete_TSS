namespace Backend.Model
{
    public class Clue
    {
        public int ClueId { get; set; }
        public string ClueText { get; set; }
        public decimal Point { get; set; }
        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
