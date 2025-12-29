using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Items.Commands.CreateItem;
using SmartInventory.Application.Items.Queries.GetActiveItems;
using SmartInventory.Application.Items.Queries.GetDeactiveItems;
using SmartInventory.Application.Items.Queries.GetItemById;
using SmartInventory.Application.Items.Queries.GetItems;

namespace SmartInventory.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> GetAllItemsAsync()
        {
            var itemList = await mediator.Send(new GetItemQuery());
            return Ok(itemList);
        }

        [HttpGet("active")]
        public async Task<IActionResult> GetAllActiveItemsAsync()
        {
            var itemList = await mediator.Send(new GetActiveItemQuery());
            return Ok(itemList);
        }

        [HttpGet("deactive")]
        public async Task<IActionResult> GetAllDeactiveItemsAsync()
        {
            var itemList = await mediator.Send(new GetDeactiveQuery());
            return Ok(itemList);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemByIdAsync(int id)
        {
            var item = await mediator.Send(new GetItemByIdQuery() { ItemId = id });

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);
        }

        [HttpPost]
        public async Task<IActionResult> CreateItemAsync(CreateItemCommand command)
        {
            ItemViewModel createdItem = await mediator.Send(command);
            return Ok(createdItem);
        }
    }
}
