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
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderdetailRepository;
        public OrderDetailService(IOrderDetailRepository orderdetailRepository)
        {
            _orderdetailRepository = orderdetailRepository;
        }

        public Task<List<OrderDetail>> GetAllOrderDetail()
        {
            return _orderdetailRepository.GetAllOrderDetail();
        }

        public Task<OrderDetail> GetOrderDetailById(int id)
        {
            return _orderdetailRepository.GetOrderDetailById(id);
        }

        public Task<Boolean> AddOrderDetail(OrderDetailRequest request)
        {
            var orderdetail = new OrderDetail()
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                Price = request.Price
            };
            return _orderdetailRepository.AddOrderDetail(orderdetail);
        }



        public async Task<Boolean> UpdateOrderDetail(OrderDetailRequest request)
        {
            var orderdetail = await _orderdetailRepository.GetOrderDetailById(request.OrderDetailId);
            orderdetail.OrderId = request.OrderId;
            orderdetail.ProductId = request.ProductId;
            orderdetail.Amount = request.Amount;
            orderdetail.Price = request.Price;
            await _orderdetailRepository.UpdateOrderDetail(orderdetail);
            return true;
        }

        public Task<Boolean> DeleteOrderDetail(int id)
        {
            return _orderdetailRepository.DeleteOrderDetail(id);
        }
    }
}
