using AutoMapper;
using MediatR;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Queries.GetTotalProfitForGivrnRange
{
    public class GetTotalProfitForGivrnRangeQueryHandler : IRequestHandler<GetTotalProfitForGivrnRangeQuery, float>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetTotalProfitForGivrnRangeQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<float> Handle(GetTotalProfitForGivrnRangeQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetTotalProfitForGivenRange(request.StartDate, request.EndDate);
        }
    }
}
