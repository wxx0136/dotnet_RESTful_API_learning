using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI.Entities;

namespace NETAPI.Repositories
{
    public class InMemItemsRepository : IItemsRepository
    {
        private readonly List<Item> _items = new()
        {
            new Item {Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreateDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Iron Sword", Price = 20, CreateDate = DateTimeOffset.UtcNow},
            new Item {Id = Guid.NewGuid(), Name = "Bronze Shield", Price = 18, CreateDate = DateTimeOffset.UtcNow}
        };

        public async Task<IEnumerable<Item>> GetItemsAsync()
        {
            return await Task.FromResult(_items);
        }

        public async Task<Item> GetItemAsync(Guid id)
        {
            return await Task.FromResult(_items.SingleOrDefault(item => item.Id == id));

        }

        public async Task CreateItemAsync(Item item)
        {
            _items.Add(item);
            await Task.CompletedTask;
        }

        public async Task UpdateItemAsync(Item item)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == item.Id);
            _items[index] = item;
            await Task.CompletedTask;
        }

        public async Task DeleteItemAsync(Guid id)
        {
            var index = _items.FindIndex(existingItem => existingItem.Id == id);
            _items.Remove(_items[index]);
            await Task.CompletedTask;
        }
    }
}