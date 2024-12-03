using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class StartingGridPosition
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

    public int? QualificationPositionNumber { get; set; }

    public string? QualificationPositionText { get; set; }

    public string? GridPenalty { get; set; }

    public int? GridPenaltyPositions { get; set; }

    public string? Time { get; set; }

    public int? TimeMillis { get; set; }
}
