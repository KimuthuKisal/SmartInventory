using SmartInventory.Application.Common.Mappings;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Queries.GetAllCustomers
{
    public class CustomerViewModel : IMapFrom<Customer>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public float LoyaltyDiscount { get; set; }
        public int TotalPurchases { get; set; }
        public float TotalPurchaseAmount { get; set; }
        public float TotalLoyaltyPoints { get; set; }
    }
}
