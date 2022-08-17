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
                if (city.Any())
                {
                    _logger.LogInformation("Get all city succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all city");
                    return Ok(city);
                }
                else
                {
                    _logger.LogInformation("Get all city failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all city");
                    return BadRequest("Cities not found!");
                }
                
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
                if (city != null)
                {
                    _logger.LogInformation("Get city by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get city by id");
                    return Ok(city);
                }
                else
                {
                    _logger.LogInformation("Get city by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get city by id");
                    return BadRequest("City not found!");
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var city = await _cityService.AddCity(request);
                timer.Stop();
                if (city.Success)
                {
                    _logger.LogInformation("Add city {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add city");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Add city {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds, city.Message);
                    _logger.LogInformation("End add city");
                    return BadRequest(city.Message);
                }
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
                string jsonString = JsonSerializer.Serialize(request);
                var city = await _cityService.UpdateCity(request);
                timer.Stop();
                if (city.Success)
                {
                    _logger.LogInformation("Update city {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update city");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Update city {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,city.Message);
                    _logger.LogInformation("End update city");
                    return BadRequest(city.Message);
                }  
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
                if (city.Success)
                {
                    _logger.LogInformation("Delete city id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete city");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete city id {0} failed in {1} ms with message {2}", id, timer.Elapsed.TotalMilliseconds,city.Message);
                    _logger.LogInformation("End delete city");
                    return BadRequest(city.Message);
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
