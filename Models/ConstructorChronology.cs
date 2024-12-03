using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class ConstructorChronology
{
    public string ConstructorId { get; set; } = null!;

    public int PositionDisplayOrder { get; set; }

    public string OtherConstructorId { get; set; } = null!;

    public int YearFrom { get; set; }

    public int? YearTo { get; set; }

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual Constructor OtherConstructor { get; set; } = null!;
}
