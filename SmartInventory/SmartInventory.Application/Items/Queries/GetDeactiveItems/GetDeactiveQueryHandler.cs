using AutoMapper;
using MediatR;
using SmartInventory.Application.Items.Queries.GetActiveItems;
using SmartInventory.Application.Items.Queries.GetItems;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetDeactiveItems
{
    public class GetDeactiveQueryHandler : IRequestHandler<GetDeactiveQuery, List<ItemViewModel>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetDeactiveQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<ItemViewModel>> Handle(GetDeactiveQuery request, CancellationToken cancellationToken)
        {
            List<Item> itemList = await _itemRepository.GetAllDectiveItems();

            List<ItemViewModel> itemViewList = _mapper.Map<List<ItemViewModel>>(itemList);

            return itemViewList;
        }
    }
}
