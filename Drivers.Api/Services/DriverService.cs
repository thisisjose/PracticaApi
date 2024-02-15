using Drivers.Api.Configurations;
using Drivers.Api.Models;
using Microsoft.Extensions.Options;
using MongoDB.Drive;

namespace Drivers.Api.Services;
{
    private readonly IMongoCollection<Drive> _driversCollection;
    public DriverServices(
        IOptions<DatabaseSettings> databaseSettings)
        {
            var mongoClient = new MongoClient(databaseSettings.Value.ConnectionsString);
            var mongoDB = mongoClient.GetDatabase(databaseSettings.Value.DatabaseName);
            _driversCollection = mongoDB.GetCollection<Drive>(databaseSettings.Value.CollectionName);
        }
        public async Task<List<Drive>> GetAsync() =>
        await _driversCollection.Find(_ => true).ToListAsync();
}