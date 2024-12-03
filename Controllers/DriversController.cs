using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using project_f1_be.Models;

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
            var drivers = await _dbContext.Drivers.AsNoTracking().ToListAsync();

            if (drivers == null || !drivers.Any())
            {
                return NotFound("No drivers found.");
            }

            return Ok(drivers);
        }

        [HttpGet("count")]
        public async Task<ActionResult<int>> GetDriverCount()
        {
            var driverCount = await _dbContext.Drivers.CountAsync();

            return Ok(driverCount);
        }
    }
}
