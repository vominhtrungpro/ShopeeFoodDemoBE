using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IOrderDetailRepository
    {
        Task<List<OrderDetail>> GetAllOrderDetail();

        Task<OrderDetail> GetOrderDetailById(int id);

        Task<Boolean> AddOrderDetail(OrderDetail orderdetail);

        Task<Boolean> UpdateOrderDetail(OrderDetail orderdetail);

        Task<Boolean> DeleteOrderDetail(int id);
    }
}
