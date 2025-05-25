using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_f1_be.Models;

namespace project_f1_be.Controllers
{
    [Route("api/constructors")]
    [ApiController]
    public class ConstructorsController : Controller
    {
        private readonly F1dbContext _dbContext;

        public ConstructorsController(F1dbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Driver>>> GetConstructors()
        {

            var performanceData = await _dbContext.SeasonConstructors
            .GroupBy(x => x.ConstructorId)
            .Select(group => new
            {
                TeamName = group.Key,
                TotalPoints = group.Sum(sc => sc.TotalPoints),
                TotalRaces = group.Sum(sc => sc.TotalRaceStarts),
                TotalWins = group.Sum(sc => sc.TotalRaceWins)
            })
            .OrderByDescending(data => data.TotalPoints)
            .ToListAsync();

            var championshipData = await _dbContext.SeasonConstructorStandings
            .Where(scs => scs.PositionDisplayOrder == 1)
            .GroupBy(x => x.ConstructorId)
            .Select(group => new
            {
                ConstructorId = group.Key,
                ChampionshipWins = group.Count()
            })
            .ToListAsync();

            var result = performanceData
            .Select(pd => new
            {
                pd.TeamName,
                pd.TotalPoints,
                pd.TotalRaces,
                pd.TotalWins,
                ChampionshipWins = championshipData
                    .FirstOrDefault(cd => cd.ConstructorId == pd.TeamName)?.ChampionshipWins ?? 0
            })
            .OrderByDescending(x => x.ChampionshipWins)
            .ToList();

            if (result == null || !result.Any())
            {
                return NotFound("No constructors found.");
            }

            return Ok(result);
        }
    }
}
