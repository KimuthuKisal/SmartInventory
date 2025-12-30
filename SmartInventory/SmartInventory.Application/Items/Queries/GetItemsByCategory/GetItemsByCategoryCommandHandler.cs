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

namespace SmartInventory.Application.Items.Queries.GetItemsByCategory
{
    public class GetItemsByCategoryCommandHandler : IRequestHandler<GetItemsByCategoryCommand, List<ItemViewModel>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemsByCategoryCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<List<ItemViewModel>> Handle(GetItemsByCategoryCommand request, CancellationToken cancellationToken)
        {
            List<Item> itemList = await _itemRepository.GetActiveItemsByCategory(request.Type);

            List<ItemViewModel> itemViewList = _mapper.Map<List<ItemViewModel>>(itemList);

            return itemViewList;
        }
    }
}
