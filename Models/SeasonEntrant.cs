using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class SeasonEntrant
{
    public int Year { get; set; }

    public string EntrantId { get; set; } = null!;

    public string CountryId { get; set; } = null!;

    public virtual Country Country { get; set; } = null!;

    public virtual Entrant Entrant { get; set; } = null!;

    public virtual Season YearNavigation { get; set; } = null!;
}
