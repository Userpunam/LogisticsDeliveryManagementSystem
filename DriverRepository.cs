using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;
using Microsoft.Extensions.Options;
using LogisticsDeliveryManagementSystem.Configurations;
 
namespace LogisticsDeliveryManagementSystem.Repositories
{
    public class DriverRepository : IDriverRepository
    {
        private readonly IMongoCollection<Driver> _drivers;

        public DriverRepository(IOptions<MongoDbSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _drivers = database.GetCollection<Driver>("Drivers");
        }

        public async Task<List<Driver>> GetAllDriversAsync() =>
            await _drivers.Find(_ => true).ToListAsync();

        public async Task<Driver> GetDriverByIdAsync(string id) =>
            await _drivers.Find(d => d.Id == id).FirstOrDefaultAsync();

        public async Task AddDriverAsync(Driver driver) =>
            await _drivers.InsertOneAsync(driver);

        public async Task UpdateDriverAsync(string id, Driver driver) =>
            await _drivers.ReplaceOneAsync(d => d.Id == id, driver);

        public async Task DeleteDriverAsync(string id) =>
            await _drivers.DeleteOneAsync(d => d.Id == id);
    }
}
