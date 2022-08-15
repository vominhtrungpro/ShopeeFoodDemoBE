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
                _logger.LogInformation("Get all restaurant type succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all restaurant type ");
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
                _logger.LogInformation("Get restaurant type by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant type by id ");
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
                _logger.LogInformation("Get restaurant type by category id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant type by category id ");
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
                _logger.LogInformation("Add restaurant type name: {0},category id: {1},description: {2},status: {3} succeed in {4} ms", request.RestaurantTypeName,request.CategoryId,request.Description,request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add restaurant type ");
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
                _logger.LogInformation("update restaurant type id: {0}, restaurant name: {1},category id: {2},description: {3},status: {4} succeed in {5} ms",request.RestaurantTypeId, request.RestaurantTypeName, request.CategoryId, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update restaurant type ");
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
                _logger.LogInformation("Delete restaurant type {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete restaurant type ");
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
