using Microsoft.EntityFrameworkCore;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Enums;
using SmartInventory.Domain.Repository;
using SmartInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Infrastructure.Repository
{
    public class ItemRepository : IItemRepository
    {
        private readonly SmartInventoryDbContext _context;
        public ItemRepository(SmartInventoryDbContext smartInventoryDbContext)
        {
            _context = smartInventoryDbContext;
        }

        public async Task<Item> CreateItem(Item item)
        {
            await _context.Items.AddAsync(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public async Task<int> DeactivateItem(int id)
        {
            return await _context.Items.Where(it => it.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(i => i.ActiveStatus, ItemActiveStatus.Inactive)
            );
        }

        public async Task<int> DeleteItem(int id)
        {
            //return await _context.Items.Where(item => item.Id == id).ExecuteDeleteAsync();
            return await _context.Items.Where(it => it.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(i => i.ActiveStatus, ItemActiveStatus.Deleted)
            );
        }

        public async Task<List<Item>> GetActiveItemsByCategory(string category)
        {
            return await _context.Items.Where(item => item.Type == category).ToListAsync();
        }

        public async Task<List<Item>> GetActiveItemsBySearch(string searchString)
        {
            return await _context.Items.Where(item => item.Name.Contains(searchString) || item.Description.Contains(searchString)).ToListAsync();
        }

        public async Task<List<Item>> GetAllActiveItems()
        {
            return await _context.Items.Where(item => item.ActiveStatus == ItemActiveStatus.Active).ToListAsync();
        }

        public async Task<List<Item>> GetAllDectiveItems()
        {
            return await _context.Items.Where(item => item.ActiveStatus == ItemActiveStatus.Inactive).ToListAsync();
        }

        public async Task<List<Item>> GetAllItems()
        {
            return await _context.Items.ToListAsync();
        }

        public async Task<Item> GetItemById(int id)
        {
            return await _context.Items.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        }

        public async Task<int> ReactivateItem(int id)
        {
            return await _context.Items.Where(it => it.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(i => i.ActiveStatus, ItemActiveStatus.Active)
            );
        }

        public async Task<Item> UpdateItem(int id, Item item)
        {
            await _context.Items.Where(it => it.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(i => i.Name, item.Name)
                .SetProperty(i => i.Description, item.Description)
                .SetProperty(i => i.Type, item.Type)
                .SetProperty(i => i.Count, item.Count)
                .SetProperty(i => i.Frequency, item.Frequency)
                .SetProperty(i => i.UnitPriceBuy, item.UnitPriceBuy)
                .SetProperty(i => i.UnitPriceSell, item.UnitPriceSell)
                .SetProperty(i => i.Unit, item.Unit)
                .SetProperty(i => i.AmountPerUnit, item.AmountPerUnit)
                .SetProperty(i => i.Discount, item.Discount)
                .SetProperty(i => i.TransportCost, item.TransportCost)
                .SetProperty(i => i.TransportType, item.TransportType)
                .SetProperty(i => i.LoadingCost, item.LoadingCost)
                .SetProperty(i => i.LoadingType, item.LoadingType)
                .SetProperty(i => i.ActiveStatus, item.ActiveStatus)
            );

            return await _context.Items.AsNoTracking().FirstOrDefaultAsync(item => item.Id == id);
        }
    }
}
