using AutoMapper;
using MediatR;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Commands.DeleteItem
{
    public class DeleteItemCommandHandler : IRequestHandler<DeleteItemCommand, int>
    {
        private readonly IItemRepository _itemRepository;

        public DeleteItemCommandHandler(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }
        public async Task<int> Handle(DeleteItemCommand request, CancellationToken cancellationToken)
        {
            int deleteStatus = await _itemRepository.DeleteItem(request.ItemId);
            return deleteStatus;
        }
    }
}
