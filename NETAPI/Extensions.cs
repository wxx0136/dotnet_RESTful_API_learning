using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NETAPI.Dtos;
using NETAPI.Entities;

namespace NETAPI
{
    public static class Extensions
    {
        public static ItemDto AsDto(this Item item)
        {
            return new ItemDto()
            {
                Id = item.Id,
                Name = item.Name,
                Price = item.Price,
                CreateDate = item.CreateDate
            };
        }
    }
}
