using AutoMapper;
using SmartInventory.Application.Common.Mappings;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetItems
{
    public class ItemViewModel : IMapFrom<Item>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Type { get; set; }           
        public float Count { get; set; }
        public string Frequency { get; set; }
        public float UnitPriceBuy { get; set; }
        public float UnitPriceSell { get; set; }
        public float Discount { get; set; }
        public float TransportCost { get; set; }
        public string TransportType { get; set; }
        public float LoadingCost { get; set; }
        public string LoadingType { get; set; }
        public ItemActiveStatus ActiveStatus { get; set; }
    }
}
