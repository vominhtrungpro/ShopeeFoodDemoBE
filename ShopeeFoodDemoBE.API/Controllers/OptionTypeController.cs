using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionTypeController : ControllerBase
    {
        private readonly IOptionTypeService _ioptiontypeService;
        public OptionTypeController(IOptionTypeService ioptiontypeService)
        {
            _ioptiontypeService = ioptiontypeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptionType()
        {
            var optiontype = await _ioptiontypeService.GetAllOptionType();
            return Ok(optiontype);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionTypeById(int id)
        {
            var optiontype = await _ioptiontypeService.GetOptionTypeById(id);
            return Ok(optiontype);
        }

        [HttpPost]
        public async Task<IActionResult> AddOptionType(OptionTypeRequest request)
        {
            var optiontype = await _ioptiontypeService.AddOptionType(request);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOptionType(OptionTypeRequest request)
        {
            var optiontype = await _ioptiontypeService.UpdateOptionType(request);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionType(int id)
        {
            var optiontype = await _ioptiontypeService.DeleteOptionType(id);
            return Ok();
        }

        [HttpGet("productid-{id}")]
        public async Task<IActionResult> GetOptionTypeByProductId(int id)
        {
            var optiontype = await _ioptiontypeService.GetOptionTypeByProductId(id);
            return Ok(optiontype);
        }
        [HttpGet("detail-productid-{id}")]
        public async Task<IActionResult> GetOptionTypeDetailByProductId(int id)
        {
            var optiontype = await _ioptiontypeService.GetOptionTypeDetailByProductId(id);
            return Ok(optiontype);
        }
    }
}
