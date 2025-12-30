using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Repository
{
    public interface IItemRepository
    {
        Task<List<Item>> GetAllItems();
        Task<List<Item>> GetAllActiveItems();
        Task<List<Item>> GetAllDectiveItems();
        Task<Item> GetItemById(int id);
        Task<Item> CreateItem(Item item);
        Task<Item> UpdateItem(int id, Item item);
        Task<int> DeleteItem(int id);
        Task<int> DeactivateItem(int id);
        Task<int> ReactivateItem(int id);
        Task<List<Item>> GetActiveItemsByCategory(string category);
        Task<List<Item>> GetActiveItemsBySearch(string searchString);
    }
}
