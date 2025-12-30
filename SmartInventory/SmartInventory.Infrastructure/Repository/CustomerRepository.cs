using Microsoft.EntityFrameworkCore;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using SmartInventory.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Infrastructure.Repository
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly SmartInventoryDbContext _context;

        public CustomerRepository(SmartInventoryDbContext smartInventoryDbContext)
        {
            _context = smartInventoryDbContext;
        }

        public async Task<Customer> ChangeCustomerLoyaltyDiscount(int id, float discount)
        {
            await _context.Customers.Where(cus => cus.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(i => i.LoyaltyDiscount, discount)
            );

            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(cus => cus.Id == id);
        }

        public async Task<Customer> CreateNewCustomer(Customer customer)
        {
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
            return customer;
        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<List<Customer>> GetAllLoyaltyCustomers()
        {
            DateTime currentDateTime = DateTime.Today;
            DateTime loyaltyDateTime = currentDateTime.AddYears(-1);
            return await _context.Customers.Where(cus => cus.RegisteredDate.Date<=loyaltyDateTime).ToListAsync();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(cus => cus.Id == id);
        }

        public async Task<Customer> UpdateCutomer(int id, Customer customer)
        {
            await _context.Customers.Where(cus => cus.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(c => c.Name, customer.Name)
                .SetProperty(c => c.Address, customer.Address)
                .SetProperty(c => c.PhoneNumber, customer.PhoneNumber)
                .SetProperty(c => c.LoyaltyDiscount, customer.LoyaltyDiscount)
            );

            return await _context.Customers.AsNoTracking().FirstOrDefaultAsync(cus => cus.Id == id);
        }

        public async Task<int> UpdateLoyaltyPoints(int id, float totalBillAmount, float redeemLoyaltyPointsAmount)
        {
            Customer customer = await GetCustomerById(id);

            return await _context.Customers.Where(cus => cus.Id == id).ExecuteUpdateAsync(setter => setter
                .SetProperty(c => c.TotalPurchases, customer.TotalPurchases+1)
                .SetProperty(c => c.TotalPurchaseAmount, customer.TotalPurchaseAmount + totalBillAmount)
                .SetProperty(c => c.TotalLoyaltyPoints, customer.TotalLoyaltyPoints - redeemLoyaltyPointsAmount)
            );
        }
    }
}
