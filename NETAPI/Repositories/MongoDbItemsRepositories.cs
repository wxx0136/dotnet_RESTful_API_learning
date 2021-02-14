using NETAPI.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;

namespace NETAPI.Repositories
{
    public class MongoDbItemsRepositories : IItemsRepository
    {

        // config a docker image locally:  docker run -d --rm --name mongo -p 27017:27017 -v mongodbdata:/data/db mongo
        private const string DatabaseName = "catalog";
        private const string CollectionName = "items";
        private readonly IMongoCollection<Item> _itemsCollection;
        private readonly FilterDefinitionBuilder<Item> _filterBuilder = Builders<Item>.Filter;

        public MongoDbItemsRepositories(IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(DatabaseName);
            _itemsCollection = database.GetCollection<Item>(CollectionName);
        }

        public async Task CreateItemAsync(Item item)
        {
            await _itemsCollection.InsertOneAsync(item);
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            await _itemsCollection.DeleteOneAsync(filter);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            return await _itemsCollection.Find(filter).SingleOrDefaultAsync();
        }

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await _itemsCollection.Find(new BsonDocument()).ToListAsync();
        }

        public async Task UpdateItemAsync(Item item)
        {
            var filter = _filterBuilder.Eq(existingItem => existingItem.Id, item.Id);
            await _itemsCollection.ReplaceOneAsync(filter, item);
        }
    }
}
