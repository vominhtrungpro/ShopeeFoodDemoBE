using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IOptionService
    {
        Task<List<DtoOption>> GetAllOption();

        Task<DtoOption> GetOptionById(int id);

        Task<ActionResponse> AddOption(OptionRequest request);

        Task<ActionResponse> UpdateOption(OptionRequest request);

        Task<ActionResponse> DeleteOption(int id);

        Task<List<DtoOption>> GetOptionByProductId(int id);
    }
}
