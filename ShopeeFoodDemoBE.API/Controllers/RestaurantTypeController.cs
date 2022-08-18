using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;
using System.Text.Json;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTypeController : ControllerBase
    {
        private readonly IRestaurantTypeService _restauranttypeService;
        private readonly ILogger<RestaurantTypeController> _logger;
        public RestaurantTypeController(IRestaurantTypeService restauranttypeService, ILogger<RestaurantTypeController> logger)
        {
            _restauranttypeService = restauranttypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurantType()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all restaurant type ");
            try
            {
                var restauranttype = await _restauranttypeService.GetAllRestaurantType();
                timer.Stop();
                if (restauranttype.Any())
                {
                    _logger.LogInformation("Get all restaurant type succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all restaurant type ");
                    return Ok(restauranttype);
                }
                else
                {
                    _logger.LogInformation("Get all restaurant type failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all restaurant type ");
                    return BadRequest("Restauranttypes not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantTypeById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant type by id ");
            try
            {
                var restauranttype = await _restauranttypeService.GetRestaurantTypeById(id);
                timer.Stop();
                if (restauranttype != null)
                {
                    _logger.LogInformation("Get restaurant type by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant type by id ");
                    return Ok(restauranttype);
                }
                else
                {
                    _logger.LogInformation("Get restaurant type by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant type by id ");
                    return BadRequest("Restauranttype not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("categoryid-{id}")]
        public async Task<IActionResult> GetRestaurantTypeByCategoryId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant type by category id ");
            try
            {
                var restauranttype = await _restauranttypeService.GetRestaurantTypeByCategoryId(id);
                timer.Stop();
                if (restauranttype != null)
                {
                    _logger.LogInformation("Get restaurant type by category id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant type by category id ");
                    return Ok(restauranttype);
                }
                else
                {
                    _logger.LogInformation("Get restaurant type by category id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant type by category id ");
                    return BadRequest("Restaurant not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurantType(RestaurantTypeRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add restaurant type ");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var restauranttype = await _restauranttypeService.AddRestaurantType(request);
                timer.Stop();
                if (restauranttype.Success)
                {
                    _logger.LogInformation("Add restauranttype {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add restaurant type ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add restauranttype {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,restauranttype.Message);
                    _logger.LogInformation("End add restaurant type ");
                    return BadRequest(restauranttype.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaurantType(RestaurantTypeRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update restaurant type ");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var restauranttype = await _restauranttypeService.UpdateRestaurantType(request);
                timer.Stop();
                if (restauranttype.Success)
                {
                    _logger.LogInformation("update restauranttype {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update restaurant type ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("update restauranttype {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds, restauranttype.Message);
                    _logger.LogInformation("End update restaurant type ");
                    return BadRequest(restauranttype.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantType(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete restaurant type ");
            try
            {
                var restauranttype = await _restauranttypeService.DeleteRestaurantType(id);
                timer.Stop();
                if (restauranttype.Success)
                {
                    _logger.LogInformation("Delete restaurant type {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete restaurant type ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete restaurant type {0} failed in {1} ms with message {2}", id, timer.Elapsed.TotalMilliseconds, restauranttype.Message);
                    _logger.LogInformation("End delete restaurant type ");
                    return BadRequest(restauranttype.Message);
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
