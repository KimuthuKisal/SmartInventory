using AutoMapper;
using MediatR;
using SmartInventory.Application.Customers.Queries.GetAllCustomers;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Commands.ChangeLoyaltyDiscount
{
    public class ChangeLoyaltyDiscountCommandHandler : IRequestHandler<ChangeLoyaltyDiscountCommand, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public ChangeLoyaltyDiscountCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerViewModel> Handle(ChangeLoyaltyDiscountCommand request, CancellationToken cancellationToken)
        {
            Customer customer = await _customerRepository.ChangeCustomerLoyaltyDiscount(request.Id, request.LoyaltyDiscount);
            CustomerViewModel customerView = _mapper.Map<CustomerViewModel>(customer);
            return customerView;
        }
    }
}
