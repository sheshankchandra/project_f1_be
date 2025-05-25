namespace project_f1_be.DTOs
{
    public class DriverResultDto
    {
        public required string DriverName { get; set; }
        public string Nationality { get; set; }
        public DateOnly DateOfBirth { get; set; }
        public DateOnly? DateOfDeath { get; set; }
        public int Age { get; set; }

        public string CurrentTeam { get; set; }
        public string? CurrentDriverNumber { get; set; }
        public int DebutYear { get; set; }
        public int LastSeasonYear { get; set; }
        public RaceResultDto FirstRace { get; set; }
        public RaceResultDto LatestRace { get; set; }

        public List<TeamDto> Teams { get; set; }
        public List<int> DriverNumbers { get; set; }

        public int ChampionshipsWon { get; set; }

        public List<RaceResultDto> RacesData { get; set; }
    }
}
