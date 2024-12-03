using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Engine
{
    public string Id { get; set; } = null!;

    public string EngineManufacturerId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public decimal? Capacity { get; set; }

    public string? Configuration { get; set; }

    public string? Aspiration { get; set; }

    public virtual EngineManufacturer EngineManufacturer { get; set; } = null!;

    public virtual ICollection<SeasonEntrantEngine> SeasonEntrantEngines { get; set; } = new List<SeasonEntrantEngine>();
}
