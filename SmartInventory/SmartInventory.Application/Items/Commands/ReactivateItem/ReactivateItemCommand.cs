using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.ReactivateItem
{
    public class ReactivateItemCommand : IRequest<int>
    {
        public int ItemId { get; set; }
    }
}
