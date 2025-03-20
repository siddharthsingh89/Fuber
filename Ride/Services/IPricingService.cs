namespace Ride.Services
{
    public interface IPricingService
    {
        public Task<string> GetEstimatedFare();
    }
}
