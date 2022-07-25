using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Task<List<Category>> GetAllCategory()
        {
            return _categoryRepository.GetAllCategory();
        }

        public Task<Category> GetCategoryById(int id)
        {
            return _categoryRepository.GetCategoryById(id);
        }

        public Task<Boolean> AddCategory(CreateCategoryRequest request)
        {
            var category = new Category()
            {
                CategoryName = request.CategoryName,
                Description = request.Description,
                Status = request.Status
            };
            return _categoryRepository.AddCategory(category);
        }

        public async Task<Boolean> UpdateCategory(UpdateCategoryRequest request)
        {
            var category = await _categoryRepository.GetCategoryById(request.CategoryId);
            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            category.Status = request.Status;

            await _categoryRepository.UpdateCategory(category);
            return true;
        }

        public Task<Boolean> DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }
    }
}
