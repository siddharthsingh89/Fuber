using Microsoft.AspNetCore.Mvc;
using Ride.Models;
using Ride.Models.ClientModels;
using Ride.Services;

namespace Ride.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RideController : ControllerBase
    {
       
        private readonly ILogger<RideController> _logger;
        private readonly IFareRepository _fareRepository;
        public RideController(ILogger<RideController> logger, IFareRepository fareRepository)
        {
            _logger = logger;
            _fareRepository = fareRepository;
        }

        [HttpPost("Fare")]
        public async Task<IActionResult> GetFare([Bind] FareInputRequest fareInputRequest)
        {
            if(fareInputRequest==null || string.IsNullOrWhiteSpace(fareInputRequest.PickupLocation) 
                || string.IsNullOrEmpty(fareInputRequest.Destination))
            {
                return BadRequest();
            }

            var fare = new Fare
            {
                Source = fareInputRequest.PickupLocation,
                Destination = fareInputRequest.Destination,
                EstimatedTimeOfArrival = DateTime.Now.AddMinutes(10),
                FareAmount = 10.00M,
                FareName = "Standard",
                UserId = 1
            };

            await _fareRepository.AddFareAsync(fare);
            var fareFromDb = await _fareRepository.GetFareByIdAsync(fare.FareId);
            return Ok(fareFromDb);
        }
    }
}
