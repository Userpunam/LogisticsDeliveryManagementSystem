using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;

namespace LogisticsDeliveryManagementSystem.Repositories
{
    public interface IDriverRepository
    {
        Task<List<Driver>> GetAllDriversAsync();
        Task<Driver> GetDriverByIdAsync(string id);
        Task AddDriverAsync(Driver driver);
        Task UpdateDriverAsync(string id, Driver driver);
        Task DeleteDriverAsync(string id);
    }
}
