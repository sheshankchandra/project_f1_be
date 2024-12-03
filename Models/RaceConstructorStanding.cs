using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class RaceConstructorStanding
{
    public int RaceId { get; set; }

    public int PositionDisplayOrder { get; set; }

    public int? PositionNumber { get; set; }

    public string PositionText { get; set; } = null!;

    public string ConstructorId { get; set; } = null!;

    public string EngineManufacturerId { get; set; } = null!;

    public int Points { get; set; }

    public int? PositionsGained { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual Race Race { get; set; } = null!;
}
