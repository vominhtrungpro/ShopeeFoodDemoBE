using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

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
                _logger.LogInformation("Get all restaurant type succeed in {0} s", timer.Elapsed.TotalSeconds);
                return Ok(restauranttype);
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
                _logger.LogInformation("Get restaurant type by id {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
                return Ok(restauranttype);
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
                _logger.LogInformation("Get restaurant type by category id {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
                return Ok(restauranttype);
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
                var restauranttype = await _restauranttypeService.AddRestaurantType(request);
                timer.Stop();
                _logger.LogInformation("Add restaurant type {0} succeed in {1} s", request.RestaurantTypeName, timer.Elapsed.TotalSeconds);
                return Ok();
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
                var restauranttype = await _restauranttypeService.UpdateRestaurantType(request);
                timer.Stop();
                _logger.LogInformation("Update restaurant type {0} succeed in {1} s", request.RestaurantTypeId, timer.Elapsed.TotalSeconds);
                return Ok();
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
                _logger.LogInformation("Delete restaurant type {0} succeed in {1} s", id, timer.Elapsed.TotalSeconds);
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
