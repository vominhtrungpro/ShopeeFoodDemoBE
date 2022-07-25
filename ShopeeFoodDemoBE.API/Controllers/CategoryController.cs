using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;

namespace ShopeeFoodDemoBE.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _icategoryService;
        private readonly DataContext _dataContext;
        public CategoryController(ICategoryService icategoryService,DataContext dataContext)
        {
            _icategoryService = icategoryService;
            _dataContext = dataContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllCategory()
        {
            var category = await _icategoryService.GetAllCategory();
            return Ok(category);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var category = await _icategoryService.GetCategoryById(id);
            return Ok(category);
        }

        [HttpPost]
        public async Task<IActionResult> AddCategory(CreateCategoryRequest request)
        {
            var category = await _icategoryService.AddCategory(request);
            return Ok(category);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryRequest request)
        {
            //var category = await _dataContext.Category.FindAsync(request.CategoryId);
            //if (category == null)
            //    return BadRequest("Category not found");
            //category.CategoryName = request.CategoryName;
            //category.Description = request.Description;
            //category.Status = request.Status;

            //await _dataContext.SaveChangesAsync();

            //return Ok(await _dataContext.Category.ToListAsync());

            var category = await _icategoryService.UpdateCategory(request);
            return Ok(category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var category = await _icategoryService.DeleteCategory(id);
            return Ok(category);

        }


    }
}
