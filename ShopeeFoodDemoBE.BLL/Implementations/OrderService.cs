using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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

        public async Task<List<DtoOrder>> GetAllOrder()
        {
            var dtoOrder = new List<DtoOrder>();
            var dbOrder = await _orderRepository.GetAllOrder();
            dtoOrder = dbOrder.Select(c => new DtoOrder
            {
                OrderId = c.OrderId,
                CustomerId = c.CustomerId,
                TotalPrice = c.TotalPrice,
                TimeOrder = c.TimeOrder,
                PlaceOrder = c.PlaceOrder,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoOrder;
        }

        public async Task<DtoOrder> GetOrderById(int id)
        {
            var dtoOrder = new DtoOrder();
            var dbOrder = await _orderRepository.GetOrderById(id);
            if (dbOrder == null)
            {
                return await Task.FromResult<DtoOrder>(null);
            }
            else
            {
                dtoOrder.OrderId = dbOrder.OrderId;
                dtoOrder.CustomerId = dbOrder.CustomerId;
                dtoOrder.TotalPrice = dbOrder.TotalPrice;
                dtoOrder.TimeOrder = dbOrder.TimeOrder;
                dtoOrder.PlaceOrder = dbOrder.PlaceOrder;
                dtoOrder.Description = dbOrder.Description;
                dtoOrder.Status = dbOrder.Status;
                return dtoOrder;
            }
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

        public async Task<ActionResponse> UpdateOrder(OrderRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbOrder = await _orderRepository.GetOrderById(request.OrderId);
            if (dbOrder == null)
            {
                result.Success = false;
                result.Message = "Order not found!";
                return result;
            }
            dbOrder.CustomerId = request.CustomerId;
            dbOrder.TotalPrice = request.TotalPrice;
            dbOrder.TimeOrder = request.TimeOrder;
            dbOrder.PlaceOrder = request.PlaceOrder;
            dbOrder.Description = request.Description;
            dbOrder.Status = request.Status;
            var updateResult = await _orderRepository.UpdateOrder(dbOrder);
            if (updateResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Update failed!";
            }
            return result;
        }

        public async Task<ActionResponse> DeleteOrder(int id)
        {
            var result = new ActionResponse();
            var dbMenu = await _orderRepository.GetOrderById(id);
            if (dbMenu == null)
            {
                result.Success = false;
                result.Message = "Order not found!";
                return result;
            }
            var deleteResult = await _orderRepository.DeleteOrder(id);
            if (deleteResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Delete failed";
            }
            return result;
        }
    }
}
