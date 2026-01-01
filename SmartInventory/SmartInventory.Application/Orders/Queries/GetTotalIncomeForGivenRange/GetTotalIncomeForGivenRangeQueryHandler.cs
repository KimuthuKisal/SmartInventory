using AutoMapper;
using MediatR;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Queries.GetTotalIncomeForGivenRange
{
    public class GetTotalIncomeForGivenRangeQueryHandler : IRequestHandler<GetTotalIncomeForGivenRangeQuery, float>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetTotalIncomeForGivenRangeQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<float> Handle(GetTotalIncomeForGivenRangeQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetTotalIncomeForGivenRange(request.StartDate, request.EndDate);
        }
    }
}
