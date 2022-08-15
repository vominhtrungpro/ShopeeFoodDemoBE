using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System.Diagnostics;

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
                _logger.LogInformation("Get all category succeed in {0} ms", timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get all category");
                return Ok(category);  
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
                _logger.LogInformation("Get category by id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End get category by id");
                return Ok(category);
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
                var category = await _categoryService.AddCategory(request);
                timer.Stop();
                _logger.LogInformation("Add category name: {0},description: {1},status: {2} succeed in {3} ms", request.CategoryName, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End add category");
                return Ok();
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
                var category = await _categoryService.UpdateCategory(request);
                timer.Stop();
                _logger.LogInformation("Update category id: {0},name {1},description: {2},status: {3} succeed in {4} ms", request.CategoryId, request.CategoryName, request.Description, request.Status, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End update category");
                return Ok();
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
                _logger.LogInformation("Delete category id {0} succeed in {1} ms", id, timer.Elapsed.TotalMilliseconds);
                _logger.LogInformation("End delete category");
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
