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
        private readonly ICategoryRepository _icategoryRepository;
        public CategoryService(ICategoryRepository icategoryRepository)
        {
            _icategoryRepository = icategoryRepository;
        }

        public Task<List<Category>> GetAllCategory()
        {
            return _icategoryRepository.GetAllCategory();
        }

        public Task<Category> GetCategoryById(int id)
        {
            return _icategoryRepository.GetCategoryById(id);
        }

        public Task<Boolean> AddCategory(CreateCategoryRequest request)
        {
            var category = new Category()
            {
                CategoryName = request.CategoryName,
                Description = request.Description,
                Status = request.Status
            };
            return _icategoryRepository.AddCategory(category);
        }

        public async Task<Boolean> UpdateCategory(UpdateCategoryRequest request)
        {
            var category = await _icategoryRepository.GetCategoryById(request.CategoryId);
            category.CategoryName = request.CategoryName;
            category.Description = request.Description;
            category.Status = request.Status;
            await _icategoryRepository.UpdateCategory(category);
            return true;
        }

        public Task<Boolean> DeleteCategory(int id)
        {
            return _icategoryRepository.DeleteCategory(id);
        }
    }
}
