using MediatR;
using SmartInventory.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Queries.GetAllOrders
{
    public class GetOrdersQuery : IRequest<List<GetOrderDto>>
    {
    }
}
