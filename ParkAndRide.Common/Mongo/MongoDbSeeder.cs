using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkAndRide.Common.Mongo
{
    public class MongoDbSeeder
    {
        protected readonly IMongoDatabase _mongoDatabase;

        public MongoDbSeeder(IMongoDatabase mongoDatabase)
        {
            _mongoDatabase = mongoDatabase;
        }

        public async Task SeedAsync()
        {
            var cursor = await _mongoDatabase.ListCollectionsAsync();
            var collections = await cursor.ToListAsync();
            if (collections.Any())
            {
                return;
            }
            await Task.CompletedTask;
        }
    }
}
