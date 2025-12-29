using MediatR;
using SmartInventory.Application.Items.Queries.GetItems;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetActiveItems
{
    public class GetActiveItemQuery : IRequest<List<ItemViewModel>>
    {
    }
}
