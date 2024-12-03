using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonEntrantConstructor
{
    public int Year { get; set; }

    public string EntrantId { get; set; } = null!;

    public string ConstructorId { get; set; } = null!;

    public string EngineManufacturerId { get; set; } = null!;

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual Entrant Entrant { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}
