using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Entrant
{
    public string Id { get; set; } = null!;

    public string Name { get; set; } = null!;

    public virtual ICollection<SeasonEntrantChassi> SeasonEntrantChassis { get; set; } = new List<SeasonEntrantChassi>();

    public virtual ICollection<SeasonEntrantConstructor> SeasonEntrantConstructors { get; set; } = new List<SeasonEntrantConstructor>();

    public virtual ICollection<SeasonEntrantDriver> SeasonEntrantDrivers { get; set; } = new List<SeasonEntrantDriver>();

    public virtual ICollection<SeasonEntrantEngine> SeasonEntrantEngines { get; set; } = new List<SeasonEntrantEngine>();

    public virtual ICollection<SeasonEntrantTyreManufacturer> SeasonEntrantTyreManufacturers { get; set; } = new List<SeasonEntrantTyreManufacturer>();

    public virtual ICollection<SeasonEntrant> SeasonEntrants { get; set; } = new List<SeasonEntrant>();
}
