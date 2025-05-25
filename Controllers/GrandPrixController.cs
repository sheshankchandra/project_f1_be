using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_f1_be.Models;

namespace project_f1_be.Controllers
{
    [Route("api/grandprixs")]
    [ApiController]
    public class GrandPrixController : ControllerBase
    {
        private readonly F1dbContext _dbContext;

        public GrandPrixController(F1dbContext DbContext)
        {
            _dbContext = DbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Race>>> GetGrandPrixs()
        {
            var gpData = await _dbContext.Races
            .Select(x => new
            {
                RaceId = x.Id,
                Year = x.Year,
                Round = x.Round,
                Date = x.Date,
                GpId = x.GrandPrixId,
                CircuitId = x.CircuitId,
                CircuitType = x.CircuitType,
                CourseLength = x.CourseLength,
                Laps = x.Laps,
                CourseDistance = x.Distance

            })
            .OrderByDescending(gp => gp.Date)
            .ToListAsync();

            if(gpData == null || !gpData.Any())
            {
                return NotFound("No Grand Prix's Found");
            }

            return Ok(gpData);
        }

        [HttpGet("totalRaces")]
        public async Task<ActionResult<int>> GetTotalRacesHistory()
        {
            var totalraces = await _dbContext.Races.CountAsync();

            return totalraces;
        }

        [HttpGet("totalDistance")]
        public async Task<ActionResult<int>> GetTotalDistanceHistory()
        {
            var totalDistance = await _dbContext.Races.SumAsync(r => r.Distance);

            if (totalDistance == 0)
            {
                return NotFound("No race distances found.");
            }

            return Ok(totalDistance);
        }
    }
}
