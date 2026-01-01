using AutoMapper;
using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Queries.GetAllOrders
{
    public class GetOrdersQueryHandler : IRequestHandler<GetOrdersQuery, List<GetOrderDto>>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrdersQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<List<GetOrderDto>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetAllOrders();
        }
    }
}
