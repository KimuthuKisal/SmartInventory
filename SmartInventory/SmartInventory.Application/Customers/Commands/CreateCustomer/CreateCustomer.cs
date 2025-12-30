using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime RegisteredDate { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        //public float LoyaltyDiscount { get; set; } = 0;
        //public int TotalPurchases { get; set; } = 0;
        //public float TotalPurchaseAmount { get; set; } = 0;
        //public float TotalLoyaltyPoints { get; set; } = 0;
    }
}
