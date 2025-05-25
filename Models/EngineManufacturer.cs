using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class EngineManufacturer
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string CountryId { get; set; } = null!;

    public int? BestChampionshipPosition { get; set; }

    public int? BestStartingGridPosition { get; set; }

    public int? BestRaceResult { get; set; }

    public int TotalChampionshipWins { get; set; }

    public int TotalRaceEntries { get; set; }

    public int TotalRaceStarts { get; set; }

    public int TotalRaceWins { get; set; }

    public int TotalRaceLaps { get; set; }

    public int TotalPodiums { get; set; }

    public int TotalPodiumRaces { get; set; }

    public decimal TotalPoints { get; set; }

    public decimal TotalChampionshipPoints { get; set; }

    public int TotalPolePositions { get; set; }

    public int TotalFastestLaps { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Engine> Engines { get; set; } = new List<Engine>();

    public virtual ICollection<RaceConstructorStanding> RaceConstructorStandings { get; set; } = new List<RaceConstructorStanding>();

    public virtual ICollection<RaceData> RaceData { get; set; } = new List<RaceData>();

    public virtual ICollection<SeasonConstructorStanding> SeasonConstructorStandings { get; set; } = new List<SeasonConstructorStanding>();

    public virtual ICollection<SeasonEngineManufacturer> SeasonEngineManufacturers { get; set; } = new List<SeasonEngineManufacturer>();

    public virtual ICollection<SeasonEntrantChassi> SeasonEntrantChassis { get; set; } = new List<SeasonEntrantChassi>();

    public virtual ICollection<SeasonEntrantConstructor> SeasonEntrantConstructors { get; set; } = new List<SeasonEntrantConstructor>();

    public virtual ICollection<SeasonEntrantDriver> SeasonEntrantDrivers { get; set; } = new List<SeasonEntrantDriver>();

    public virtual ICollection<SeasonEntrantEngine> SeasonEntrantEngines { get; set; } = new List<SeasonEntrantEngine>();

    public virtual ICollection<SeasonEntrantTyreManufacturer> SeasonEntrantTyreManufacturers { get; set; } = new List<SeasonEntrantTyreManufacturer>();
}
