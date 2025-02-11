using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;
using LogisticsDeliveryManagementSystem.Repositories;

namespace LogisticsDeliveryManagementSystem.Services
{
    public class PackageService
    {
        private readonly IPackageRepository _packageRepository;

        public PackageService(IPackageRepository packageRepository)
        {
            _packageRepository = packageRepository;
        }

        public async Task<List<Package>> GetAllPackagesAsync()
        {
            return await _packageRepository.GetAllPackagesAsync();
        }

        public async Task<Package> GetPackageByIdAsync(string id)
        {
            return await _packageRepository.GetPackageByIdAsync(id);
        }

        public async Task AddPackageAsync(Package package)
        {
            // Business logic: Ensure weight is positive before adding
            if (package.Weight <= 0)
            {
                throw new ArgumentException("Package weight must be greater than zero.");
            }

            package.Status = PackageStatus.Pending; // Default status
            await _packageRepository.AddPackageAsync(package);
        }

        public async Task UpdatePackageAsync(string id, Package package)
        {
            await _packageRepository.UpdatePackageAsync(id, package);
        }

        public async Task MarkPackageAsDeliveredAsync(string id)
        {
            var package = await _packageRepository.GetPackageByIdAsync(id);
            if (package == null) throw new KeyNotFoundException("Package not found.");

            package.Status = PackageStatus.Delivered;
            await _packageRepository.UpdatePackageAsync(id, package);
        }
    }
}
