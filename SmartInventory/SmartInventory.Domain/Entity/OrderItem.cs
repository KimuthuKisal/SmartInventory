using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class OrderItem
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ItemId { get; set; }
        public string Unit { get; set; }
        public float UnitPrice { get; set; }
        public float OrderAmount { get; set; }
        public float TotalPrice { get; set; }
        public float StandardDiscount { get; set; }
        public float LoyaltyDiscount { get; set; }
        public float TotalDiscount { get; set; }
        public float DiscountedTotalPrice { get; set; }
        public float TotalRevenue { get; set; }
        public float TotalProfit { get; set; }
        public float TransportCost { get; set; }
        public float LoadingCost { get; set; }
    }
}
