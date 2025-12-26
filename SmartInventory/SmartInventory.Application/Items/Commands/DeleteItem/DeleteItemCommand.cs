using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommand : IRequest<int>
    {
        public int ItemId { get; set; }
    }
}
