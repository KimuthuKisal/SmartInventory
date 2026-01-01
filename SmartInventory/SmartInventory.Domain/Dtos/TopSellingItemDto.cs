using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Dtos
{
    public class TopSellingItemDto
    {
        public Item Item { get; set; }
        public float TotalSold { get; set; }
    }
}
