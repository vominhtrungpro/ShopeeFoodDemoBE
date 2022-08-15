using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemOptionController : ControllerBase
    {
        private readonly IItemOptionService _itemoptionService;
        private readonly ILogger<ItemOptionController> _logger;
        public ItemOptionController(IItemOptionService itemoptionService, ILogger<ItemOptionController> logger)
        {
            _itemoptionService = itemoptionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllItemOption()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all item option");
            try
            {
                var itemoption = await _itemoptionService.GetAllItemOption();
                timer.Stop();
                _logger.LogInformation("Get all item option succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all item option");
                return Ok(itemoption);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }   
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetItemOptionById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get item option by id");
            try
            {
                var itemoption = await _itemoptionService.GetItemOptionById(id);
                timer.Stop();
                _logger.LogInformation("Get item option by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get item option by id");
                return Ok(itemoption);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddItemOption(ItemOptionRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add item option");
            try
            {
                var itemoption = await _itemoptionService.AddItemOption(request);
                timer.Stop();
                _logger.LogInformation("Add item option with product id: {0},option id: {1}  succeed in {2} ms", request.ProductId, request.OptionId, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add item option");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }  
        }

        [HttpPut]
        public async Task<IActionResult> UpdateItemOption(ItemOptionRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update item option");
            try
            {
                var itemoption = await _itemoptionService.UpdateItemOption(request);
                timer.Stop();
                _logger.LogInformation("Update item option id {0},product id: {1},option id: {2} succeed in {3} s", request.ItemOptionId, request.ProductId, request.OptionId, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update item option");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteItemOption(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete item option");
            try
            {
                var itemoption = await _itemoptionService.DeleteItemOption(id);
                timer.Stop();
                _logger.LogInformation("Delete item option succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete item option");
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
