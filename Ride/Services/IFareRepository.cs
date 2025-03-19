using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ride.Models;
namespace Ride.Services
{
    public interface IFareRepository
    {      
        public Task<Fare> GetFareByIdAsync(int fareId);
        public Task AddFareAsync(Fare fare);
        public Task UpdateFareAsync(Fare fare);
        public Task DeleteFareAsync(int fareId);
    }    
}
