using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SmartInventory.Domain.Repository;
using SmartInventory.Infrastructure.Data;
using SmartInventory.Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Infrastructure
{
    public static class ConfigureServices
    {
        public static IServiceCollection AddInfrastructureServices (this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<SmartInventoryDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("SmartInventoryDatabase") ?? throw new InvalidOperationException("Connection string not found"));
            });

            services.AddTransient<IItemRepository, ItemRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();

            return services;
        }
    }
}
