using AutoMapper;
using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Queries.GetOrderById
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, GetOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<GetOrderDto> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetOrderById(request.OrderId);
        }
    }
}
