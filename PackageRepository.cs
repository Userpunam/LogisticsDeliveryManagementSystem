using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogisticsDeliveryManagementSystem.Models;
using Microsoft.Extensions.Options;
using LogisticsDeliveryManagementSystem.Configurations;
namespace LogisticsDeliveryManagementSystem.Repositories
{
    public class PackageRepository : IPackageRepository
    {
        private readonly IMongoCollection<Package> _packages;

        public PackageRepository(IOptions<MongoDbSettings> settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.Value.DatabaseName);
            _packages = database.GetCollection<Package>("Packages");
        }

        public async Task<List<Package>> GetAllPackagesAsync() =>
            await _packages.Find(_ => true).ToListAsync();

        public async Task<Package> GetPackageByIdAsync(string id) =>
            await _packages.Find(p => p.Id == id).FirstOrDefaultAsync();

        public async Task<Package> AddPackageAsync(Package package)
        {
            if (package == null)
            {
                throw new ArgumentNullException(nameof(package));
            }

            await _packages.InsertOneAsync(package);  // ✅ Insert into MongoDB
            return package;  // ✅ Return the inserted package
        }

        public async Task UpdatePackageAsync(string id, Package package) =>
            await _packages.ReplaceOneAsync(p => p.Id == id, package);

        public async Task DeletePackageAsync(string id) =>
            await _packages.DeleteOneAsync(p => p.Id == id);

        // ✅ Implementing the missing method
        public async Task MarkPackageAsDeliveredAsync(string id)
        {
            var filter = Builders<Package>.Filter.Eq(p => p.Id, id);
            var update = Builders<Package>.Update.Set(p => p.Status, PackageStatus.Delivered);

            var result = await _packages.UpdateOneAsync(filter, update);
            if (result.MatchedCount == 0)
            {
                throw new KeyNotFoundException("Package not found.");
            }
        }
    }
}
