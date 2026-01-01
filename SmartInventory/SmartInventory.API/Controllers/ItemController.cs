using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartInventory.Application.Items.Commands.CreateItem;
using SmartInventory.Application.Items.Commands.DeactivateItem;
using SmartInventory.Application.Items.Commands.DeleteItem;
using SmartInventory.Application.Items.Commands.ReactivateItem;
using SmartInventory.Application.Items.Commands.UpdateItem;
using SmartInventory.Application.Items.Queries.GetActiveItems;
using SmartInventory.Application.Items.Queries.GetDeactiveItems;
using SmartInventory.Application.Items.Queries.GetItemById;
using SmartInventory.Application.Items.Queries.GetItems;
using SmartInventory.Application.Items.Queries.GetItemsByCategory;
using SmartInventory.Application.Items.Queries.GetItemsBySearch;
using SmartInventory.Application.Items.Queries.GetTopSellingItems;
using SmartInventory.Domain.Dtos;

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

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateItemAsync(UpdateItemCommand command)
        {
            ItemViewModel updatedItem = await mediator.Send(command);
            return Ok(updatedItem);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemAsync(int id)
        {
            int status = await mediator.Send(new DeleteItemCommand {  ItemId = id });
            if (status > 0)
            {
                return Ok("Item delete success.");
            }
            else
            {
                return Ok("Item delete unsuccess.");
            }
        }

        [HttpPut("reactivate/{id}")]
        public async Task<IActionResult> ReactivateItemAsync(int id)
        {
            int status = await mediator.Send(new ReactivateItemCommand { ItemId = id });
            if (status > 0)
            {
                return Ok("Item reactivation success.");
            }
            else
            {
                return Ok("Item reactivation unsuccess.");
            }
        }

        [HttpPut("deactivate/{id}")]
        public async Task<IActionResult> DectivateItemAsync(int id)
        {
            int status = await mediator.Send(new DeactivateItemCommand { ItemId = id });
            if (status > 0)
            {
                return Ok("Item deactivation success.");
            }
            else
            {
                return Ok("Item deactivation unsuccess.");
            }
        }

        [HttpGet("getByCategory/{type}")]
        public async Task<IActionResult> GetItemsByCategoryAsync(string type)
        {
            List<ItemViewModel> itemList = await mediator.Send(new GetItemsByCategoryCommand { Type = type });
            return Ok(itemList);
        }

        [HttpGet("searchItem/{search}")]
        public async Task<IActionResult> GetItemsBySearchAsync(string search)
        {
            List<ItemViewModel> itemList = await mediator.Send(new GetItemsBySearchCommand { SearchString = search });
            return Ok(itemList);
        }

        [HttpGet("topSelling/{startDate}/{endDate}")]
        public async Task<IActionResult> GetTopSellingItems(DateTime startDate, DateTime endDate)
        {
            List<TopSellingItemDto> itemlist = await mediator.Send(new GetTopSellingItemQuery { StartDate = startDate, EndDate = endDate }); 
            return Ok(itemlist);
        }
    }
}
