using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonDriver
{
    public int Year { get; set; }

    public string DriverId { get; set; } = null!;

    public int? PositionNumber { get; set; }

    public string? PositionText { get; set; }

    public int? BestStartingGridPosition { get; set; }

    public int? BestRaceResult { get; set; }

    public int TotalRaceEntries { get; set; }

    public int TotalRaceStarts { get; set; }

    public int TotalRaceWins { get; set; }

    public int TotalRaceLaps { get; set; }

    public int TotalPodiums { get; set; }

    public int TotalPoints { get; set; }

    public int TotalPolePositions { get; set; }

    public int TotalFastestLaps { get; set; }

    public int TotalDriverOfTheDay { get; set; }

    public int TotalGrandSlams { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}
