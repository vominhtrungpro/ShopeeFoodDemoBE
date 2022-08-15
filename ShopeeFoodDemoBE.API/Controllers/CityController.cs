using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly ICityService _cityService;
        private readonly ILogger<CityController> _logger;
        public CityController(ICityService cityService, ILogger<CityController> logger)
        {
            _cityService = cityService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCity()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all city");
            try
            {
                var city = await _cityService.GetAllCity();
                timer.Stop();
                _logger.LogInformation("Get all city succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all city");
                return Ok(city);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCityById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get city by id");
            try
            {
                var city = await _cityService.GetCityById(id);
                timer.Stop();
                _logger.LogInformation("Get city by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get city by id");
                return Ok(city);
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCity(CityRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add city");
            try
            {
                var city = await _cityService.AddCity(request);
                timer.Stop();
                _logger.LogInformation("Add city name: {0},description: {1},status: {2} succeed in {3} ms", request.CityName, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add city");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(CityRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update city");
            try
            {
                var city = await _cityService.UpdateCity(request);
                timer.Stop();
                _logger.LogInformation("Update city id: {0},city name: {1},description: {2},status: {3} succeed in {4} ms", request.CityId, request.CityName, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update city");
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCity(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete city");
            try
            {
                var city = await _cityService.DeleteCity(id);
                timer.Stop();
                _logger.LogInformation("Delete city id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete city");
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
