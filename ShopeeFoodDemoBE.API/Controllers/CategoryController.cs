using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System.Diagnostics;
using System.Text.Json;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private readonly ILogger<CategoryController> _logger;
        public CategoryController(ICategoryService categoryService, ILogger<CategoryController> logger)
        {
            _categoryService = categoryService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get all category");
            try
            {
                var category = await _categoryService.GetAllCategory();
                timer.Stop();
                if (category.Any())
                {
                    _logger.LogInformation("Get all category succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all category");
                    return Ok(category);
                }
                else
                { 
                    _logger.LogInformation("Get all category failed in {0} ms", timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get all category");
                    return BadRequest("Categories not found!"); 
                }
                
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start get category by id");
            try
            {
                var category = await _categoryService.GetCategoryById(id);
                timer.Stop();
                if (category != null)
                {
                    _logger.LogInformation("Get category by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get category by id");
                    return Ok(category);
                }
                else
                {
                    _logger.LogInformation("Get category by id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End get category by id");
                    return BadRequest("Category not found!");
                }                
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start add category");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var category = await _categoryService.AddCategory(request);
                timer.Stop();
                if (category.Success)
                {
                    _logger.LogInformation("Add category {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End add category");
                    return Ok();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _logger.LogInformation("Add category {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,category.Message);
                    _logger.LogInformation("End add category");
                    return BadRequest(category.Message);
                }
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start update category");
            try
            {
                string jsonString = JsonSerializer.Serialize(request);
                var category = await _categoryService.UpdateCategory(request);
                timer.Stop();
                
                if (category.Success)
                {
                    _logger.LogInformation("Update category {0} succeed in {1} ms", jsonString, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End update category");
                    return Ok();
                }
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                else
                {
                    _logger.LogInformation("Update category {0} failed in {1} ms with message {2}", jsonString, timer.Elapsed.TotalMilliseconds,category.Message);
                    _logger.LogInformation("End update category");
                    return BadRequest(category.Message);
                }        
            }
            catch (Exception e)
            {
                _logger.LogError("Error", e);
                throw new Exception();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();
            _logger.LogInformation("Start delete category");
            try
            {
                var category = await _categoryService.DeleteCategory(id);
                timer.Stop();
                if (category == true)
                {
                    _logger.LogInformation("Delete category id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete category");
                    return Ok();
                }
                else
                {
                    _logger.LogInformation("Delete category id {0} failed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                    _logger.LogInformation("End delete category");
                    return BadRequest("Delete category failed!");
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
