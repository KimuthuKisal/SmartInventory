using MediatR;
using SmartInventory.Application.Customers.Queries.GetAllCustomers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Queries.GetAllLoyaltyCustomers
{
    public class GetLoyaltyCustomerQuery : IRequest<List<CustomerViewModel>>
    {
    }
}
