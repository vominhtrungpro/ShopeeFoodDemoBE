using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuService _menuService;
        private readonly ILogger<MenuController> _logger;

        public MenuController(IMenuService menuService, ILogger<MenuController> logger)
        {
            _menuService = menuService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllMenu()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all menu ");
            try
            {
                var menu = await _menuService.GetAllMenu();
                timer.Stop();
                _logger.LogInformation("Get all menu succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all menu ");
                return Ok(menu);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetMenuById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get menu by id ");
            try
            {
                var menu = await _menuService.GetMenuById(id);
                timer.Stop();
                _logger.LogInformation("Get menu by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get menu by id ");
                return Ok(menu);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpGet("restaurantid-{id}")]
        public async Task<IActionResult> GetMenuByRestaurantId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get menu by restaurant id ");
            try
            {
                var menu = await _menuService.GetMenuByRestaurantId(id);
                timer.Stop();
                _logger.LogInformation("Get menu by restaurant id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get menu by restaurant id ");
                return Ok(menu);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMenu(MenuRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add menu ");
            try
            {
                var menu = await _menuService.AddMenu(request);
                timer.Stop();
                _logger.LogInformation("Add menu name: {0},description: {1},status: {2},restaurand id: {3} succeed in {4} ms", request.MenuName, request.Description, request.Status, request.RestaurantId, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add menu ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateMenu(MenuRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update menu ");
            try
            {
                var menu = await _menuService.UpdateMenu(request);
                timer.Stop();
                _logger.LogInformation("Update menu id: {0}, menu name: {1},description: {2},status: {3},restaurand id: {4} succeed in {5} ms",request.MenuId, request.MenuName, request.Description, request.Status, request.RestaurantId, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update menu ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteMenu(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete menu ");
            try
            {
                var menu = await _menuService.DeleteMenu(id);
                timer.Stop();
                _logger.LogInformation("Delete menu {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete menu ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }
    }
}
