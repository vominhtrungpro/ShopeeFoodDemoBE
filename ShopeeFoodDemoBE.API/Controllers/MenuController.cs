using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _imenuService;
        public MenuController(IMenuService imenuService)
        {
            _imenuService = imenuService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            var menu = await _imenuService.GetAllMenu();
            return Ok(menu);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            var menu = await _imenuService.GetMenuById(id);
            return Ok(menu);
        }

        [HttpGet("restaurantid-{id}")]
        public async Task<IActionResult> GetMenuByRestaurantId(int id)
        {
            var menu = await _imenuService.GetMenuByRestaurantId(id);
            return Ok(menu);
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu(MenuRequest request)
        {
            var menu = await _imenuService.AddMenu(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu(MenuRequest request)
        {
            var menu = await _imenuService.UpdateMenu(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            var menu = await _imenuService.DeleteMenu(id);
            return Ok();
        }
    }
}
