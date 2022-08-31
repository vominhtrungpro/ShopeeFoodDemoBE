using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using System.Diagnostics;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : ControllerBase
    {
        private readonly ISearchService _searchService;
        private readonly ILogger<SearchController> _logger;
        public SearchController(ISearchService searchService, ILogger<SearchController> logger)
        {
            _searchService = searchService;
            _logger = logger;
        }

        [HttpPost("search")]
        public async Task<IActionResult> GetRestaurantByText(SearchRequest text)
        {
            var result = await _searchService.GetRestaurantByText(text.Text);
            return Ok(result);
        }

        [HttpPost("search-with-paging")]
        public async Task<IActionResult> GetRestaurantByTextWithPaging(SearchRequestWithPage text)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by text with paging ");
            try
            {
                var restaurant = await _searchService.GetRestaurantByTextWithPaging(text.Page,text.Text);
                timer.Stop();
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by text {0} with paging succeed in {1} ms", text.Text, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by text with paging ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by text {0} with paging failed in {1} ms", text.Text, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by text with paging ");
                    return BadRequest("Restaurant not found!");
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost("paging-text")]
        public async Task<IActionResult> GetResByTextWithPaging(SearchResponse respone)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get restaurant by city ids and restype ids with paging ");
            try
            {
                var restaurant = await _searchService.GetResByTextWithPaging(respone);
                timer.Stop();
                if (restaurant != null)
                {
                    _logger.LogInformation("Get restaurant by text {0} with paging succeed in {1} ms", respone.Text, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city ids and restype ids with paging ");
                    return Ok(restaurant);
                }
                else
                {
                    _logger.LogInformation("Get restaurant by text {0} with paging failed in {1} ms", respone.Text, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get restaurant by city ids and restype ids with paging ");
                    return BadRequest("Restaurant not found!");
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
