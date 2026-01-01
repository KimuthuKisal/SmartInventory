using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Queries.GetTotalProfitForGivrnRange
{
    public class GetTotalProfitForGivrnRangeQuery : IRequest<float>
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
