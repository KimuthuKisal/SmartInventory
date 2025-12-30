using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Repository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAllCustomers();
        Task<List<Customer>> GetAllLoyaltyCustomers();
        Task<Customer> GetCustomerById(int id);
        Task<Customer> CreateNewCustomer(Customer customer);
        Task<Customer> UpdateCutomer(int id, Customer customer);
        Task<Customer> ChangeCustomerLoyaltyDiscount(int id, float discount);
        Task<int> UpdateLoyaltyPoints(int id, float totalBillAmount, float redeemLoyaltyPointsAmount);

    }
}
