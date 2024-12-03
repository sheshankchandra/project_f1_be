using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Race
{
    public int Id { get; set; }

    public int Year { get; set; }

    public int Round { get; set; }

    public DateOnly Date { get; set; }

    public string? Time { get; set; }

    public string GrandPrixId { get; set; } = null!;

    public string OfficialName { get; set; } = null!;

    public string QualifyingFormat { get; set; } = null!;

    public string? SprintQualifyingFormat { get; set; }

    public string CircuitId { get; set; } = null!;

    public string CircuitType { get; set; } = null!;

    public decimal CourseLength { get; set; }

    public int Laps { get; set; }

    public decimal Distance { get; set; }

    public int? ScheduledLaps { get; set; }

    public decimal? ScheduledDistance { get; set; }

    public DateTime? PreQualifyingDate { get; set; }

    public string? PreQualifyingTime { get; set; }

    public DateOnly? FreePractice1Date { get; set; }

    public string? FreePractice1Time { get; set; }

    public DateOnly? FreePractice2Date { get; set; }

    public string? FreePractice2Time { get; set; }

    public DateOnly? FreePractice3Date { get; set; }

    public string? FreePractice3Time { get; set; }

    public DateTime? FreePractice4Date { get; set; }

    public string? FreePractice4Time { get; set; }

    public DateTime? Qualifying1Date { get; set; }

    public string? Qualifying1Time { get; set; }

    public DateTime? Qualifying2Date { get; set; }

    public string? Qualifying2Time { get; set; }

    public DateOnly? QualifyingDate { get; set; }

    public string? QualifyingTime { get; set; }

    public DateOnly? SprintQualifyingDate { get; set; }

    public string? SprintQualifyingTime { get; set; }

    public DateOnly? SprintRaceDate { get; set; }

    public string? SprintRaceTime { get; set; }

    public DateTime? WarmingUpDate { get; set; }

    public string? WarmingUpTime { get; set; }

    public virtual Circuit Circuit { get; set; } = null!;

    public virtual GrandPrix GrandPrix { get; set; } = null!;

    public virtual ICollection<RaceConstructorStanding> RaceConstructorStandings { get; set; } = new List<RaceConstructorStanding>();

    public virtual ICollection<RaceDatum> RaceData { get; set; } = new List<RaceDatum>();

    public virtual ICollection<RaceDriverStanding> RaceDriverStandings { get; set; } = new List<RaceDriverStanding>();

    public virtual Season YearNavigation { get; set; } = null!;
}
