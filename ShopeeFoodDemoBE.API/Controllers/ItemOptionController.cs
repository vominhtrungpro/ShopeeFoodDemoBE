using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOptionController : ControllerBase
    {
        private readonly IItemOptionService _iitemoptionService;
        public ItemOptionController(IItemOptionService iitemoptionService)
        {
            _iitemoptionService = iitemoptionService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemOption()
        {
            var itemoption = await _iitemoptionService.GetAllItemOption();
            return Ok(itemoption);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemOptionById(int id)
        {
            var itemoption = await _iitemoptionService.GetItemOptionById(id);
            return Ok(itemoption);
        }

        [HttpPost]
        public async Task<IActionResult> AddItemOption(ItemOptionRequest request)
        {
            var itemoption = await _iitemoptionService.AddItemOption(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemOption(ItemOptionRequest request)
        {
            var itemoption = await _iitemoptionService.UpdateItemOption(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemOption(int id)
        {
            var itemoption = await _iitemoptionService.DeleteItemOption(id);
            return Ok();
        }
    }
}
