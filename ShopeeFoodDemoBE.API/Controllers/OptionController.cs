using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OptionController : ControllerBase
    {
        private readonly IOptionService _optionService;
        private readonly ILogger<OptionController> _logger;
        public OptionController(IOptionService optionService, ILogger<OptionController> logger)
        {
            _optionService = optionService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOption()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all option ");
            try
            {
                var option = await _optionService.GetAllOption();
                timer.Stop();
                _logger.LogInformation("Get all option succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all option ");
                return Ok(option);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get option by id ");
            try
            {
                var option = await _optionService.GetOptionById(id);
                timer.Stop();
                _logger.LogInformation("Get option by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get option by id ");
                return Ok(option);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOption(OptionRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add option ");
            try
            {
                var option = await _optionService.AddOption(request);
                timer.Stop();
                _logger.LogInformation("Add option name: {0},option type id: {1},description: {2},status: {3} succeed in {4} ms", request.OptionName, request.OptionTypeId, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add option ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOption(OptionRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update option ");
            try
            {
                var option = await _optionService.UpdateOption(request);
                timer.Stop();
                _logger.LogInformation("Update option id: {0},option name: {1},option type id: {2},description: {3},status: {4} succeed in {5} ms",request.OptionId, request.OptionName, request.OptionTypeId, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update option ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOption(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete option ");
            try
            {
                var option = await _optionService.DeleteOption(id);
                timer.Stop();
                _logger.LogInformation("Delete option {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("Start delete option ");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }
        [HttpGet("productid-{id}")]
        public async Task<IActionResult> GetOptionByProductId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get option by product id ");
            try
            {
                var option = await _optionService.GetOptionByProductId(id);
                timer.Stop();
                _logger.LogInformation("Get option by product id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get option by product id ");
                return Ok(option);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }
    }
}
