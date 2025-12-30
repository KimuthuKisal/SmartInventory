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

namespace SmartInventory.Application.Customers.Commands.UpdateCustomer
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, CustomerViewModel>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<CustomerViewModel> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer requestCustomer = new Customer
            {
                Id = request.Id,
                Name = request.Name,
                RegisteredDate = request.RegisteredDate,
                Address = request.Address,
                PhoneNumber = request.PhoneNumber,
                LoyaltyDiscount = request.LoyaltyDiscount,
                TotalPurchases = request.TotalPurchases,
                TotalPurchaseAmount = request.TotalPurchaseAmount,
                TotalLoyaltyPoints = request.TotalLoyaltyPoints
            };

            Customer customer = await _customerRepository.UpdateCutomer(request.Id, requestCustomer);
            CustomerViewModel customerView = _mapper.Map<CustomerViewModel>(customer);
            return customerView;
        }
    }
}
