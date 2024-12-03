using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class FreePractice1Result
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

    public string? Time { get; set; }

    public int? TimeMillis { get; set; }

    public string? Gap { get; set; }

    public int? GapMillis { get; set; }

    public string? Interval { get; set; }

    public int? IntervalMillis { get; set; }

    public int? Laps { get; set; }
}
