using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonDriverStanding
{
    public int Year { get; set; }

    public int PositionDisplayOrder { get; set; }

    public int? PositionNumber { get; set; }

    public string PositionText { get; set; } = null!;

    public string DriverId { get; set; } = null!;

    public int Points { get; set; }

    public virtual Driver Driver { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}
