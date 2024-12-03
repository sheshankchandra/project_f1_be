using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Circuit
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public string? PreviousNames { get; set; }

    public string Type { get; set; } = null!;

    public string PlaceName { get; set; } = null!;

    public string CountryId { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int TotalRacesHeld { get; set; }

    public virtual Country Country { get; set; } = null!;

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();
}
