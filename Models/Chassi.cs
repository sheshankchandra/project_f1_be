using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Chassi
{
    public string Id { get; set; } = null!;

    public string ConstructorId { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string FullName { get; set; } = null!;

    public virtual Constructor Constructor { get; set; } = null!;

    public virtual ICollection<SeasonEntrantChassi> SeasonEntrantChassis { get; set; } = new List<SeasonEntrantChassi>();
}
