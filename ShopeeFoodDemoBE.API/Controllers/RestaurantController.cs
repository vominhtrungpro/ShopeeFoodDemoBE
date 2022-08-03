using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantController : ControllerBase
    {
        private readonly IRestaurantService _irestaurantService;
        public RestaurantController(IRestaurantService irestaurantService)
        {
            _irestaurantService = irestaurantService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurant()
        {
            var restaurant = await _irestaurantService.GetAllRestaurant();
            return Ok(restaurant);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantById(int id)
        {
            var restaurant = await _irestaurantService.GetRestaurantById(id);
            return Ok(restaurant);
        }

        [HttpGet("categoryid-{id}")]
        public async Task<IActionResult> GetRestaurantByCategoryId(int id)
        {
            var restaurant = await _irestaurantService.GetRestaurantByCategoryId(id);
            return Ok(restaurant);
        }

        [HttpGet("cityid-{id}")]
        public async Task<IActionResult> GetRestaurantByCityId(int id)
        {
            var restaurant = await _irestaurantService.GetRestaurantByCityId(id);
            return Ok(restaurant);
        }


        [HttpPost("listcityidrestauranttypeid")]
        public async Task<IActionResult> GetRestaurantByListCityId(RestaurantRequestListCityListRestaurantType request)
        {
            var restaurant = await _irestaurantService.GetRestaurantByListCityIdAndListRestaurantTypeId(request);
            return Ok(restaurant);
        }

        [HttpGet("restauranttypeid-{id}")]
        public async Task<IActionResult> GetRestaurantByRestaurantTypeId(int id)
        {
            var restaurant = await _irestaurantService.GetRestaurantByRestaurantTypeId(id);
            return Ok(restaurant);
        }

        [HttpGet("more-categoryid-{id1}-cityid-{id2}")]
        public async Task<IActionResult> GetRestaurantByCategoryIdAndCityId(int id1, int id2)
        {
            var restaurant = await _irestaurantService.GetRestaurantByCategoryIdAndCityId(id1, id2);
            return Ok(restaurant);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurant(RestaurantRequest request)
        {
            var restaurant = await _irestaurantService.AddRestaurant(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaurant(RestaurantRequest request)
        {
            var restaurant = await _irestaurantService.UpdateRestaurant(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurant(int id)
        {
            var restaurant = await _irestaurantService.DeleteRestaurant(id);
            return Ok();
        }
    }
}
