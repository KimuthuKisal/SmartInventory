using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Commands.UpdateLoyaltyPoints
{
    public class UpdateLoyaltyPointsCommand : IRequest<int>
    {
        public int Id { get; set; }
        public float TotalBillAmount { get; set; }
        public float RedeemLoyaltyPointsAmount { get; set; }
    }
}
