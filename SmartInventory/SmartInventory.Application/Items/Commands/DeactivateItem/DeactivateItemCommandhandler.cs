using MediatR;
using SmartInventory.Application.Items.Commands.DeleteItem;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.DeactivateItem
{
    public class DeactivateItemCommandhandler : IRequestHandler<DeactivateItemCommand, int>
    {
        private readonly IItemRepository _itemRepository;

        public DeactivateItemCommandhandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> Handle(DeactivateItemCommand request, CancellationToken cancellationToken)
        {
            int deleteStatus = await _itemRepository.DeleteItem(request.ItemId);
            return deleteStatus;
        }

    }
}
