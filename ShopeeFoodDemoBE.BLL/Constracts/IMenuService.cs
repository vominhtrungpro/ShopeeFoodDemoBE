using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IMenuService
    {
        Task<List<DtoMenu>> GetAllMenu();

        Task<DtoMenu> GetMenuById(int id);

        Task<List<DtoMenu>> GetMenuByRestaurantId(int id);

        Task<ActionResponse> AddMenu(MenuRequest request);

        Task<ActionResponse> UpdateMenu(MenuRequest request);

        Task<ActionResponse> DeleteMenu(int id);
    }
}
