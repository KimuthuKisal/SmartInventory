using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Commands.AddOrder
{
    public class AddOrderCommand : IRequest<GetOrderDto>
    {
        public Order OrderDetails { get; set; }
        public List<OrderItem> OrderItemDetails { get; set; }
    }
}
