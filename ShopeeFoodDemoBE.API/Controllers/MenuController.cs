using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;
using System.Text.Json;

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
                if (menu.Any())
                {
                    _logger.LogInformation("Get all menu succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all menu ");
                    return Ok(menu);
                }
                else
                {
                    _logger.LogInformation("Get all menu failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all menu ");
                    return BadRequest("Menus not found!");
                } 
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
                if (menu != null)
                {
                    _logger.LogInformation("Get menu by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get menu by id ");
                    return Ok(menu);
                }
                else
                {
                    _logger.LogInformation("Get menu by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get menu by id ");
                    return BadRequest("Menu not found!");
                }  
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
                if (menu != null)
                {
                    _logger.LogInformation("Get menu by restaurant id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get menu by restaurant id ");
                    return Ok(menu);
                }
                else
                {
                    _logger.LogInformation("Get menu by restaurant id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get menu by restaurant id ");
                    return BadRequest("Menu not found!");
                } 
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
                string jsonString = JsonSerializer.Serialize(request);
                var menu = await _menuService.AddMenu(request);
                timer.Stop();
                if (menu == true)
                {
                    _logger.LogInformation("Add menu {0} succeed in {4} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add menu ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add menu {0} failed in {4} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add menu ");
                    return BadRequest("Add menu failed!");
                } 
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
                string jsonString = JsonSerializer.Serialize(request);
                var menu = await _menuService.UpdateMenu(request);
                timer.Stop();
                if (menu == true)
                {
                    _logger.LogInformation("Update menu {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update menu ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update menu {0} failed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update menu ");
                    return BadRequest("Update menu failed!");
                } 
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
                if (menu == true)
                {
                    _logger.LogInformation("Delete menu {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete menu ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete menu {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete menu ");
                    return BadRequest("Delete menu failed!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }
    }
}
