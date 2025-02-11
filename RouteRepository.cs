using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;
using Microsoft.Extensions.Options;
using LogisticsDeliveryManagementSystem.Configurations;

namespace LogisticsDeliveryManagementSystem.Repositories
{
    public class RouteRepository : IRouteRepository
    {
        private readonly IMongoCollection<Route> _routes;

        public RouteRepository(IOptions<MongoDbSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _routes = database.GetCollection<Route>("Routes");
        }

        public async Task<List<Route>> GetAllRoutesAsync() =>
            await _routes.Find(_ => true).ToListAsync();

        public async Task<Route> GetRouteByIdAsync(string id) =>
            await _routes.Find(r => r.Id == id).FirstOrDefaultAsync();

        public async Task AddRouteAsync(Route route) =>
            await _routes.InsertOneAsync(route);

        public async Task UpdateRouteAsync(string id, Route route) =>
            await _routes.ReplaceOneAsync(r => r.Id == id, route);

        public async Task DeleteRouteAsync(string id) =>
            await _routes.DeleteOneAsync(r => r.Id == id);
    }
}
