using Microsoft.AspNetCore.Mvc;

namespace RideMatching.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RideMatchingController : ControllerBase
    {       

        private readonly ILogger<RideMatchingController> _logger;

        public RideMatchingController(ILogger<RideMatchingController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "MatchRide")]
        public IActionResult Get()
        {
            return BadRequest();
        }
    }
}
