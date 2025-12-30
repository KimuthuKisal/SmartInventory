using MediatR;
using SmartInventory.Application.Customers.Queries.GetAllCustomers;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Commands.ChangeLoyaltyDiscount
{
    public class ChangeLoyaltyDiscountCommand : IRequest<CustomerViewModel>
    {
        public int Id { get; set; }
        public float LoyaltyDiscount { get; set; }
    }
}
