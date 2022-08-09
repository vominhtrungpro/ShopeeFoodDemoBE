using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> GetAllOrder()
        {
            return _orderRepository.GetAllOrder();
        }

        public Task<Order> GetOrderById(int id)
        {
            return _orderRepository.GetOrderById(id);
        }

        public Task<Order> AddOrder(OrderRequest request)
        {
            var order = new Order()
            {
                CustomerId = request.CustomerId,
                TotalPrice = request.TotalPrice,
                TimeOrder = request.TimeOrder,
                PlaceOrder = request.PlaceOrder,
                Description = request.Description,
                Status = request.Status
            };
            return _orderRepository.AddOrder(order);
        }

        public async Task<Boolean> UpdateOrder(OrderRequest request)
        {
            var order = await _orderRepository.GetOrderById(request.OrderId);
            order.CustomerId = request.CustomerId;
            order.TotalPrice = request.TotalPrice;
            order.TimeOrder = request.TimeOrder;
            order.PlaceOrder = request.PlaceOrder;
            order.Description = request.Description;
            order.Status = request.Status;
            await _orderRepository.UpdateOrder(order);
            return true;
        }

        public Task<Boolean> DeleteOrder(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }
    }
}
