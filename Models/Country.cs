using System;
using System.Collections.Generic;

namespace project_f1_be.Models;

public partial class Country
{
    public string Id { get; set; } = null!;

    public string Alpha2Code { get; set; } = null!;

    public string Alpha3Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? Demonym { get; set; }

    public string ContinentId { get; set; } = null!;

    public virtual ICollection<Circuit> Circuits { get; set; } = new List<Circuit>();

    public virtual ICollection<Constructor> Constructors { get; set; } = new List<Constructor>();

    public virtual Continent Continent { get; set; } = null!;

    public virtual ICollection<Driver> DriverCountryOfBirthCountries { get; set; } = new List<Driver>();

    public virtual ICollection<Driver> DriverNationalityCountries { get; set; } = new List<Driver>();

    public virtual ICollection<Driver> DriverSecondNationalityCountries { get; set; } = new List<Driver>();

    public virtual ICollection<EngineManufacturer> EngineManufacturers { get; set; } = new List<EngineManufacturer>();

    public virtual ICollection<GrandPrix> GrandPrixes { get; set; } = new List<GrandPrix>();

    public virtual ICollection<SeasonEntrant> SeasonEntrants { get; set; } = new List<SeasonEntrant>();

    public virtual ICollection<TyreManufacturer> TyreManufacturers { get; set; } = new List<TyreManufacturer>();
}
