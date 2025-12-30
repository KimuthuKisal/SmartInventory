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

namespace SmartInventory.Application.Customers.Commands.CreateCustomer
{
    internal class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerViewModel> Handle(CreateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer requestCustomer = new Customer
            {
                Name = request.Name,
                RegisteredDate = DateTime.Now,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                LoyaltyDiscount = 0,
                TotalPurchases = 0,
                TotalPurchaseAmount = 0,
                TotalLoyaltyPoints = 0,
            };

            Customer customer = await _customerRepository.CreateNewCustomer(requestCustomer);
            CustomerViewModel customerView = _mapper.Map<CustomerViewModel>(customer);
            return customerView;

        }
    }
}
