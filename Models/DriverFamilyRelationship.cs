using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class DriverFamilyRelationship
{
    public string DriverId { get; set; } = null!;

    public int PositionDisplayOrder { get; set; }

    public string OtherDriverId { get; set; } = null!;

    public string Type { get; set; } = null!;

    public virtual Driver Driver { get; set; } = null!;

    public virtual Driver OtherDriver { get; set; } = null!;
}
