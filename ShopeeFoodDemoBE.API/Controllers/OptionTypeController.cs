using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

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
                _logger.LogInformation("Get all option type succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all option type ");
                return Ok(optiontype);
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
                _logger.LogInformation("Get option type by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get option type by id ");
                return Ok(optiontype);
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
                var optiontype = await _optiontypeService.AddOptionType(request);
                timer.Stop();
                _logger.LogInformation("Add option type name: {0},description: {1},status: {2} succeed in {3} ms", request.OptionTypeName, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add option type ");
                return Ok();
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
                var optiontype = await _optiontypeService.UpdateOptionType(request);
                timer.Stop();
                _logger.LogInformation("Update option type id: {0}, option type name: {1},description: {2},status: {3} succeed in {4} ms",request.OptionTypeId, request.OptionTypeName, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update option type ");
                return Ok();
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
                _logger.LogInformation("Delete option type {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete option type ");
                return Ok();
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
                _logger.LogInformation("Get option type by product id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get option type by product id ");
                return Ok(optiontype);
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
                _logger.LogInformation("Get option type detail by product id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get option type detail by product id ");
                return Ok(optiontype);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }
    }
}
