using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IRestaurantTypeService
    {
        Task<List<DtoRestaurantType>> GetAllRestaurantType();

        Task<DtoRestaurantType> GetRestaurantTypeById(int id);

        Task<List<DtoRestaurantType>> GetRestaurantTypeByCategoryId(int id);

        Task<ActionResponse> AddRestaurantType(RestaurantTypeRequest request);

        Task<ActionResponse> UpdateRestaurantType(RestaurantTypeRequest request);

        Task<ActionResponse> DeleteRestaurantType(int id);
    }
}
