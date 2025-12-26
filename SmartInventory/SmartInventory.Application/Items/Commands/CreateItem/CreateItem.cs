using SmartInventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.CreateItem
{
    public class CreateItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ItemType Type { get; set; }
        public float Count { get; set; }
        public ItemFrquency Frequency { get; set; }
        public float UnitPriceBuy { get; set; }
        public float UnitPriceSell { get; set; }
        public float Discount { get; set; }
        public float TransportCost { get; set; }
        public ItemTransportTypes TransportType { get; set; }
        public float LoadingCost { get; set; }
        public ItemLoadingTypes LoadingType { get; set; }
        public ItemActiveStatus ActiveStatus { get; set; }
    }
}
