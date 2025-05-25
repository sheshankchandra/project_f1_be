using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_f1_be.DTOs;
using project_f1_be.Models;
using project_f1_be.Services;

namespace project_f1_be.Controllers
{
    [Route("api/drivers")]
    [ApiController]
    public class DriversController : ControllerBase
    {
        private readonly F1dbContext _dbContext;

        public DriversController(F1dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetDrivers()
        {
            var driversData = await _dbContext.Drivers
                .Select( x => new
                {
                    DriverName = x.Name,
                    Nationality = x.NationalityCountry.Name,
                    RaceStarts = x.TotalRaceStarts,
                    RaceWon = x.TotalRaceWins,
                    TotalPoints = x.TotalPoints,
                    ChampionshipWins = x.TotalChampionshipWins
                })
                .OrderByDescending(driver => driver.ChampionshipWins)
                .ToListAsync();

            if (driversData == null || !driversData.Any())
            {
                return NotFound("No drivers found.");
            }

            return Ok(driversData);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetDriverCount()
        {
            var driverCount = await _dbContext.Drivers.CountAsync();

            return Ok(driverCount);
        }

        [HttpGet("{driverId}")]
        public async Task<ActionResult<DriverResultDto>> GetDriver(string driverId)
        {
            var driverService = new DriverService(_dbContext);
            var result = await driverService.GetDriverDetailsAsync(driverId);

            if (result == null)
                return NotFound();

            return Ok(result);
        }
    }
}
