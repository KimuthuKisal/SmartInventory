using AutoMapper;
using MediatR;
using SmartInventory.Domain.Dtos;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Orders.Commands.AddOrder
{
    public class AddOrderCommandHandler : IRequestHandler<AddOrderCommand, GetOrderDto>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IMapper _mapper;

        public AddOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
        {
            _orderRepository = orderRepository;
            _mapper = mapper;
        }
        public async Task<GetOrderDto> Handle(AddOrderCommand request, CancellationToken cancellationToken)
        {
            AddOrderDto addOrder = new AddOrderDto
            {
                OrderDetails = request.OrderDetails,
                OrderItemDetails = request.OrderItemDetails
            };

            return await _orderRepository.AddOrder(addOrder);
        }
    }
}
