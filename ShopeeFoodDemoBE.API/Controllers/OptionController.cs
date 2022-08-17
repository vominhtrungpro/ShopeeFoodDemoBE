using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;
using System.Text.Json;

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
                if (option.Any())
                {
                    _logger.LogInformation("Get all option succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all option ");
                    return Ok(option);
                }
                else
                {
                    _logger.LogInformation("Get all option failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all option ");
                    return BadRequest("Options not found!");
                }
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
                if (option != null)
                {
                    _logger.LogInformation("Get option by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option by id ");
                    return Ok(option);
                }
                else
                {
                    _logger.LogInformation("Get option by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option by id ");
                    return BadRequest("Option not found!");
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var option = await _optionService.AddOption(request);
                timer.Stop();
                if (option.Success)
                {
                    _logger.LogInformation("Add option {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add option ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add option {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,option.Message);
                    _logger.LogInformation("End add option ");
                    return BadRequest(option.Message);
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var option = await _optionService.UpdateOption(request);
                timer.Stop();
                if (option.Success)
                {
                    _logger.LogInformation("Update option {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update option ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update option {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,option.Message);
                    _logger.LogInformation("End update option ");
                    return BadRequest(option.Message);
                }
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
                if (option.Success)
                {
                    _logger.LogInformation("Delete option {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("Start delete option ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete option {0} failed in {1} ms with message {2}", id, timer.Elapsed.TotalMilliseconds,option.Message);
                    _logger.LogInformation("Start delete option ");
                    return BadRequest(option.Message);
                }
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
                if (option != null)
                {
                    _logger.LogInformation("Get option by product id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option by product id ");
                    return Ok(option);
                }
                else
                {
                    _logger.LogInformation("Get option by product id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option by product id ");
                    return BadRequest("Option not found!");
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
