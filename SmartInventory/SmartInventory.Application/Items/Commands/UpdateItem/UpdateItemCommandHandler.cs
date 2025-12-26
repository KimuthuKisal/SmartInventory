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

namespace SmartInventory.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, ItemViewModel>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public UpdateItemCommandHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ItemViewModel> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            Item requestItem = new Item
            {
                Id = request.Id,
                Name = request.Name,
                Description = request.Description,
                Type = request.Type,
                Count = request.Count,
                Frequency = request.Frequency,
                UnitPriceBuy = request.UnitPriceBuy,
                UnitPriceSell = request.UnitPriceSell,
                Discount = request.Discount,
                TransportCost = request.TransportCost,
                TransportType = request.TransportType,
                LoadingCost = request.LoadingCost,
                LoadingType = request.LoadingType,
                ActiveStatus = request.ActiveStatus
            };
            Item item = await _itemRepository.UpdateItem(request.Id, requestItem);
            ItemViewModel itemView = _mapper.Map<ItemViewModel>(item);
            return itemView;
        }
    }
}
