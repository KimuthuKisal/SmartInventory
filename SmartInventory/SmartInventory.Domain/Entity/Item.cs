using SmartInventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Domain.Entity
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }                          // Metal, Wood, Plastic, Glass, Concrete, Aluminium, Paper, Oil, Tape, Powder, Other, Clay
        public float Count { get; set; }
        public string Frequency { get; set; }                 // High -> H, Medium -> M, Low -> L
        public float UnitPriceBuy { get; set; }
        public float UnitPriceSell { get; set; }
        public float Discount { get; set; }
        public float TransportCost { get; set; }
        public string TransportType { get; set; }       // Per Unit -> S, For all -> A
        public float LoadingCost { get; set; }
        public string LoadingType { get; set; }           // Per Unit -> S, For all -> A
        public ItemActiveStatus ActiveStatus { get; set; }          // Active -> 1, Deactive -> 0, Deleted -> -1
    }
}
