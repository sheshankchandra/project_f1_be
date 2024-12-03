using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Continent
{
    public string Id { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Demonym { get; set; } = null!;

    public virtual ICollection<Country> Countries { get; set; } = new List<Country>();
}
