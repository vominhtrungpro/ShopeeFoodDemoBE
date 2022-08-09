using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _icityService;
        public CityController(ICityService icityService)
        {
            _icityService = icityService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            var city = await _icityService.GetAllCity();
            return Ok(city);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            var city = await _icityService.GetCityById(id);
            return Ok(city);
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityRequest request)
        {
            var city = await _icityService.AddCity(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityRequest request)
        {
            var city = await _icityService.UpdateCity(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            var city = await _icityService.DeleteCity(id);
            return Ok();
        }
    }
}
