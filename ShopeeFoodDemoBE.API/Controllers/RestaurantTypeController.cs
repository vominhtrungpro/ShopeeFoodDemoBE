using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RestaurantTypeController : ControllerBase
    {
        private readonly IRestaurantTypeService _irestauranttypeService;
        public RestaurantTypeController(IRestaurantTypeService irestauranttypeService)
        {
            _irestauranttypeService = irestauranttypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRestaurantType()
        {
            var restauranttype = await _irestauranttypeService.GetAllRestaurantType();
            return Ok(restauranttype);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetRestaurantTypeById(int id)
        {
            var restauranttype = await _irestauranttypeService.GetRestaurantTypeById(id);
            return Ok(restauranttype);
        }

        [HttpGet("categoryid-{id}")]
        public async Task<IActionResult> GetRestaurantTypeByCategoryId(int id)
        {
            var restauranttype = await _irestauranttypeService.GetRestaurantTypeByCategoryId(id);
            return Ok(restauranttype);
        }

        [HttpPost]
        public async Task<IActionResult> AddRestaurantType(RestaurantTypeRequest request)
        {
            var restauranttype = await _irestauranttypeService.AddRestaurantType(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRestaurantType(RestaurantTypeRequest request)
        {
            var restauranttype = await _irestauranttypeService.UpdateRestaurantType(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRestaurantType(int id)
        {
            var restauranttype = await _irestauranttypeService.DeleteRestaurantType(id);
            return Ok();
        }
    }
}
