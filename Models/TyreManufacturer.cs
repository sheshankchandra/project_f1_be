using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class TyreManufacturer
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CountryId { get; set; } = null!;

    public int? BestStartingGridPosition { get; set; }

    public int? BestRaceResult { get; set; }

    public int TotalRaceEntries { get; set; }

    public int TotalRaceStarts { get; set; }

    public int TotalRaceWins { get; set; }

    public int TotalRaceLaps { get; set; }

    public int TotalPodiums { get; set; }

    public int TotalPodiumRaces { get; set; }

    public int TotalPolePositions { get; set; }

    public int TotalFastestLaps { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<RaceDatum> RaceData { get; set; } = new List<RaceDatum>();

    public virtual ICollection<SeasonEntrantTyreManufacturer> SeasonEntrantTyreManufacturers { get; set; } = new List<SeasonEntrantTyreManufacturer>();

    public virtual ICollection<SeasonTyreManufacturer> SeasonTyreManufacturers { get; set; } = new List<SeasonTyreManufacturer>();
}
