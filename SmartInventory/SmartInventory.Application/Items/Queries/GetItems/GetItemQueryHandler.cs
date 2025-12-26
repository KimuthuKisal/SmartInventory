using AutoMapper;
using MediatR;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetItems
{
    public class GetItemQueryHandler : IRequestHandler<GetItemQuery, List<ItemViewModel>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetItemQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<ItemViewModel>> Handle(GetItemQuery request, CancellationToken cancellationToken)
        {
            List<Item> itemList = await _itemRepository.GetAllItems();

            //List<ItemViewModel> itemViewList = itemList.Select(x => new ItemViewModel
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description,
            //    Type = x.Type,
            //    Count = x.Count,
            //    Frequency = x.Frequency,
            //    UnitPriceBuy = x.UnitPriceBuy,
            //    UnitPriceSell = x.UnitPriceSell,
            //    Discount = x.Discount,
            //    TransportCost = x.TransportCost,
            //    TransportType = x.TransportType,
            //    LoadingCost = x.LoadingCost,
            //    LoadingType = x.LoadingType,
            //    ActiveStatus = x.ActiveStatus
            //}).ToList();

            List<ItemViewModel> itemViewList = _mapper.Map<List<ItemViewModel>>(itemList);

            return itemViewList;
        }
    }
}
