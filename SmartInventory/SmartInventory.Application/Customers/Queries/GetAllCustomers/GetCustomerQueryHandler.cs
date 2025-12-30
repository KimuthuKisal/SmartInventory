using AutoMapper;
using MediatR;
using SmartInventory.Domain.Entity;
using SmartInventory.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace SmartInventory.Application.Customers.Queries.GetAllCustomers
{
    public class GetCustomerQueryHandler : IRequestHandler<GetCustomerQuery, List<CustomerViewModel>>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IMapper _mapper;

        public GetCustomerQueryHandler(ICustomerRepository customerRepository, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _mapper = mapper;
        }

        public async Task<List<CustomerViewModel>> Handle(GetCustomerQuery request, CancellationToken cancellationToken)
        {
            List<Customer> customerList = await _customerRepository.GetAllCustomers();

            List<CustomerViewModel> customerViewList = _mapper.Map<List<CustomerViewModel>>(customerList);

            return customerViewList;
        }
    }
}
