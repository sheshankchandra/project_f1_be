using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Driver
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string? PermanentNumber { get; set; }

    public string Gender { get; set; } = null!;

    public DateOnly DateOfBirth { get; set; }

    public DateOnly? DateOfDeath { get; set; }

    public string PlaceOfBirth { get; set; } = null!;

    public string CountryOfBirthCountryId { get; set; } = null!;

    public string NationalityCountryId { get; set; } = null!;

    public string? SecondNationalityCountryId { get; set; }

    public int? BestChampionshipPosition { get; set; }

    public int? BestStartingGridPosition { get; set; }

    public int? BestRaceResult { get; set; }

    public int TotalChampionshipWins { get; set; }

    public int TotalRaceEntries { get; set; }

    public int TotalRaceStarts { get; set; }

    public int TotalRaceWins { get; set; }

    public int TotalRaceLaps { get; set; }

    public int TotalPodiums { get; set; }

    public decimal TotalPoints { get; set; }

    public decimal TotalChampionshipPoints { get; set; }

    public int TotalPolePositions { get; set; }

    public int TotalFastestLaps { get; set; }

    public int TotalDriverOfTheDay { get; set; }

    public int TotalGrandSlams { get; set; }

    public virtual Country CountryOfBirthCountry { get; set; } = null!;

    public virtual ICollection<DriverFamilyRelationship> DriverFamilyRelationshipDrivers { get; set; } = new List<DriverFamilyRelationship>();

    public virtual ICollection<DriverFamilyRelationship> DriverFamilyRelationshipOtherDrivers { get; set; } = new List<DriverFamilyRelationship>();

    public virtual Country NationalityCountry { get; set; } = null!;

    public virtual ICollection<RaceDatum> RaceData { get; set; } = new List<RaceDatum>();

    public virtual ICollection<RaceDriverStanding> RaceDriverStandings { get; set; } = new List<RaceDriverStanding>();

    public virtual ICollection<SeasonDriverStanding> SeasonDriverStandings { get; set; } = new List<SeasonDriverStanding>();

    public virtual ICollection<SeasonDriver> SeasonDrivers { get; set; } = new List<SeasonDriver>();

    public virtual ICollection<SeasonEntrantDriver> SeasonEntrantDrivers { get; set; } = new List<SeasonEntrantDriver>();

    public virtual Country? SecondNationalityCountry { get; set; }
}
