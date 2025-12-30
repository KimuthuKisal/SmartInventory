using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDateTime { get; set; }
        public int CustomerId { get; set; }
        public string CustomerReference { get; set; }
        public float TotalPrice { get; set; }
        public float StandardDiscount { get; set; }
        public float LoyaltyDiscount { get; set; }
        public float TotalDiscount { get; set; }
        public float DiscountedTotalPrice { get; set; }
        public float TotalRevenue { get; set; }
        public float TotalProfit { get; set; }
        public int NumberOfItems { get; set; }
        public float LoyaltyPointsEarned { get; set; }
        public float LoyaltyPointsRedeemed { get; set; }
        public int SalespersonId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }
        public int ModifiedById { get; set; }
    }
}
