using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
