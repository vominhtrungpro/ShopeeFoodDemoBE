using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IOrderDetailService
    {
        Task<List<DtoOrderDetail>> GetAllOrderDetail();

        Task<DtoOrderDetail> GetOrderDetailById(int id);

        Task<ActionResponse> AddOrderDetail(OrderDetailRequest request);

        Task<ActionResponse> UpdateOrderDetail(OrderDetailRequest request);

        Task<ActionResponse> DeleteOrderDetail(int id);
    }
}
