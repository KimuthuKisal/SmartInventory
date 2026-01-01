using AutoMapper;
using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Items.Queries.GetTopSellingItems
{
    public class GetTopSellingItemQueryHandler : IRequestHandler<GetTopSellingItemQuery, List<TopSellingItemDto>>
    {
        private readonly IItemRepository _itemRepository;
        private readonly IMapper _mapper;

        public GetTopSellingItemQueryHandler(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }
        public async Task<List<TopSellingItemDto>> Handle(GetTopSellingItemQuery request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetTopSellingItems(request.StartDate, request.EndDate);
        }
    }
}
