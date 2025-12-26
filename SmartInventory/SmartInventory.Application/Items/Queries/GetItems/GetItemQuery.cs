using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetItems
{
    public class GetItemQuery : IRequest<List<ItemViewModel>>
    {

    }
}
