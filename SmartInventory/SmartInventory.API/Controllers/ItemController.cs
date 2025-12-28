using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
    }
}
