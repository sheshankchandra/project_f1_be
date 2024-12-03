using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class GrandPrix
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string ShortName { get; set; } = null!;

    public string Abbreviation { get; set; } = null!;

    public string? CountryId { get; set; }

    public int TotalRacesHeld { get; set; }

    public virtual Country? Country { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
