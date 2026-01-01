using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Orders.Commands.AddOrder;
using SmartInventory.Application.Orders.Queries.GetAllOrders;
using SmartInventory.Application.Orders.Queries.GetOrderById;
using SmartInventory.Application.Orders.Queries.GetTotalIncomeForGivenRange;
using SmartInventory.Application.Orders.Queries.GetTotalProfitForGivrnRange;
using SmartInventory.Domain.Dtos;

namespace SmartInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllOrdersAsync()
        {
            var orderList = await mediator.Send(new GetOrdersQuery());
            return Ok(orderList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOrderByIdAsync(int id)
        {
            var order = await mediator.Send(new GetOrderByIdQuery() { OrderId = id });
            return Ok(order);
        }

        [HttpGet("income/{startDate}/{endDate}")]
        public async Task<IActionResult> GetTotalIncomeAsync(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                return BadRequest("Start date should be before End date");
            }
            float totalIncome = await mediator.Send(new GetTotalIncomeForGivenRangeQuery() { StartDate = startDate, EndDate = endDate});
            return Ok(totalIncome);
        }

        [HttpGet("profit/{startDate}/{endDate}")]
        public async Task<IActionResult> GetTotalProfitAsync(DateTime startDate, DateTime endDate)
        {
            if (endDate < startDate)
            {
                return BadRequest("Start date should be before End date");
            }
            float totalIncome = await mediator.Send(new GetTotalProfitForGivrnRangeQuery() { StartDate = startDate, EndDate = endDate });
            return Ok(totalIncome);
        }

        [HttpPost]
        public async Task<IActionResult> AddNewOrderAsync(AddOrderCommand command)
        {
            var createdOrder = await mediator.Send(command);
            return Ok(createdOrder);
        }
    }
}
