namespace Backend.Model
{
    public class Question
    {
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }

        public int CityId { get; set; }
        public City City { get; set; } = null!;
    }
}
