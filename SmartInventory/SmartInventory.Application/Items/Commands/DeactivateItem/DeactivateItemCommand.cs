using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.DeactivateItem
{
    public class DeactivateItemCommand : IRequest<int>
    {
        public int ItemId { get; set; }
    }
}
