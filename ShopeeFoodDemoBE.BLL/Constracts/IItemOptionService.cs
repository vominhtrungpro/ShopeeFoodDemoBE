using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IItemOptionService
    {
        Task<List<DtoItemOption>> GetAllItemOption();

        Task<DtoItemOption> GetItemOptionById(int id);

        Task<ActionResponse> AddItemOption(ItemOptionRequest request);

        Task<ActionResponse> UpdateItemOption(ItemOptionRequest request);

        Task<ActionResponse> DeleteItemOption(int id);
    }
}
