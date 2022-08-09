using ShopeeFoodDemoBE.BLL.Models.Requests;
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
        Task<List<OrderDetail>> GetAllOrderDetail();

        Task<OrderDetail> GetOrderDetailById(int id);

        Task<Boolean> AddOrderDetail(OrderDetailRequest request);

        Task<Boolean> UpdateOrderDetail(OrderDetailRequest request);

        Task<Boolean> DeleteOrderDetail(int id);
    }
}
