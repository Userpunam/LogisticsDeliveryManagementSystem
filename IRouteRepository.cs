using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;

namespace LogisticsDeliveryManagementSystem.Repositories
{
    public interface IRouteRepository
    {
        Task<List<Route>> GetAllRoutesAsync();
        Task<Route> GetRouteByIdAsync(string id);
        Task AddRouteAsync(Route route);
        Task UpdateRouteAsync(string id, Route route);
        Task DeleteRouteAsync(string id);
    }
}
