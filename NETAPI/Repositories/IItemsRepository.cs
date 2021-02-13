using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI.Entities;

namespace NETAPI.Repositories
{
    public interface IItemsRepository
    {
        IEnumerable<Item> GetItems();
        Item GetItem(Guid id);
    }

    
}