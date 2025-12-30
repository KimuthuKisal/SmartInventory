using MediatR;
using SmartInventory.Application.Customers.Queries.GetAllCustomers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdQuery : IRequest<CustomerViewModel>
    {
        public int CustomerId { get; set; }
    }
}
