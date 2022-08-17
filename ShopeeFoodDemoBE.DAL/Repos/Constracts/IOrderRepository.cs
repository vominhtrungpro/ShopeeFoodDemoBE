using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAllOrder();

        Task<Order> GetOrderById(int id);

        Task<Order> AddOrder(Order order);

        Task<Boolean> UpdateOrder(Order order);

        Task<Boolean> DeleteOrder(int id);
    }
}
