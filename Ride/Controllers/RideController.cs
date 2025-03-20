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
        private readonly IMappingService _mappingService;
        private readonly IPricingService _pricingService;
        public RideController(ILogger<RideController> logger,
                            IFareRepository fareRepository,
                            IMappingService mappingService,
                            IPricingService pricingService)
        {
            _logger = logger;
            _fareRepository = fareRepository;
            _mappingService = mappingService;
            _pricingService = pricingService;
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
            //fix the models
            string result = await _mappingService.GetETAForSourceAndDestination(fare.Source, fare.Destination);
            string finalPrice = await _pricingService.GetEstimatedFare();
            await _fareRepository.AddFareAsync(fare);
            var fareFromDb = await _fareRepository.GetFareByIdAsync(fare.FareId);
            return Ok(fareFromDb);
        }


        [HttpPost]
        public async Task<IActionResult> RequestRide([Bind] RideRequest rideRequest)
        {
            if (rideRequest == null || string.IsNullOrWhiteSpace(rideRequest.FareId.ToString()))
            {
                return BadRequest();
            }

            
            var fareFromDb = await _fareRepository.GetFareByIdAsync(rideRequest.FareId);
            //Call RideMatching service to get available drivers
            // This should be async polling pattern
            return Ok(fareFromDb);
        }
    }
}
