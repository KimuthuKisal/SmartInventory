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

namespace SmartInventory.Application.Items.Queries.GetItemsBySearch
{
    public class GetItemsBySearchCommandHandler : IRequestHandler<GetItemsBySearchCommand, List<ItemViewModel>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsBySearchCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<List<ItemViewModel>> Handle(GetItemsBySearchCommand request, CancellationToken cancellationToken)
        {
            List<Item> itemList = await _itemRepository.GetActiveItemsBySearch(request.SearchString);

            List<ItemViewModel> itemViewList = _mapper.Map<List<ItemViewModel>>(itemList);

            return itemViewList;
        }
    }
}
