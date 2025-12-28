using Microsoft.EntityFrameworkCore;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Infrastructure.Data
{
    public class SmartInventoryDbContext : DbContext
    {
        public SmartInventoryDbContext(DbContextOptions<SmartInventoryDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }
}
