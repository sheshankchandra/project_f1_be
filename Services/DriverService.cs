using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_f1_be.Models;
using project_f1_be.DTOs;

namespace project_f1_be.Services
{
    public class DriverService(F1dbContext f1dbContext)
    {
        private readonly F1dbContext _f1dbContext = f1dbContext;

        public async Task<DriverResultDto?> GetDriverDetailsAsync(string driverId)
        {
            var driver = await _f1dbContext.Drivers
                .Include(d => d.NationalityCountry)
                .Where(d => d.Id == driverId)
                .FirstOrDefaultAsync();

            if (driver == null)
            {
                return null;
            }
            
            var results = await _f1dbContext.RaceData
                .Include(r => r.Race)
                .Include(r => r.Constructor)
                .Where(r => r.DriverId == driverId)
                .ToListAsync();

            var orderedRaceResults = results
                .OrderBy(r => r.Race.Date)
                .ToList();

            var raceResults = orderedRaceResults
                .Select(r => new RaceResultDto
                {
                    RaceId = r.RaceId,
                    SeasonYear = r.Race.Year,
                    RaceDate = r.Race.Date,
                    RaceName = r.Race.OfficialName,
                    Position = r.PositionNumber
                })
                .ToList();

            return new DriverResultDto
            {
                DriverName = driver.Name,
                Nationality = driver.NationalityCountry.Name,
                DateOfBirth = driver.DateOfBirth,
                DateOfDeath = driver.DateOfDeath,
                Age = DateTime.Now.Year - driver.DateOfBirth.Year,
                CurrentTeam = orderedRaceResults.Last().Constructor.FullName,
                CurrentDriverNumber = orderedRaceResults.Last().DriverNumber,
                DebutYear = orderedRaceResults.First().Race.Year,
                LastSeasonYear = orderedRaceResults.Last().Race.Year,
                FirstRace = raceResults.First(),
                LatestRace = raceResults.Last(),
                ChampionshipsWon = driver.TotalChampionshipWins,
                RacesData = raceResults,
            };
        }
    }
}
