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
    public interface IOrderService
    {
        Task<List<DtoOrder>> GetAllOrder();

        Task<DtoOrder> GetOrderById(int id);

        Task<Order> AddOrder(OrderRequest request);

        Task<ActionResponse> UpdateOrder(OrderRequest request);

        Task<ActionResponse> DeleteOrder(int id);
    }
}
