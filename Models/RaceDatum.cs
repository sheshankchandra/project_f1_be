using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class RaceDatum
{
    public int RaceId { get; set; }

    public string Type { get; set; } = null!;

    public int PositionDisplayOrder { get; set; }

    public int? PositionNumber { get; set; }

    public string PositionText { get; set; } = null!;

    public string DriverNumber { get; set; } = null!;

    public string DriverId { get; set; } = null!;

    public string ConstructorId { get; set; } = null!;

    public string EngineManufacturerId { get; set; } = null!;

    public string TyreManufacturerId { get; set; } = null!;

    public string? PracticeTime { get; set; }

    public int? PracticeTimeMillis { get; set; }

    public string? PracticeGap { get; set; }

    public int? PracticeGapMillis { get; set; }

    public string? PracticeInterval { get; set; }

    public int? PracticeIntervalMillis { get; set; }

    public int? PracticeLaps { get; set; }

    public string? QualifyingTime { get; set; }

    public int? QualifyingTimeMillis { get; set; }

    public string? QualifyingQ1 { get; set; }

    public int? QualifyingQ1Millis { get; set; }

    public string? QualifyingQ2 { get; set; }

    public int? QualifyingQ2Millis { get; set; }

    public string? QualifyingQ3 { get; set; }

    public int? QualifyingQ3Millis { get; set; }

    public decimal? QualifyingGap { get; set; }

    public int? QualifyingGapMillis { get; set; }

    public decimal? QualifyingInterval { get; set; }

    public int? QualifyingIntervalMillis { get; set; }

    public int? QualifyingLaps { get; set; }

    public int? StartingGridPositionQualificationPositionNumber { get; set; }

    public string? StartingGridPositionQualificationPositionText { get; set; }

    public string? StartingGridPositionGridPenalty { get; set; }

    public int? StartingGridPositionGridPenaltyPositions { get; set; }

    public string? StartingGridPositionTime { get; set; }

    public int? StartingGridPositionTimeMillis { get; set; }

    public bool? RaceSharedCar { get; set; }

    public int? RaceLaps { get; set; }

    public string? RaceTime { get; set; }

    public int? RaceTimeMillis { get; set; }

    public string? RaceTimePenalty { get; set; }

    public int? RaceTimePenaltyMillis { get; set; }

    public string? RaceGap { get; set; }

    public int? RaceGapMillis { get; set; }

    public int? RaceGapLaps { get; set; }

    public string? RaceInterval { get; set; }

    public int? RaceIntervalMillis { get; set; }

    public string? RaceReasonRetired { get; set; }

    public decimal? RacePoints { get; set; }

    public int? RaceQualificationPositionNumber { get; set; }

    public string? RaceQualificationPositionText { get; set; }

    public int? RaceGridPositionNumber { get; set; }

    public string? RaceGridPositionText { get; set; }

    public int? RacePositionsGained { get; set; }

    public int? RacePitStops { get; set; }

    public bool? RaceFastestLap { get; set; }

    public bool? RaceDriverOfTheDay { get; set; }

    public bool? RaceGrandSlam { get; set; }

    public int? FastestLapLap { get; set; }

    public string? FastestLapTime { get; set; }

    public int? FastestLapTimeMillis { get; set; }

    public string? FastestLapGap { get; set; }

    public int? FastestLapGapMillis { get; set; }

    public string? FastestLapInterval { get; set; }

    public int? FastestLapIntervalMillis { get; set; }

    public int? PitStopStop { get; set; }

    public int? PitStopLap { get; set; }

    public string? PitStopTime { get; set; }

    public int? PitStopTimeMillis { get; set; }

    public decimal? DriverOfTheDayPercentage { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;

    public virtual TyreManufacturer TyreManufacturer { get; set; } = null!;
}
