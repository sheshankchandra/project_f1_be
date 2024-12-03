using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonEntrantEngine
{
    public int Year { get; set; }

    public string EntrantId { get; set; } = null!;

    public string ConstructorId { get; set; } = null!;

    public string EngineManufacturerId { get; set; } = null!;

    public string EngineId { get; set; } = null!;

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Engine Engine { get; set; } = null!;

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual Entrant Entrant { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}
