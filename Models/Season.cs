﻿using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Season
{
    public int Year { get; set; }

    public virtual ICollection<Race> Races { get; set; } = new List<Race>();

    public virtual ICollection<SeasonConstructorStanding> SeasonConstructorStandings { get; set; } = new List<SeasonConstructorStanding>();

    public virtual ICollection<SeasonConstructor> SeasonConstructors { get; set; } = new List<SeasonConstructor>();

    public virtual ICollection<SeasonDriverStanding> SeasonDriverStandings { get; set; } = new List<SeasonDriverStanding>();

    public virtual ICollection<SeasonDriver> SeasonDrivers { get; set; } = new List<SeasonDriver>();

    public virtual ICollection<SeasonEngineManufacturer> SeasonEngineManufacturers { get; set; } = new List<SeasonEngineManufacturer>();

    public virtual ICollection<SeasonEntrantChassi> SeasonEntrantChassis { get; set; } = new List<SeasonEntrantChassi>();

    public virtual ICollection<SeasonEntrantConstructor> SeasonEntrantConstructors { get; set; } = new List<SeasonEntrantConstructor>();

    public virtual ICollection<SeasonEntrantDriver> SeasonEntrantDrivers { get; set; } = new List<SeasonEntrantDriver>();

    public virtual ICollection<SeasonEntrantEngine> SeasonEntrantEngines { get; set; } = new List<SeasonEntrantEngine>();

    public virtual ICollection<SeasonEntrantTyreManufacturer> SeasonEntrantTyreManufacturers { get; set; } = new List<SeasonEntrantTyreManufacturer>();

    public virtual ICollection<SeasonEntrant> SeasonEntrants { get; set; } = new List<SeasonEntrant>();

    public virtual ICollection<SeasonTyreManufacturer> SeasonTyreManufacturers { get; set; } = new List<SeasonTyreManufacturer>();
}
