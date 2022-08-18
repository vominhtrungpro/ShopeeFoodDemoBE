using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<List<DtoCategory>> GetAllCategory()
        {
            var dtoCategory = new List<DtoCategory>();
            var dbCategory = await _categoryRepository.GetAllCategory();
            dtoCategory = dbCategory.Select(c => new DtoCategory
            {
                CategoryId = c.CategoryId,
                CategoryName = c.CategoryName,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoCategory;
        }

        public async Task<DtoCategory> GetCategoryById(int id)
        {
            var dtoCategory = new DtoCategory();
            var dbCategory = await _categoryRepository.GetCategoryById(id);
            if (dbCategory == null)
            {
                return await Task.FromResult<DtoCategory>(null);
            }
            else
            {
                dtoCategory.CategoryId = dbCategory.CategoryId;
                dtoCategory.CategoryName = dbCategory.CategoryName;
                dtoCategory.Description = dbCategory.Description;
                dtoCategory.Status = dbCategory.Status;
                return dtoCategory;
            }
            
        }

        public async Task<ActionResponse> AddCategory(CreateCategoryRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var category = new Category()
            {
                CategoryName = request.CategoryName,
                Description = request.Description,
                Status = request.Status
            };
            var addResult = await _categoryRepository.AddCategory(category);
            if (addResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Add failed!";
            }
            return result;
        }

        public async Task<ActionResponse> UpdateCategory(UpdateCategoryRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbCategory = await _categoryRepository.GetCategoryById(request.CategoryId);
            if (dbCategory == null)
            {
                result.Success = false;
                result.Message = "Category not found!";
                return result;
            }
            dbCategory.CategoryName = request.CategoryName;
            dbCategory.Description = request.Description;
            dbCategory.Status = request.Status;
            var updateResult = await _categoryRepository.UpdateCategory(dbCategory);
            if (updateResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Update failed!";
            }
            return result;
        }

        public async Task<ActionResponse> DeleteCategory(int id)
        {
            var result = new ActionResponse();
            var dbCategory = await _categoryRepository.GetCategoryById(id);
            if (dbCategory == null)
            {
                result.Success = false;
                result.Message = "Category not found!";
                return result;
            }
            var deleteResult = await  _categoryRepository.DeleteCategory(id);
            if (deleteResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Delete failed";
                
            }
            return result;
        }
    }
}
