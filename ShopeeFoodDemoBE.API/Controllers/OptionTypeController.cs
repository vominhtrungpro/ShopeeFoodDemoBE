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
    public class OptionTypeController : ControllerBase
    {
        private readonly IOptionTypeService _optiontypeService;
        private readonly ILogger<OptionTypeController> _logger;
        public OptionTypeController(IOptionTypeService optiontypeService, ILogger<OptionTypeController> logger)
        {
            _optiontypeService = optiontypeService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOptionType()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all option type ");
            try
            {
                var optiontype = await _optiontypeService.GetAllOptionType();
                timer.Stop();
                if (optiontype.Any())
                {
                    _logger.LogInformation("Get all option type succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all option type ");
                    return Ok(optiontype);
                }
                else
                {
                    _logger.LogInformation("Get all option type failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all option type ");
                    return BadRequest("Optiontypes not found");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            } 
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOptionTypeById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get option type by id ");
            try
            {
                var optiontype = await _optiontypeService.GetOptionTypeById(id);
                timer.Stop();
                if (optiontype != null)
                {
                    _logger.LogInformation("Get option type by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option type by id ");
                    return Ok(optiontype);
                }
                else
                {
                    _logger.LogInformation("Get option type by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option type by id ");
                    return BadRequest("Optiontype not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddOptionType(OptionTypeRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add option type ");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var optiontype = await _optiontypeService.AddOptionType(request);
                timer.Stop();
                if (optiontype.Success)
                {
                    _logger.LogInformation("Add optiontype {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add option type ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add optiontype {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,optiontype.Message);
                    _logger.LogInformation("End add option type ");
                    return BadRequest(optiontype.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }    
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOptionType(OptionTypeRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update option type ");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var optiontype = await _optiontypeService.UpdateOptionType(request);
                timer.Stop();
                if (optiontype.Success)
                {
                    _logger.LogInformation("Update optiontype {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update option type ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update optiontype {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,optiontype.Message);
                    _logger.LogInformation("End update option type ");
                    return BadRequest(optiontype.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOptionType(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete option type ");
            try
            {
                var optiontype = await _optiontypeService.DeleteOptionType(id);
                timer.Stop();
                if (optiontype.Success)
                {
                    _logger.LogInformation("Delete option type {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete option type ");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete option type {0} failed in {1} ms with message {2}", id, timer.Elapsed.TotalMilliseconds,optiontype.Message);
                    _logger.LogInformation("End delete option type ");
                    return BadRequest(optiontype.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("productid-{id}")]
        public async Task<IActionResult> GetOptionTypeByProductId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get option type by product id ");
            try
            {
                var optiontype = await _optiontypeService.GetOptionTypeByProductId(id);
                timer.Stop();
                if (optiontype != null)
                {
                    _logger.LogInformation("Get option type by product id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option type by product id ");
                    return Ok(optiontype);
                }
                else
                {
                    _logger.LogInformation("Get option type by product id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option type by product id ");
                    return BadRequest("Optiontype not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }
        [HttpGet("detail-productid-{id}")]
        public async Task<IActionResult> GetOptionTypeDetailByProductId(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get option type detail by product id ");
            try
            {
                var optiontype = await _optiontypeService.GetOptionTypeDetailByProductId(id);
                timer.Stop();
                if (optiontype != null)
                {
                    _logger.LogInformation("Get option type detail by product id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option type detail by product id ");
                    return Ok(optiontype);
                }
                else
                {
                    _logger.LogInformation("Get option type detail by product id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get option type detail by product id ");
                    return BadRequest("Optiontype not found!");
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
