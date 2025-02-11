using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;

namespace LogisticsDeliveryManagementSystem.Repositories
{
    public interface IPackageRepository
    {
        Task<List<Package>> GetAllPackagesAsync();
        Task<Package> GetPackageByIdAsync(string id);
        Task<Package> AddPackageAsync(Package package);
        Task UpdatePackageAsync(string id, Package package);
        Task DeletePackageAsync(string id);
        Task MarkPackageAsDeliveredAsync(string id);
    }
}
