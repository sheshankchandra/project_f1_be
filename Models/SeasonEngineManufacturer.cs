﻿using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonEngineManufacturer
{
    public int Year { get; set; }

    public string EngineManufacturerId { get; set; } = null!;

    public int? PositionNumber { get; set; }

    public string? PositionText { get; set; }

    public int? BestStartingGridPosition { get; set; }

    public int? BestRaceResult { get; set; }

    public int TotalRaceEntries { get; set; }

    public int TotalRaceStarts { get; set; }

    public int TotalRaceWins { get; set; }

    public int TotalRaceLaps { get; set; }

    public int TotalPodiums { get; set; }

    public int TotalPodiumRaces { get; set; }

    public int TotalPoints { get; set; }

    public int TotalPolePositions { get; set; }

    public int TotalFastestLaps { get; set; }

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}