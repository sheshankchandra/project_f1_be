using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class DriverOfTheDayResult
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

    public int? Percentage { get; set; }
}
