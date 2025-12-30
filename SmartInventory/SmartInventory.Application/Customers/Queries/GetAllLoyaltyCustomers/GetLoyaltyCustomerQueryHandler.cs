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

namespace SmartInventory.Application.Customers.Queries.GetAllLoyaltyCustomers
{
    public class GetLoyaltyCustomerQueryHandler : IRequestHandler<GetLoyaltyCustomerQuery, List<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetLoyaltyCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerViewModel>> Handle(GetLoyaltyCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customerList = await _customerRepository.GetAllLoyaltyCustomers();

            List<CustomerViewModel> customerViewList = _mapper.Map<List<CustomerViewModel>>(customerList);

            return customerViewList;
        }
    }
}
