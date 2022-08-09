using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _ioptionService;
        public OptionController(IOptionService ioptionService)
        {
            _ioptionService = ioptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOption()
        {
            var option = await _ioptionService.GetAllOption();
            return Ok(option);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(int id)
        {
            var option = await _ioptionService.GetOptionById(id);
            return Ok(option);
        }

        [HttpPost]
        public async Task<IActionResult> AddOption(OptionRequest request)
        {
            var option = await _ioptionService.AddOption(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOption(OptionRequest request)
        {
            var option = await _ioptionService.UpdateOption(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            var option = await _ioptionService.DeleteOption(id);
            return Ok();
        }
        [HttpGet("productid-{id}")]
        public async Task<IActionResult> GetOptionByProductId(int id)
        {
            var option = await _ioptionService.GetOptionByProductId(id);
            return Ok(option);
        }
    }
}
