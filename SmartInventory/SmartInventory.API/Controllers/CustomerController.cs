using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Customers.Commands.ChangeLoyaltyDiscount;
using SmartInventory.Application.Customers.Commands.CreateCustomer;
using SmartInventory.Application.Customers.Commands.UpdateCustomer;
using SmartInventory.Application.Customers.Commands.UpdateLoyaltyPoints;
using SmartInventory.Application.Customers.Queries.GetAllCustomers;
using SmartInventory.Application.Customers.Queries.GetAllLoyaltyCustomers;
using SmartInventory.Application.Customers.Queries.GetCustomerById;
using SmartInventory.Application.Items.Commands.CreateItem;
using SmartInventory.Application.Items.Commands.UpdateItem;
using SmartInventory.Application.Items.Queries.GetItemById;
using SmartInventory.Application.Items.Queries.GetItems;

namespace SmartInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllCustomersAsync()
        {
            var customerList = await mediator.Send(new GetCustomerQuery());
            return Ok(customerList);
        }

        [HttpGet("loyaltyCustomers")]
        public async Task<IActionResult> GetAllLoyaltyCustomersAsync()
        {
            var customerList = await mediator.Send(new GetLoyaltyCustomerQuery());
            return Ok(customerList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCustomerByIdAsync(int id)
        {
            var customer = await mediator.Send(new GetCustomerByIdQuery() { CustomerId = id });

            if (customer == null)
            {
                return NotFound();
            }

            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomerAsync(CreateCustomerCommand command)
        {
            CustomerViewModel customer = await mediator.Send(command);
            return Ok(customer);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomerAsync(UpdateCustomerCommand command)
        {
            CustomerViewModel customer = await mediator.Send(command);
            return Ok(customer);
        }

        [HttpPut("changeLoyaltyDiscount/{id}")]
        public async Task<IActionResult> UpdateCustomerLoyatyDiscount(ChangeLoyaltyDiscountCommand command)
        {
            CustomerViewModel customer = await mediator.Send(command);
            return Ok(customer);
        }

        [HttpPut("changeLoyaltyPoints/{id}")]
        public async Task<IActionResult> UpdateCustomerLoyatyPoints(UpdateLoyaltyPointsCommand command)
        {
            int status = await mediator.Send(command);
            if (status > 0)
            {
                return Ok("Loyalty point update success.");
            }
            else
            {
                return Ok("Loyalty point update unsuccess.");
            }
        }
    }
}
