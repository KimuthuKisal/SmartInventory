using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Dtos
{
    public class UpdateOrderDto
    {
        public Order OrderDetails {  get; set; }
        public List<OrderItem> OrderItemDetails { get; set; }
    }
}
