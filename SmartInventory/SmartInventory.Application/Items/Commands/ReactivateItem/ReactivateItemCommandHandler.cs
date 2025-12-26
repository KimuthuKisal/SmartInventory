using MediatR;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.ReactivateItem
{
    public class ReactivateItemCommandHandler : IRequestHandler<ReactivateItemCommand, int>
    {
        private readonly IItemRepository _itemRepository;

        public ReactivateItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        public async Task<int> Handle(ReactivateItemCommand request, CancellationToken cancellationToken)
        {
            int reactivateStatus = await _itemRepository.ReactivateItem(request.ItemId);
            return reactivateStatus;
        }
    }
}
