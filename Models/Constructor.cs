using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Constructor
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string CountryId { get; set; } = null!;

    public int? BestChampionshipPosition { get; set; }

    public int? BestStartingGridPosition { get; set; }

    public int? BestRaceResult { get; set; }

    public int TotalChampionshipWins { get; set; }

    public int TotalRaceEntries { get; set; }

    public int TotalRaceStarts { get; set; }

    public int TotalRaceWins { get; set; }

    public int Total1And2Finishes { get; set; }

    public int TotalRaceLaps { get; set; }

    public int TotalPodiums { get; set; }

    public int TotalPodiumRaces { get; set; }

    public int TotalPoints { get; set; }

    public int TotalChampionshipPoints { get; set; }

    public int TotalPolePositions { get; set; }

    public int TotalFastestLaps { get; set; }

    public virtual ICollection<Chassi> Chassis { get; set; } = new List<Chassi>();

    public virtual ICollection<ConstructorChronology> ConstructorChronologyConstructors { get; set; } = new List<ConstructorChronology>();

    public virtual ICollection<ConstructorChronology> ConstructorChronologyOtherConstructors { get; set; } = new List<ConstructorChronology>();

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<RaceConstructorStanding> RaceConstructorStandings { get; set; } = new List<RaceConstructorStanding>();

    public virtual ICollection<RaceData> RaceData { get; set; } = new List<RaceData>();

    public virtual ICollection<SeasonConstructorStanding> SeasonConstructorStandings { get; set; } = new List<SeasonConstructorStanding>();

    public virtual ICollection<SeasonConstructor> SeasonConstructors { get; set; } = new List<SeasonConstructor>();

    public virtual ICollection<SeasonEntrantChassi> SeasonEntrantChassis { get; set; } = new List<SeasonEntrantChassi>();

    public virtual ICollection<SeasonEntrantConstructor> SeasonEntrantConstructors { get; set; } = new List<SeasonEntrantConstructor>();

    public virtual ICollection<SeasonEntrantDriver> SeasonEntrantDrivers { get; set; } = new List<SeasonEntrantDriver>();

    public virtual ICollection<SeasonEntrantEngine> SeasonEntrantEngines { get; set; } = new List<SeasonEntrantEngine>();

    public virtual ICollection<SeasonEntrantTyreManufacturer> SeasonEntrantTyreManufacturers { get; set; } = new List<SeasonEntrantTyreManufacturer>();
}
