using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _restaurantService;
        private readonly ILogger<RestaurantController> _logger;
        public RestaurantController(IRestaurantService restaurantService, ILogger<RestaurantController> logger)
        {
            _restaurantService = restaurantService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurant()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all restaurant ");
            try
            {
                var restaurant = await _restaurantService.GetAllRestaurant();
                timer.Stop();
                _logger.LogInformation("Get all restaurant succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("Start get all restaurant ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by id ");
            try
            {
                var restaurant = await _restaurantService.GetRestaurantById(id);
                timer.Stop();
                _logger.LogInformation("Get restaurant by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by id ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("categoryid-{id}")]
        public async Task<IActionResult> GetRestaurantByCategoryId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by category id ");
            try
            {
                var restaurant = await _restaurantService.GetRestaurantByCategoryId(id);
                timer.Stop();
                _logger.LogInformation("Get restaurant by category id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by category id ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("cityid-{id}")]
        public async Task<IActionResult> GetRestaurantByCityId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by city id ");
            try
            {
                var restaurant = await _restaurantService.GetRestaurantByCityId(id);
                timer.Stop();
                _logger.LogInformation("Get restaurant by city id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by city id ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpPost("by-cityids-restypeids")]
        public async Task<IActionResult> GetResByCityIdsAndResTypeIds(RestaurantRequestListCityListRestaurantType request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by city id and restaurant type id ");
            try
            {
                var restaurant = await _restaurantService.GetResByCityIdsAndResTypeIds(request);
                timer.Stop();
                _logger.LogInformation("Get restaurant by city ids {0} and restaurant type ids {1} succeed in {2} ms", request.CityIds, request.RestaurantTypeIds, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by city id and restaurant type id ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpPost("paging-cityids-restypeids")]
        public async Task<IActionResult> GetResByCityIdsAndResTypeIdsWithPaging(RestaurantResponse respone)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by city ids and restype ids with paging ");
            try
            {
                var restaurant = await _restaurantService.GetResByCityIdsAndResTypeIdsWithPaging(respone);
                timer.Stop();
                _logger.LogInformation("Get restaurant by city ids {0} and restype ids {1} with paging succeed in {2} ms", respone.CityIds, respone.RestaurantTypeIds, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by city ids and restype ids with paging ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("restauranttypeid-{id}")]
        public async Task<IActionResult> GetRestaurantByRestaurantTypeId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by restaurant type id ");
            try
            {
                var restaurant = await _restaurantService.GetRestaurantByRestaurantTypeId(id);
                timer.Stop();
                _logger.LogInformation("Get restaurant by restaurant type id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by restaurant type id ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("more-categoryid-{cateId}-cityid-{cityId}")]
        public async Task<IActionResult> GetRestaurantByCategoryIdAndCityId(int cateId, int cityId)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by category id and city id ");
            try
            {
                var restaurant = await _restaurantService.GetRestaurantByCategoryIdAndCityId(cateId, cityId);
                timer.Stop();
                _logger.LogInformation("Get restaurant by category id {0} and city id {1} succeed in {2} ms", cateId, cityId, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get restaurant by category id and city id ");
                return Ok(restaurant);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(RestaurantRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add restaurant ");
            try
            {
                var restaurant = await _restaurantService.AddRestaurant(request);
                timer.Stop();
                _logger.LogInformation("Add restaurant name {0},city id: {1},restaurant type id: {2},restaurant address: {3},restaurant image: {4},description: {5},status: {6} succeed in {7} ms", request.RestaurantName, request.CityId, request.RestaurantTypeId, request.RestaurantAddress, request.RestaurantImage, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add restaurant ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaurant(RestaurantRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update restaurant ");
            try
            {
                var restaurant = await _restaurantService.UpdateRestaurant(request);
                timer.Stop();
                _logger.LogInformation("Update restaurant id: {0} restaurant name {1},city id: {2},restaurant type id: {3},restaurant address: {4},restaurant image: {5},description: {6},status: {7} succeed in {8} ms",request.RestaurantId, request.RestaurantName, request.CityId, request.RestaurantTypeId, request.RestaurantAddress, request.RestaurantImage, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update restaurant ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete restaurant ");
            try
            {
                var restaurant = await _restaurantService.DeleteRestaurant(id);
                timer.Stop();
                _logger.LogInformation("Delete restaurant {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete restaurant ");
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
