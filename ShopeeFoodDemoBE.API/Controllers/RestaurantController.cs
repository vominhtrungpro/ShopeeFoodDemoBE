using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using System.Diagnostics;
using System.Text.Json;

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
                if (restaurant.Any())
                {
                    _logger.LogInformation("Get all restaurant succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("Start get all restaurant ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get all restaurant failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("Start get all restaurant ");
                    return BadRequest("Restaurants not found!");
                }
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
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by id ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by id ");
                    return BadRequest("Restaurant not found!");
                }
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
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by category id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by category id ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by category id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by category id ");
                    return BadRequest("Restaurant not found!");
                }
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
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by city id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city id ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by city id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city id ");
                    return BadRequest("Restaurant not found!");
                }
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
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by city ids {0} and restaurant type ids {1} succeed in {2} ms", request.CityIds, request.RestaurantTypeIds, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city id and restaurant type id ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by city ids {0} and restaurant type ids {1} failed in {2} ms", request.CityIds, request.RestaurantTypeIds, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city id and restaurant type id ");
                    return BadRequest("Restaurant not found!");
                }
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
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by city ids {0} and restype ids {1} with paging succeed in {2} ms", respone.CityIds, respone.RestaurantTypeIds, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city ids and restype ids with paging ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by city ids {0} and restype ids {1} with paging failed in {2} ms", respone.CityIds, respone.RestaurantTypeIds, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city ids and restype ids with paging ");
                    return BadRequest("Restaurant not found!");
                }
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
                if (restaurant!=null)
                {
                    _logger.LogInformation("Get restaurant by restaurant type id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by restaurant type id ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by restaurant type id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by restaurant type id ");
                    return BadRequest("Restaurant not found!");
                }
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
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by category id {0} and city id {1} succeed in {2} ms", cateId, cityId, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by category id and city id ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by category id {0} and city id {1} failed in {2} ms", cateId, cityId, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by category id and city id ");
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
        public async Task<IActionResult> AddRestaurant(RestaurantRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add restaurant ");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var restaurant = await _restaurantService.AddRestaurant(request);
                timer.Stop();
                if (restaurant.Success)
                {
                    _logger.LogInformation("Add restaurant {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add restaurant ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add restaurant {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,restaurant.Message);
                    _logger.LogInformation("End add restaurant ");
                    return BadRequest(restaurant.Message);
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var restaurant = await _restaurantService.UpdateRestaurant(request);
                timer.Stop();
                if (restaurant.Success)
                {
                    _logger.LogInformation("Update restaurant {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update restaurant ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update restaurant {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds, restaurant.Message);
                    _logger.LogInformation("End update restaurant ");
                    return BadRequest(restaurant.Message);
                }
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
                if (restaurant.Success)
                {
                    _logger.LogInformation("Delete restaurant {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete restaurant ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete restaurant {0} failed in {1} ms with message {2}", id, timer.Elapsed.TotalMilliseconds,restaurant.Message);
                    _logger.LogInformation("End delete restaurant ");
                    return BadRequest(restaurant.Message);
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
