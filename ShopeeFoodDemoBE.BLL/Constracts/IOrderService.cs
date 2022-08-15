using ShopeeFoodDemoBE.BLL.Models.Requests;
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
        Task<List<Order>> GetAllOrder();

        Task<Order> GetOrderById(int id);

        Task<Order> AddOrder(OrderRequest request);

        Task<Boolean> UpdateOrder(OrderRequest request);

        Task<Boolean> DeleteOrder(int id);
    }
}
