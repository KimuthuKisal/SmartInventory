using MediatR;
using SmartInventory.Application.Items.Queries.GetItems;
using SmartInventory.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetItemsBySearch
{
    public class GetItemsBySearchCommand : IRequest<List<ItemViewModel>>
    {
        public string SearchString { get; set; }
    }
}
