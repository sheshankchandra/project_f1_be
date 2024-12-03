using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonEntrantDriver
{
    public int Year { get; set; }

    public string EntrantId { get; set; } = null!;

    public string ConstructorId { get; set; } = null!;

    public string EngineManufacturerId { get; set; } = null!;

    public string DriverId { get; set; } = null!;

    public string? Rounds { get; set; }

    public string? RoundsText { get; set; }

    public bool TestDriver { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual Entrant Entrant { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}
