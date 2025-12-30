using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Queries.GetAllCustomers
{
    public class GetCustomerQuery : IRequest<List<CustomerViewModel>>
    {
    }
}
