using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetTopSellingItems
{
    public class GetTopSellingItemQuery : IRequest<List<TopSellingItemDto>>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
