using AutoMapper;
using MediatR;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Commands.UpdateLoyaltyPoints
{
    public class UpdateLoyaltyPointsCommandHandler : IRequestHandler<UpdateLoyaltyPointsCommand, int>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateLoyaltyPointsCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(UpdateLoyaltyPointsCommand request, CancellationToken cancellationToken)
        {
            int status = await _customerRepository.UpdateLoyaltyPoints(request.Id, request.TotalBillAmount, request.RedeemLoyaltyPointsAmount);
            return status;
        }
    }
}
