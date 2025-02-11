using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;
using LogisticsDeliveryManagementSystem.Repositories;

namespace LogisticsDeliveryManagementSystem.Services
{
    public class DriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IPackageRepository _packageRepository;

        public DriverService(IDriverRepository driverRepository, IPackageRepository packageRepository)
        {
            _driverRepository = driverRepository;
            _packageRepository = packageRepository;
        }

        public async Task<List<Driver>> GetAllDriversAsync()
        {
            return await _driverRepository.GetAllDriversAsync();
        }

        public async Task<Driver> GetDriverByIdAsync(string id)
        {
            return await _driverRepository.GetDriverByIdAsync(id);
        }

        public async Task AddDriverAsync(Driver driver)
        {
            if (string.IsNullOrEmpty(driver.Name))
            {
                throw new ArgumentException("Driver name cannot be empty.");
            }

            await _driverRepository.AddDriverAsync(driver);
        }

        public async Task AssignDriverToPackageAsync(string driverId, string packageId)
        {
            var driver = await _driverRepository.GetDriverByIdAsync(driverId);
            var package = await _packageRepository.GetPackageByIdAsync(packageId);

            if (driver == null || package == null)
            {
                throw new KeyNotFoundException("Driver or Package not found.");
            }

            package.AssignedDriverID = driverId;
            await _packageRepository.UpdatePackageAsync(packageId, package);
        }
    }
}
