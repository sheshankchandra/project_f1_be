namespace project_f1_be.DTOs
{
    public class RaceResultDto
    {
        public int RaceId { get; set; }
        public int SeasonYear { get; set; }
        public DateOnly RaceDate { get; set; }
        public string RaceName { get; set; }
        public int? Position { get; set; }
    }
}
