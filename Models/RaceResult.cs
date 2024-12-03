using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class RaceResult
{
    public int? RaceId { get; set; }

    public int? PositionDisplayOrder { get; set; }

    public int? PositionNumber { get; set; }

    public string? PositionText { get; set; }

    public string? DriverNumber { get; set; }

    public string? DriverId { get; set; }

    public string? ConstructorId { get; set; }

    public string? EngineManufacturerId { get; set; }

    public string? TyreManufacturerId { get; set; }

    public bool? SharedCar { get; set; }

    public int? Laps { get; set; }

    public string? Time { get; set; }

    public int? TimeMillis { get; set; }

    public decimal? TimePenalty { get; set; }

    public int? TimePenaltyMillis { get; set; }

    public string? Gap { get; set; }

    public int? GapMillis { get; set; }

    public int? GapLaps { get; set; }

    public string? Interval { get; set; }

    public int? IntervalMillis { get; set; }

    public string? ReasonRetired { get; set; }

    public int? Points { get; set; }

    public int? QualificationPositionNumber { get; set; }

    public string? QualificationPositionText { get; set; }

    public int? GridPositionNumber { get; set; }

    public string? GridPositionText { get; set; }

    public int? PositionsGained { get; set; }

    public int? PitStops { get; set; }

    public bool? FastestLap { get; set; }

    public bool? DriverOfTheDay { get; set; }

    public bool? GrandSlam { get; set; }
}
