using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;
using LogisticsDeliveryManagementSystem.Repositories;

namespace LogisticsDeliveryManagementSystem.Services
{
    public class RouteService
    {
        private readonly IRouteRepository _routeRepository;
        private readonly IPackageRepository _packageRepository;

        public RouteService(IRouteRepository routeRepository, IPackageRepository packageRepository)
        {
            _routeRepository = routeRepository;
            _packageRepository = packageRepository;
        }

        public async Task<List<Route>> GetAllRoutesAsync()
        {
            return await _routeRepository.GetAllRoutesAsync();
        }

        public async Task<Route> GetRouteByIdAsync(string id)
        {
            return await _routeRepository.GetRouteByIdAsync(id);
        }

        public async Task AddRouteAsync(Route route)
        {
            if (route.PackageIDs == null || route.PackageIDs.Count == 0)
            {
                throw new ArgumentException("A route must have at least one package assigned.");
            }

            route.Status = RouteStatus.Pending; // Default status
            await _routeRepository.AddRouteAsync(route);
        }

        public async Task UpdateRouteAsync(string id, Route route)
        {
            await _routeRepository.UpdateRouteAsync(id, route);
        }

        public async Task<double> CalculateRouteDistance(string id)
        {
            var route = await _routeRepository.GetRouteByIdAsync(id);
            if (route == null)
            {
                throw new KeyNotFoundException("Route not found.");
            }

            // TODO: Implement actual distance calculation logic
            return 10.5;  // Dummy value
        }
    }
}
