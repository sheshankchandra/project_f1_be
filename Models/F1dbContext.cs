using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace project_f1_be.Models;

public partial class F1dbContext : DbContext
{
    private readonly IConfiguration _configuration;

    // Inject IConfiguration into DbContext
    public F1dbContext(DbContextOptions<F1dbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Chassi> Chasses { get; set; }

    public virtual DbSet<Circuit> Circuits { get; set; }

    public virtual DbSet<Constructor> Constructors { get; set; }

    public virtual DbSet<ConstructorChronology> ConstructorChronologies { get; set; }

    public virtual DbSet<Continent> Continents { get; set; }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Driver> Drivers { get; set; }

    public virtual DbSet<DriverFamilyRelationship> DriverFamilyRelationships { get; set; }

    public virtual DbSet<DriverOfTheDayResult> DriverOfTheDayResults { get; set; }

    public virtual DbSet<Engine> Engines { get; set; }

    public virtual DbSet<EngineManufacturer> EngineManufacturers { get; set; }

    public virtual DbSet<Entrant> Entrants { get; set; }

    public virtual DbSet<FastestLap> FastestLaps { get; set; }

    public virtual DbSet<FreePractice1Result> FreePractice1Results { get; set; }

    public virtual DbSet<FreePractice2Result> FreePractice2Results { get; set; }

    public virtual DbSet<FreePractice3Result> FreePractice3Results { get; set; }

    public virtual DbSet<FreePractice4Result> FreePractice4Results { get; set; }

    public virtual DbSet<GrandPrix> GrandPrixes { get; set; }

    public virtual DbSet<PitStop> PitStops { get; set; }

    public virtual DbSet<PreQualifyingResult> PreQualifyingResults { get; set; }

    public virtual DbSet<Qualifying1Result> Qualifying1Results { get; set; }

    public virtual DbSet<Qualifying2Result> Qualifying2Results { get; set; }

    public virtual DbSet<QualifyingResult> QualifyingResults { get; set; }

    public virtual DbSet<Race> Races { get; set; }

    public virtual DbSet<RaceConstructorStanding> RaceConstructorStandings { get; set; }

    public virtual DbSet<RaceDatum> RaceData { get; set; }

    public virtual DbSet<RaceDriverStanding> RaceDriverStandings { get; set; }

    public virtual DbSet<RaceResult> RaceResults { get; set; }

    public virtual DbSet<Season> Seasons { get; set; }

    public virtual DbSet<SeasonConstructor> SeasonConstructors { get; set; }

    public virtual DbSet<SeasonConstructorStanding> SeasonConstructorStandings { get; set; }

    public virtual DbSet<SeasonDriver> SeasonDrivers { get; set; }

    public virtual DbSet<SeasonDriverStanding> SeasonDriverStandings { get; set; }

    public virtual DbSet<SeasonEngineManufacturer> SeasonEngineManufacturers { get; set; }

    public virtual DbSet<SeasonEntrant> SeasonEntrants { get; set; }

    public virtual DbSet<SeasonEntrantChassi> SeasonEntrantChasses { get; set; }

    public virtual DbSet<SeasonEntrantConstructor> SeasonEntrantConstructors { get; set; }

    public virtual DbSet<SeasonEntrantDriver> SeasonEntrantDrivers { get; set; }

    public virtual DbSet<SeasonEntrantEngine> SeasonEntrantEngines { get; set; }

    public virtual DbSet<SeasonEntrantTyreManufacturer> SeasonEntrantTyreManufacturers { get; set; }

    public virtual DbSet<SeasonTyreManufacturer> SeasonTyreManufacturers { get; set; }

    public virtual DbSet<SprintQualifyingResult> SprintQualifyingResults { get; set; }

    public virtual DbSet<SprintRaceResult> SprintRaceResults { get; set; }

    public virtual DbSet<SprintStartingGridPosition> SprintStartingGridPositions { get; set; }

    public virtual DbSet<StartingGridPosition> StartingGridPositions { get; set; }

    public virtual DbSet<TyreManufacturer> TyreManufacturers { get; set; }

    public virtual DbSet<WarmingUpResult> WarmingUpResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite(_configuration.GetConnectionString("F1Database"));
        }
    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Chassi>(entity =>
        {
            entity.ToTable("chassis");

            entity.HasIndex(e => e.ConstructorId, "chss_constructor_id_idx");

            entity.HasIndex(e => e.FullName, "chss_full_name_idx");

            entity.HasIndex(e => e.Name, "chss_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("full_name");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");

            entity.HasOne(d => d.Constructor).WithMany(p => p.Chassis)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Circuit>(entity =>
        {
            entity.ToTable("circuit");

            entity.HasIndex(e => e.CountryId, "crct_country_id_idx");

            entity.HasIndex(e => e.FullName, "crct_full_name_idx");

            entity.HasIndex(e => e.Name, "crct_name_idx");

            entity.HasIndex(e => e.PlaceName, "crct_place_name_idx");

            entity.HasIndex(e => e.Type, "crct_type_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.CountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_id");
            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("full_name");
            entity.Property(e => e.Latitude)
                .HasColumnType("DECIMAL(10,6)")
                .HasColumnName("latitude");
            entity.Property(e => e.Longitude)
                .HasColumnType("DECIMAL(10,6)")
                .HasColumnName("longitude");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
            entity.Property(e => e.PlaceName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("place_name");
            entity.Property(e => e.PreviousNames)
                .HasColumnType("VARCHAR(255)")
                .HasColumnName("previous_names");
            entity.Property(e => e.TotalRacesHeld).HasColumnName("total_races_held");
            entity.Property(e => e.Type)
                .HasColumnType("VARCHAR(6)")
                .HasColumnName("type");

            entity.HasOne(d => d.Country).WithMany(p => p.Circuits)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Constructor>(entity =>
        {
            entity.ToTable("constructor");

            entity.HasIndex(e => e.CountryId, "cnst_country_id_idx");

            entity.HasIndex(e => e.FullName, "cnst_full_name_idx");

            entity.HasIndex(e => e.Name, "cnst_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.BestChampionshipPosition).HasColumnName("best_championship_position");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.CountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_id");
            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("full_name");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
            entity.Property(e => e.Total1And2Finishes).HasColumnName("total_1_and_2_finishes");
            entity.Property(e => e.TotalChampionshipPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_championship_points");
            entity.Property(e => e.TotalChampionshipWins).HasColumnName("total_championship_wins");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalPodiumRaces).HasColumnName("total_podium_races");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_points");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.Country).WithMany(p => p.Constructors)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<ConstructorChronology>(entity =>
        {
            entity.HasKey(e => new { e.ConstructorId, e.PositionDisplayOrder });

            entity.ToTable("constructor_chronology");

            entity.HasIndex(e => new { e.ConstructorId, e.OtherConstructorId, e.YearFrom, e.YearTo }, "IX_constructor_chronology_constructor_id_other_constructor_id_year_from_year_to").IsUnique();

            entity.HasIndex(e => e.ConstructorId, "cnch_constructor_id_idx");

            entity.HasIndex(e => e.OtherConstructorId, "cnch_other_constructor_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "cnch_position_display_order_idx");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.OtherConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("other_constructor_id");
            entity.Property(e => e.YearFrom).HasColumnName("year_from");
            entity.Property(e => e.YearTo).HasColumnName("year_to");

            entity.HasOne(d => d.Constructor).WithMany(p => p.ConstructorChronologyConstructors)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OtherConstructor).WithMany(p => p.ConstructorChronologyOtherConstructors)
                .HasForeignKey(d => d.OtherConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Continent>(entity =>
        {
            entity.ToTable("continent");

            entity.HasIndex(e => e.Code, "IX_continent_code").IsUnique();

            entity.HasIndex(e => e.Name, "IX_continent_name").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.Code)
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("code");
            entity.Property(e => e.Demonym)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("demonym");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<Country>(entity =>
        {
            entity.ToTable("country");

            entity.HasIndex(e => e.Alpha2Code, "IX_country_alpha2_code").IsUnique();

            entity.HasIndex(e => e.Alpha3Code, "IX_country_alpha3_code").IsUnique();

            entity.HasIndex(e => e.Name, "IX_country_name").IsUnique();

            entity.HasIndex(e => e.ContinentId, "cntr_continent_id_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.Alpha2Code)
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("alpha2_code");
            entity.Property(e => e.Alpha3Code)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("alpha3_code");
            entity.Property(e => e.ContinentId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("continent_id");
            entity.Property(e => e.Demonym)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("demonym");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");

            entity.HasOne(d => d.Continent).WithMany(p => p.Countries)
                .HasForeignKey(d => d.ContinentId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Driver>(entity =>
        {
            entity.ToTable("driver");

            entity.HasIndex(e => e.Abbreviation, "drvr_abbreviation_idx");

            entity.HasIndex(e => e.CountryOfBirthCountryId, "drvr_country_of_birth_country_id_idx");

            entity.HasIndex(e => e.DateOfBirth, "drvr_date_of_birth_idx");

            entity.HasIndex(e => e.DateOfDeath, "drvr_date_of_death_idx");

            entity.HasIndex(e => e.FirstName, "drvr_first_name_idx");

            entity.HasIndex(e => e.FullName, "drvr_full_name_idx");

            entity.HasIndex(e => e.Gender, "drvr_gender_idx");

            entity.HasIndex(e => e.LastName, "drvr_last_name_idx");

            entity.HasIndex(e => e.Name, "drvr_name_idx");

            entity.HasIndex(e => e.NationalityCountryId, "drvr_nationality_country_id_idx");

            entity.HasIndex(e => e.PermanentNumber, "drvr_permanent_number_idx");

            entity.HasIndex(e => e.PlaceOfBirth, "drvr_place_of_birth_idx");

            entity.HasIndex(e => e.SecondNationalityCountryId, "drvr_second_nationality_country_id_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("abbreviation");
            entity.Property(e => e.BestChampionshipPosition).HasColumnName("best_championship_position");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.CountryOfBirthCountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_of_birth_country_id");
            entity.Property(e => e.DateOfBirth)
                .HasColumnType("DATE")
                .HasColumnName("date_of_birth");
            entity.Property(e => e.DateOfDeath)
                .HasColumnType("DATE")
                .HasColumnName("date_of_death");
            entity.Property(e => e.FirstName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("first_name");
            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("full_name");
            entity.Property(e => e.Gender)
                .HasColumnType("VARCHAR(6)")
                .HasColumnName("gender");
            entity.Property(e => e.LastName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
            entity.Property(e => e.NationalityCountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("nationality_country_id");
            entity.Property(e => e.PermanentNumber)
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("permanent_number");
            entity.Property(e => e.PlaceOfBirth)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("place_of_birth");
            entity.Property(e => e.SecondNationalityCountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("second_nationality_country_id");
            entity.Property(e => e.TotalChampionshipPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_championship_points");
            entity.Property(e => e.TotalChampionshipWins).HasColumnName("total_championship_wins");
            entity.Property(e => e.TotalDriverOfTheDay).HasColumnName("total_driver_of_the_day");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalGrandSlams).HasColumnName("total_grand_slams");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_points");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.CountryOfBirthCountry).WithMany(p => p.DriverCountryOfBirthCountries)
                .HasForeignKey(d => d.CountryOfBirthCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.NationalityCountry).WithMany(p => p.DriverNationalityCountries)
                .HasForeignKey(d => d.NationalityCountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.SecondNationalityCountry).WithMany(p => p.DriverSecondNationalityCountries).HasForeignKey(d => d.SecondNationalityCountryId);
        });

        modelBuilder.Entity<DriverFamilyRelationship>(entity =>
        {
            entity.HasKey(e => new { e.DriverId, e.PositionDisplayOrder });

            entity.ToTable("driver_family_relationship");

            entity.HasIndex(e => new { e.DriverId, e.OtherDriverId, e.Type }, "IX_driver_family_relationship_driver_id_other_driver_id_type").IsUnique();

            entity.HasIndex(e => e.DriverId, "dfrl_driver_id_idx");

            entity.HasIndex(e => e.OtherDriverId, "dfrl_other_driver_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "dfrl_position_display_order_idx");

            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.OtherDriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("other_driver_id");
            entity.Property(e => e.Type)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("type");

            entity.HasOne(d => d.Driver).WithMany(p => p.DriverFamilyRelationshipDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.OtherDriver).WithMany(p => p.DriverFamilyRelationshipOtherDrivers)
                .HasForeignKey(d => d.OtherDriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<DriverOfTheDayResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("driver_of_the_day_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Percentage)
                .HasColumnType("DECIMAL(4,1)")
                .HasColumnName("percentage");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<Engine>(entity =>
        {
            entity.ToTable("engine");

            entity.HasIndex(e => e.Aspiration, "engn_aspiration_idx");

            entity.HasIndex(e => e.Capacity, "engn_capacity_idx");

            entity.HasIndex(e => e.Configuration, "engn_configuration_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "engn_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.FullName, "engn_full_name_idx");

            entity.HasIndex(e => e.Name, "engn_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.Aspiration)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("aspiration");
            entity.Property(e => e.Capacity)
                .HasColumnType("DECIMAL(2,1)")
                .HasColumnName("capacity");
            entity.Property(e => e.Configuration)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("configuration");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("full_name");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.Engines)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<EngineManufacturer>(entity =>
        {
            entity.ToTable("engine_manufacturer");

            entity.HasIndex(e => e.CountryId, "enmf_country_id_idx");

            entity.HasIndex(e => e.Name, "enmf_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.BestChampionshipPosition).HasColumnName("best_championship_position");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.CountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
            entity.Property(e => e.TotalChampionshipPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_championship_points");
            entity.Property(e => e.TotalChampionshipWins).HasColumnName("total_championship_wins");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalPodiumRaces).HasColumnName("total_podium_races");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_points");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.Country).WithMany(p => p.EngineManufacturers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Entrant>(entity =>
        {
            entity.ToTable("entrant");

            entity.HasIndex(e => e.Name, "entr_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
        });

        modelBuilder.Entity<FastestLap>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("fastest_lap");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Lap).HasColumnName("lap");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<FreePractice1Result>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("free_practice_1_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<FreePractice2Result>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("free_practice_2_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<FreePractice3Result>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("free_practice_3_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<FreePractice4Result>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("free_practice_4_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<GrandPrix>(entity =>
        {
            entity.ToTable("grand_prix");

            entity.HasIndex(e => e.Abbreviation, "grpx_abbreviation_idx");

            entity.HasIndex(e => e.CountryId, "grpx_country_id_idx");

            entity.HasIndex(e => e.FullName, "grpx_full_name_idx");

            entity.HasIndex(e => e.Name, "grpx_name_idx");

            entity.HasIndex(e => e.ShortName, "grpx_short_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("abbreviation");
            entity.Property(e => e.CountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_id");
            entity.Property(e => e.FullName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("full_name");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
            entity.Property(e => e.ShortName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("short_name");
            entity.Property(e => e.TotalRacesHeld).HasColumnName("total_races_held");

            entity.HasOne(d => d.Country).WithMany(p => p.GrandPrixes).HasForeignKey(d => d.CountryId);
        });

        modelBuilder.Entity<PitStop>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("pit_stop");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Lap).HasColumnName("lap");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Stop).HasColumnName("stop");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<PreQualifyingResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("pre_qualifying_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<Qualifying1Result>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("qualifying_1_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<Qualifying2Result>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("qualifying_2_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<QualifyingResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("qualifying_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.Q1)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("q1");
            entity.Property(e => e.Q1Millis).HasColumnName("q1_millis");
            entity.Property(e => e.Q2)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("q2");
            entity.Property(e => e.Q2Millis).HasColumnName("q2_millis");
            entity.Property(e => e.Q3)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("q3");
            entity.Property(e => e.Q3Millis).HasColumnName("q3_millis");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<Race>(entity =>
        {
            entity.ToTable("race");

            entity.HasIndex(e => new { e.Year, e.Round }, "IX_race_year_round").IsUnique();

            entity.HasIndex(e => e.CircuitId, "race_circuit_id_idx");

            entity.HasIndex(e => e.Date, "race_date_idx");

            entity.HasIndex(e => e.GrandPrixId, "race_grand_prix_id_idx");

            entity.HasIndex(e => e.OfficialName, "race_official_name_idx");

            entity.HasIndex(e => e.Round, "race_round_idx");

            entity.HasIndex(e => e.Year, "race_year_idx");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.CircuitId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("circuit_id");
            entity.Property(e => e.CircuitType)
                .HasColumnType("VARCHAR(6)")
                .HasColumnName("circuit_type");
            entity.Property(e => e.CourseLength)
                .HasColumnType("DECIMAL(6,3)")
                .HasColumnName("course_length");
            entity.Property(e => e.Date)
                .HasColumnType("DATE")
                .HasColumnName("date");
            entity.Property(e => e.Distance)
                .HasColumnType("DECIMAL(6,3)")
                .HasColumnName("distance");
            entity.Property(e => e.FreePractice1Date)
                .HasColumnType("DATE")
                .HasColumnName("free_practice_1_date");
            entity.Property(e => e.FreePractice1Time)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("free_practice_1_time");
            entity.Property(e => e.FreePractice2Date)
                .HasColumnType("DATE")
                .HasColumnName("free_practice_2_date");
            entity.Property(e => e.FreePractice2Time)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("free_practice_2_time");
            entity.Property(e => e.FreePractice3Date)
                .HasColumnType("DATE")
                .HasColumnName("free_practice_3_date");
            entity.Property(e => e.FreePractice3Time)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("free_practice_3_time");
            entity.Property(e => e.FreePractice4Date)
                .HasColumnType("DATE")
                .HasColumnName("free_practice_4_date");
            entity.Property(e => e.FreePractice4Time)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("free_practice_4_time");
            entity.Property(e => e.GrandPrixId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("grand_prix_id");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.OfficialName)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("official_name");
            entity.Property(e => e.PreQualifyingDate)
                .HasColumnType("DATE")
                .HasColumnName("pre_qualifying_date");
            entity.Property(e => e.PreQualifyingTime)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("pre_qualifying_time");
            entity.Property(e => e.Qualifying1Date)
                .HasColumnType("DATE")
                .HasColumnName("qualifying_1_date");
            entity.Property(e => e.Qualifying1Time)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("qualifying_1_time");
            entity.Property(e => e.Qualifying2Date)
                .HasColumnType("DATE")
                .HasColumnName("qualifying_2_date");
            entity.Property(e => e.Qualifying2Time)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("qualifying_2_time");
            entity.Property(e => e.QualifyingDate)
                .HasColumnType("DATE")
                .HasColumnName("qualifying_date");
            entity.Property(e => e.QualifyingFormat)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_format");
            entity.Property(e => e.QualifyingTime)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("qualifying_time");
            entity.Property(e => e.Round).HasColumnName("round");
            entity.Property(e => e.ScheduledDistance)
                .HasColumnType("DECIMAL(6,3)")
                .HasColumnName("scheduled_distance");
            entity.Property(e => e.ScheduledLaps).HasColumnName("scheduled_laps");
            entity.Property(e => e.SprintQualifyingDate)
                .HasColumnType("DATE")
                .HasColumnName("sprint_qualifying_date");
            entity.Property(e => e.SprintQualifyingFormat)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("sprint_qualifying_format");
            entity.Property(e => e.SprintQualifyingTime)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("sprint_qualifying_time");
            entity.Property(e => e.SprintRaceDate)
                .HasColumnType("DATE")
                .HasColumnName("sprint_race_date");
            entity.Property(e => e.SprintRaceTime)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("sprint_race_time");
            entity.Property(e => e.Time).HasColumnName("time");
            entity.Property(e => e.WarmingUpDate)
                .HasColumnType("DATE")
                .HasColumnName("warming_up_date");
            entity.Property(e => e.WarmingUpTime)
                .HasColumnType("VARCHAR(5)")
                .HasColumnName("warming_up_time");
            entity.Property(e => e.Year).HasColumnName("year");

            entity.HasOne(d => d.Circuit).WithMany(p => p.Races)
                .HasForeignKey(d => d.CircuitId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.GrandPrix).WithMany(p => p.Races)
                .HasForeignKey(d => d.GrandPrixId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.Races)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RaceConstructorStanding>(entity =>
        {
            entity.HasKey(e => new { e.RaceId, e.PositionDisplayOrder });

            entity.ToTable("race_constructor_standing");

            entity.HasIndex(e => e.ConstructorId, "rccs_constructor_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "rccs_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "rccs_position_display_order_idx");

            entity.HasIndex(e => e.PositionNumber, "rccs_position_number_idx");

            entity.HasIndex(e => e.PositionText, "rccs_position_text_idx");

            entity.HasIndex(e => e.RaceId, "rccs_race_id_idx");

            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Points)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("points");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.PositionsGained).HasColumnName("positions_gained");

            entity.HasOne(d => d.Constructor).WithMany(p => p.RaceConstructorStandings)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.RaceConstructorStandings)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.RaceConstructorStandings)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RaceDatum>(entity =>
        {
            entity.HasKey(e => new { e.RaceId, e.Type, e.PositionDisplayOrder });

            entity.ToTable("race_data");

            entity.HasIndex(e => e.ConstructorId, "rcda_constructor_id_idx");

            entity.HasIndex(e => e.DriverId, "rcda_driver_id_idx");

            entity.HasIndex(e => e.DriverNumber, "rcda_driver_number_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "rcda_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "rcda_position_display_order_idx");

            entity.HasIndex(e => e.PositionNumber, "rcda_position_number_idx");

            entity.HasIndex(e => e.PositionText, "rcda_position_text_idx");

            entity.HasIndex(e => e.RaceId, "rcda_race_id_idx");

            entity.HasIndex(e => e.Type, "rcda_type_idx");

            entity.HasIndex(e => e.TyreManufacturerId, "rcda_tyre_manufacturer_id_idx");

            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Type)
                .HasColumnType("VARCHAR(50)")
                .HasColumnName("type");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.DriverOfTheDayPercentage)
                .HasColumnType("DECIMAL(4,1)")
                .HasColumnName("driver_of_the_day_percentage");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.FastestLapGap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("fastest_lap_gap");
            entity.Property(e => e.FastestLapGapMillis).HasColumnName("fastest_lap_gap_millis");
            entity.Property(e => e.FastestLapInterval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("fastest_lap_interval");
            entity.Property(e => e.FastestLapIntervalMillis).HasColumnName("fastest_lap_interval_millis");
            entity.Property(e => e.FastestLapLap).HasColumnName("fastest_lap_lap");
            entity.Property(e => e.FastestLapTime)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("fastest_lap_time");
            entity.Property(e => e.FastestLapTimeMillis).HasColumnName("fastest_lap_time_millis");
            entity.Property(e => e.PitStopLap).HasColumnName("pit_stop_lap");
            entity.Property(e => e.PitStopStop).HasColumnName("pit_stop_stop");
            entity.Property(e => e.PitStopTime)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("pit_stop_time");
            entity.Property(e => e.PitStopTimeMillis).HasColumnName("pit_stop_time_millis");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.PracticeGap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("practice_gap");
            entity.Property(e => e.PracticeGapMillis).HasColumnName("practice_gap_millis");
            entity.Property(e => e.PracticeInterval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("practice_interval");
            entity.Property(e => e.PracticeIntervalMillis).HasColumnName("practice_interval_millis");
            entity.Property(e => e.PracticeLaps).HasColumnName("practice_laps");
            entity.Property(e => e.PracticeTime)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("practice_time");
            entity.Property(e => e.PracticeTimeMillis).HasColumnName("practice_time_millis");
            entity.Property(e => e.QualifyingGap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_gap");
            entity.Property(e => e.QualifyingGapMillis).HasColumnName("qualifying_gap_millis");
            entity.Property(e => e.QualifyingInterval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_interval");
            entity.Property(e => e.QualifyingIntervalMillis).HasColumnName("qualifying_interval_millis");
            entity.Property(e => e.QualifyingLaps).HasColumnName("qualifying_laps");
            entity.Property(e => e.QualifyingQ1)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_q1");
            entity.Property(e => e.QualifyingQ1Millis).HasColumnName("qualifying_q1_millis");
            entity.Property(e => e.QualifyingQ2)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_q2");
            entity.Property(e => e.QualifyingQ2Millis).HasColumnName("qualifying_q2_millis");
            entity.Property(e => e.QualifyingQ3)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_q3");
            entity.Property(e => e.QualifyingQ3Millis).HasColumnName("qualifying_q3_millis");
            entity.Property(e => e.QualifyingTime)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("qualifying_time");
            entity.Property(e => e.QualifyingTimeMillis).HasColumnName("qualifying_time_millis");
            entity.Property(e => e.RaceDriverOfTheDay)
                .HasColumnType("BOOLEAN")
                .HasColumnName("race_driver_of_the_day");
            entity.Property(e => e.RaceFastestLap)
                .HasColumnType("BOOLEAN")
                .HasColumnName("race_fastest_lap");
            entity.Property(e => e.RaceGap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("race_gap");
            entity.Property(e => e.RaceGapLaps).HasColumnName("race_gap_laps");
            entity.Property(e => e.RaceGapMillis).HasColumnName("race_gap_millis");
            entity.Property(e => e.RaceGrandSlam)
                .HasColumnType("BOOLEAN")
                .HasColumnName("race_grand_slam");
            entity.Property(e => e.RaceGridPositionNumber).HasColumnName("race_grid_position_number");
            entity.Property(e => e.RaceGridPositionText)
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("race_grid_position_text");
            entity.Property(e => e.RaceInterval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("race_interval");
            entity.Property(e => e.RaceIntervalMillis).HasColumnName("race_interval_millis");
            entity.Property(e => e.RaceLaps).HasColumnName("race_laps");
            entity.Property(e => e.RacePitStops).HasColumnName("race_pit_stops");
            entity.Property(e => e.RacePoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("race_points");
            entity.Property(e => e.RacePositionsGained).HasColumnName("race_positions_gained");
            entity.Property(e => e.RaceQualificationPositionNumber).HasColumnName("race_qualification_position_number");
            entity.Property(e => e.RaceQualificationPositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("race_qualification_position_text");
            entity.Property(e => e.RaceReasonRetired)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("race_reason_retired");
            entity.Property(e => e.RaceSharedCar)
                .HasColumnType("BOOLEAN")
                .HasColumnName("race_shared_car");
            entity.Property(e => e.RaceTime)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("race_time");
            entity.Property(e => e.RaceTimeMillis).HasColumnName("race_time_millis");
            entity.Property(e => e.RaceTimePenalty)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("race_time_penalty");
            entity.Property(e => e.RaceTimePenaltyMillis).HasColumnName("race_time_penalty_millis");
            entity.Property(e => e.StartingGridPositionGridPenalty)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("starting_grid_position_grid_penalty");
            entity.Property(e => e.StartingGridPositionGridPenaltyPositions).HasColumnName("starting_grid_position_grid_penalty_positions");
            entity.Property(e => e.StartingGridPositionQualificationPositionNumber).HasColumnName("starting_grid_position_qualification_position_number");
            entity.Property(e => e.StartingGridPositionQualificationPositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("starting_grid_position_qualification_position_text");
            entity.Property(e => e.StartingGridPositionTime)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("starting_grid_position_time");
            entity.Property(e => e.StartingGridPositionTimeMillis).HasColumnName("starting_grid_position_time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");

            entity.HasOne(d => d.Constructor).WithMany(p => p.RaceData)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Driver).WithMany(p => p.RaceData)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.RaceData)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.RaceData)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TyreManufacturer).WithMany(p => p.RaceData)
                .HasForeignKey(d => d.TyreManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RaceDriverStanding>(entity =>
        {
            entity.HasKey(e => new { e.RaceId, e.PositionDisplayOrder });

            entity.ToTable("race_driver_standing");

            entity.HasIndex(e => e.DriverId, "rcds_driver_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "rcds_position_display_order_idx");

            entity.HasIndex(e => e.PositionNumber, "rcds_position_number_idx");

            entity.HasIndex(e => e.PositionText, "rcds_position_text_idx");

            entity.HasIndex(e => e.RaceId, "rcds_race_id_idx");

            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.Points)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("points");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.PositionsGained).HasColumnName("positions_gained");

            entity.HasOne(d => d.Driver).WithMany(p => p.RaceDriverStandings)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Race).WithMany(p => p.RaceDriverStandings)
                .HasForeignKey(d => d.RaceId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<RaceResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("race_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.DriverOfTheDay)
                .HasColumnType("BOOLEAN")
                .HasColumnName("driver_of_the_day");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.FastestLap)
                .HasColumnType("BOOLEAN")
                .HasColumnName("fastest_lap");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapLaps).HasColumnName("gap_laps");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.GrandSlam)
                .HasColumnType("BOOLEAN")
                .HasColumnName("grand_slam");
            entity.Property(e => e.GridPositionNumber).HasColumnName("grid_position_number");
            entity.Property(e => e.GridPositionText)
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("grid_position_text");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PitStops).HasColumnName("pit_stops");
            entity.Property(e => e.Points)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("points");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.PositionsGained).HasColumnName("positions_gained");
            entity.Property(e => e.QualificationPositionNumber).HasColumnName("qualification_position_number");
            entity.Property(e => e.QualificationPositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("qualification_position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.ReasonRetired)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("reason_retired");
            entity.Property(e => e.SharedCar)
                .HasColumnType("BOOLEAN")
                .HasColumnName("shared_car");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TimePenalty)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time_penalty");
            entity.Property(e => e.TimePenaltyMillis).HasColumnName("time_penalty_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<Season>(entity =>
        {
            entity.HasKey(e => e.Year);

            entity.ToTable("season");

            entity.Property(e => e.Year)
                .ValueGeneratedNever()
                .HasColumnName("year");
        });

        modelBuilder.Entity<SeasonConstructor>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.ConstructorId });

            entity.ToTable("season_constructor");

            entity.HasIndex(e => e.ConstructorId, "sscn_constructor_id_idx");

            entity.HasIndex(e => e.Year, "sscn_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.Total1And2Finishes).HasColumnName("total_1_and_2_finishes");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalPodiumRaces).HasColumnName("total_podium_races");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_points");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonConstructors)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonConstructors)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonConstructorStanding>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.PositionDisplayOrder });

            entity.ToTable("season_constructor_standing");

            entity.HasIndex(e => e.ConstructorId, "sscs_constructor_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "sscs_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "sscs_position_display_order_idx");

            entity.HasIndex(e => e.PositionNumber, "sscs_position_number_idx");

            entity.HasIndex(e => e.PositionText, "sscs_position_text_idx");

            entity.HasIndex(e => e.Year, "sscs_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Points)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("points");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonConstructorStandings)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonConstructorStandings)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonConstructorStandings)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonDriver>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.DriverId });

            entity.ToTable("season_driver");

            entity.HasIndex(e => e.DriverId, "ssdr_driver_id_idx");

            entity.HasIndex(e => e.Year, "ssdr_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.TotalDriverOfTheDay).HasColumnName("total_driver_of_the_day");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalGrandSlams).HasColumnName("total_grand_slams");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_points");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.Driver).WithMany(p => p.SeasonDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonDrivers)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonDriverStanding>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.PositionDisplayOrder });

            entity.ToTable("season_driver_standing");

            entity.HasIndex(e => e.DriverId, "ssds_driver_id_idx");

            entity.HasIndex(e => e.PositionDisplayOrder, "ssds_position_display_order_idx");

            entity.HasIndex(e => e.PositionNumber, "ssds_position_number_idx");

            entity.HasIndex(e => e.PositionText, "ssds_position_text_idx");

            entity.HasIndex(e => e.Year, "ssds_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.Points)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("points");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");

            entity.HasOne(d => d.Driver).WithMany(p => p.SeasonDriverStandings)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonDriverStandings)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEngineManufacturer>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EngineManufacturerId });

            entity.ToTable("season_engine_manufacturer");

            entity.HasIndex(e => e.EngineManufacturerId, "ssem_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.Year, "ssem_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalPodiumRaces).HasColumnName("total_podium_races");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPoints)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("total_points");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonEngineManufacturers)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEngineManufacturers)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEntrant>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EntrantId });

            entity.ToTable("season_entrant");

            entity.HasIndex(e => e.CountryId, "sent_country_id_idx");

            entity.HasIndex(e => e.EntrantId, "sent_entrant_id_idx");

            entity.HasIndex(e => e.Year, "sent_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EntrantId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("entrant_id");
            entity.Property(e => e.CountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_id");

            entity.HasOne(d => d.Country).WithMany(p => p.SeasonEntrants)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Entrant).WithMany(p => p.SeasonEntrants)
                .HasForeignKey(d => d.EntrantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEntrants)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEntrantChassi>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EntrantId, e.ConstructorId, e.EngineManufacturerId, e.ChassisId });

            entity.ToTable("season_entrant_chassis");

            entity.HasIndex(e => e.ChassisId, "sech_chassis_id_idx");

            entity.HasIndex(e => e.ConstructorId, "sech_constructor_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "sech_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.EntrantId, "sech_entrant_id_idx");

            entity.HasIndex(e => e.Year, "sech_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EntrantId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("entrant_id");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.ChassisId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("chassis_id");

            entity.HasOne(d => d.Chassis).WithMany(p => p.SeasonEntrantChassis)
                .HasForeignKey(d => d.ChassisId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonEntrantChassis)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonEntrantChassis)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Entrant).WithMany(p => p.SeasonEntrantChassis)
                .HasForeignKey(d => d.EntrantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEntrantChassis)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEntrantConstructor>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EntrantId, e.ConstructorId, e.EngineManufacturerId });

            entity.ToTable("season_entrant_constructor");

            entity.HasIndex(e => e.ConstructorId, "secn_constructor_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "secn_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.EntrantId, "secn_entrant_id_idx");

            entity.HasIndex(e => e.Year, "secn_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EntrantId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("entrant_id");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonEntrantConstructors)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonEntrantConstructors)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Entrant).WithMany(p => p.SeasonEntrantConstructors)
                .HasForeignKey(d => d.EntrantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEntrantConstructors)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEntrantDriver>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EntrantId, e.ConstructorId, e.EngineManufacturerId, e.DriverId });

            entity.ToTable("season_entrant_driver");

            entity.HasIndex(e => e.ConstructorId, "sedr_constructor_id_idx");

            entity.HasIndex(e => e.DriverId, "sedr_driver_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "sedr_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.EntrantId, "sedr_entrant_id_idx");

            entity.HasIndex(e => e.Year, "sedr_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EntrantId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("entrant_id");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.Rounds)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("rounds");
            entity.Property(e => e.RoundsText)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("rounds_text");
            entity.Property(e => e.TestDriver)
                .HasColumnType("BOOLEAN")
                .HasColumnName("test_driver");

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonEntrantDrivers)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Driver).WithMany(p => p.SeasonEntrantDrivers)
                .HasForeignKey(d => d.DriverId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonEntrantDrivers)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Entrant).WithMany(p => p.SeasonEntrantDrivers)
                .HasForeignKey(d => d.EntrantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEntrantDrivers)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEntrantEngine>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EntrantId, e.ConstructorId, e.EngineManufacturerId, e.EngineId });

            entity.ToTable("season_entrant_engine");

            entity.HasIndex(e => e.ConstructorId, "seen_constructor_id_idx");

            entity.HasIndex(e => e.EngineId, "seen_engine_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "seen_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.EntrantId, "seen_entrant_id_idx");

            entity.HasIndex(e => e.Year, "seen_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EntrantId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("entrant_id");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.EngineId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_id");

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonEntrantEngines)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Engine).WithMany(p => p.SeasonEntrantEngines)
                .HasForeignKey(d => d.EngineId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonEntrantEngines)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Entrant).WithMany(p => p.SeasonEntrantEngines)
                .HasForeignKey(d => d.EntrantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEntrantEngines)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonEntrantTyreManufacturer>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.EntrantId, e.ConstructorId, e.EngineManufacturerId, e.TyreManufacturerId });

            entity.ToTable("season_entrant_tyre_manufacturer");

            entity.HasIndex(e => e.ConstructorId, "setm_constructor_id_idx");

            entity.HasIndex(e => e.EngineManufacturerId, "setm_engine_manufacturer_id_idx");

            entity.HasIndex(e => e.EntrantId, "setm_entrant_id_idx");

            entity.HasIndex(e => e.TyreManufacturerId, "setm_tyre_manufacturer_id_idx");

            entity.HasIndex(e => e.Year, "setm_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.EntrantId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("entrant_id");
            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");

            entity.HasOne(d => d.Constructor).WithMany(p => p.SeasonEntrantTyreManufacturers)
                .HasForeignKey(d => d.ConstructorId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.EngineManufacturer).WithMany(p => p.SeasonEntrantTyreManufacturers)
                .HasForeignKey(d => d.EngineManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Entrant).WithMany(p => p.SeasonEntrantTyreManufacturers)
                .HasForeignKey(d => d.EntrantId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.TyreManufacturer).WithMany(p => p.SeasonEntrantTyreManufacturers)
                .HasForeignKey(d => d.TyreManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonEntrantTyreManufacturers)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SeasonTyreManufacturer>(entity =>
        {
            entity.HasKey(e => new { e.Year, e.TyreManufacturerId });

            entity.ToTable("season_tyre_manufacturer");

            entity.HasIndex(e => e.TyreManufacturerId, "sstm_tyre_manufacturer_id_idx");

            entity.HasIndex(e => e.Year, "sstm_year_idx");

            entity.Property(e => e.Year).HasColumnName("year");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalPodiumRaces).HasColumnName("total_podium_races");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.TyreManufacturer).WithMany(p => p.SeasonTyreManufacturers)
                .HasForeignKey(d => d.TyreManufacturerId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.YearNavigation).WithMany(p => p.SeasonTyreManufacturers)
                .HasForeignKey(d => d.Year)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<SprintQualifyingResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sprint_qualifying_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.Q1)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("q1");
            entity.Property(e => e.Q1Millis).HasColumnName("q1_millis");
            entity.Property(e => e.Q2)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("q2");
            entity.Property(e => e.Q2Millis).HasColumnName("q2_millis");
            entity.Property(e => e.Q3)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("q3");
            entity.Property(e => e.Q3Millis).HasColumnName("q3_millis");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<SprintRaceResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sprint_race_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapLaps).HasColumnName("gap_laps");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.GridPositionNumber).HasColumnName("grid_position_number");
            entity.Property(e => e.GridPositionText)
                .HasColumnType("VARCHAR(2)")
                .HasColumnName("grid_position_text");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.Points)
                .HasColumnType("DECIMAL(8,2)")
                .HasColumnName("points");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.PositionsGained).HasColumnName("positions_gained");
            entity.Property(e => e.QualificationPositionNumber).HasColumnName("qualification_position_number");
            entity.Property(e => e.QualificationPositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("qualification_position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.ReasonRetired)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("reason_retired");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TimePenalty)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time_penalty");
            entity.Property(e => e.TimePenaltyMillis).HasColumnName("time_penalty_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<SprintStartingGridPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("sprint_starting_grid_position");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.GridPenalty)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("grid_penalty");
            entity.Property(e => e.GridPenaltyPositions).HasColumnName("grid_penalty_positions");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.QualificationPositionNumber).HasColumnName("qualification_position_number");
            entity.Property(e => e.QualificationPositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("qualification_position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<StartingGridPosition>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("starting_grid_position");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.GridPenalty)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("grid_penalty");
            entity.Property(e => e.GridPenaltyPositions).HasColumnName("grid_penalty_positions");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.QualificationPositionNumber).HasColumnName("qualification_position_number");
            entity.Property(e => e.QualificationPositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("qualification_position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        modelBuilder.Entity<TyreManufacturer>(entity =>
        {
            entity.ToTable("tyre_manufacturer");

            entity.HasIndex(e => e.CountryId, "tymf_country_id_idx");

            entity.HasIndex(e => e.Name, "tymf_name_idx");

            entity.Property(e => e.Id)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("id");
            entity.Property(e => e.BestRaceResult).HasColumnName("best_race_result");
            entity.Property(e => e.BestStartingGridPosition).HasColumnName("best_starting_grid_position");
            entity.Property(e => e.CountryId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("country_id");
            entity.Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("name");
            entity.Property(e => e.TotalFastestLaps).HasColumnName("total_fastest_laps");
            entity.Property(e => e.TotalPodiumRaces).HasColumnName("total_podium_races");
            entity.Property(e => e.TotalPodiums).HasColumnName("total_podiums");
            entity.Property(e => e.TotalPolePositions).HasColumnName("total_pole_positions");
            entity.Property(e => e.TotalRaceEntries).HasColumnName("total_race_entries");
            entity.Property(e => e.TotalRaceLaps).HasColumnName("total_race_laps");
            entity.Property(e => e.TotalRaceStarts).HasColumnName("total_race_starts");
            entity.Property(e => e.TotalRaceWins).HasColumnName("total_race_wins");

            entity.HasOne(d => d.Country).WithMany(p => p.TyreManufacturers)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<WarmingUpResult>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("warming_up_result");

            entity.Property(e => e.ConstructorId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("constructor_id");
            entity.Property(e => e.DriverId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("driver_id");
            entity.Property(e => e.DriverNumber)
                .HasColumnType("VARCHAR(3)")
                .HasColumnName("driver_number");
            entity.Property(e => e.EngineManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("engine_manufacturer_id");
            entity.Property(e => e.Gap)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("gap");
            entity.Property(e => e.GapMillis).HasColumnName("gap_millis");
            entity.Property(e => e.Interval)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("interval");
            entity.Property(e => e.IntervalMillis).HasColumnName("interval_millis");
            entity.Property(e => e.Laps).HasColumnName("laps");
            entity.Property(e => e.PositionDisplayOrder).HasColumnName("position_display_order");
            entity.Property(e => e.PositionNumber).HasColumnName("position_number");
            entity.Property(e => e.PositionText)
                .HasColumnType("VARCHAR(4)")
                .HasColumnName("position_text");
            entity.Property(e => e.RaceId).HasColumnName("race_id");
            entity.Property(e => e.Time)
                .HasColumnType("VARCHAR(20)")
                .HasColumnName("time");
            entity.Property(e => e.TimeMillis).HasColumnName("time_millis");
            entity.Property(e => e.TyreManufacturerId)
                .HasColumnType("VARCHAR(100)")
                .HasColumnName("tyre_manufacturer_id");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
