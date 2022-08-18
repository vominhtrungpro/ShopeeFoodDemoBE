using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface ICategoryService
    {
        Task<List<DtoCategory>> GetAllCategory();

        Task<DtoCategory> GetCategoryById(int id);

        Task<ActionResponse> AddCategory(CreateCategoryRequest request);

        Task<ActionResponse> UpdateCategory(UpdateCategoryRequest request);

        Task<ActionResponse> DeleteCategory(int id);
    }
}
