using AutoMapper;
using MediatR;
using SmartInventory.Application.Items.Queries.GetItems;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetItemById
{
    public class GetItemByIdQueryHandler : IRequestHandler<GetItemByIdQuery, ItemViewModel>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemByIdQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemViewModel> Handle(GetItemByIdQuery request, CancellationToken cancellationToken)
        {
            Item item = await _itemRepository.GetItemById(request.ItemId);
            ItemViewModel itemView = _mapper.Map<ItemViewModel>(item);
            return itemView;
        }
    }
}
