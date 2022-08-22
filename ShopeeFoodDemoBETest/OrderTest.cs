using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using Newtonsoft.Json;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using ShopeeFoodDemoBE.DAL.Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBETest 
{
    public class OrderTest 
    {
        public Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();

        List<Order> order = new List<Order>
            {
                new Order {
                    OrderId = 1,
                    CustomerId = 1,
                    TotalPrice = 200000,
                    TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                    PlaceOrder = "Tien Giang",
                    Description = "200000",
                    Status = "Active"
                },
                new Order {
                    OrderId = 2,
                    CustomerId = 1,
                    TotalPrice = 300000,
                    TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                    PlaceOrder = "Tien Giang",
                    Description = "300000",
                    Status = "Active"
                },
                new Order {
                    OrderId = 4,
                    CustomerId = 1,
                    TotalPrice = 600000,
                    TimeOrder = Convert.ToDateTime("2022-08-09T02:41:41.15"),
                    PlaceOrder = "Tien Giang",
                    Description = "600000",
                    Status = "Active"
                }
            };

        [Fact]
        public async void GetAllOrder()
        {
            mockOrderRepository.Setup(p => p.GetAllOrder()).ReturnsAsync(order);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var result = await orderService.GetAllOrder();
            var dbOrder = new List<Order>();
            dbOrder = result.Select(c => new Order
            {
                OrderId = c.OrderId,
                CustomerId = c.CustomerId,
                TotalPrice = c.TotalPrice,
                TimeOrder = c.TimeOrder,
                PlaceOrder = c.PlaceOrder,
                Description = c.Description,
                Status = c.Status
            }).ToList();
            var obj1Str = JsonConvert.SerializeObject(order);
            var obj2Str = JsonConvert.SerializeObject(dbOrder);
            Assert.Equal(obj1Str, obj2Str);
        }

        [Fact]
        public async void GetOrderById()
        {
            mockOrderRepository.Setup(p => p.GetOrderById(1)).ReturnsAsync(order[0]);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var result = await orderService.GetOrderById(1);
            var dbOrder = new Order();
            dbOrder.OrderId = result.OrderId;
            dbOrder.CustomerId = result.CustomerId;
            dbOrder.TotalPrice = result.TotalPrice;
            dbOrder.TimeOrder = result.TimeOrder;
            dbOrder.PlaceOrder = result.PlaceOrder;
            dbOrder.Description = result.Description;
            dbOrder.Status = result.Status;

            var obj1Str = JsonConvert.SerializeObject(order[0]);
            var obj2Str = JsonConvert.SerializeObject(dbOrder);
            Assert.Equal(obj1Str, obj2Str);
        }

        [Fact]
        public async Task AddOrder()
        {
            mockOrderRepository.Setup(r => r.AddOrder(order[0])).ReturnsAsync(order[0]);
            OrderRequest request = new OrderRequest()
            {      
                OrderId = 1,
                CustomerId = 1,
                TotalPrice = 200000,
                TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                PlaceOrder = "Tien Giang",
                Description = "200000",
                Status = "Active"
            };
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var addResult = await orderService.AddOrder(request);
            Assert.NotNull(addResult);
        }

        [Fact]
        public async void UpdateOrder()
        {
            Order dbOrder = new Order()
            {
                CustomerId = 1,
                TotalPrice = 200000,
                TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                PlaceOrder = "Tien Giang",
                Description = "200000",
                Status = "Active"
            };
            mockOrderRepository.Setup(p => p.GetOrderById(1)).ReturnsAsync(order[0]);
            mockOrderRepository.Setup(p => p.UpdateOrder(order[0])).ReturnsAsync(true);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            OrderRequest request = new OrderRequest()
            {
                OrderId = 1,
                CustomerId = 1,
                TotalPrice = 200000,
                TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                PlaceOrder = "Tien Giang",
                Description = "200000",
                Status = "Active"
            };
            var updateResult = await orderService.UpdateOrder(request);
            Assert.Equal("Successful", updateResult.Message);
        }
         

        [Fact]
        public async void DeleteOrder()
        {
            mockOrderRepository.Setup(p => p.GetOrderById(1)).ReturnsAsync(order[0]);
            mockOrderRepository.Setup(p => p.DeleteOrder(1)).ReturnsAsync(true);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var deleteResult = await orderService.DeleteOrder(1);
            Assert.Equal("Successful", deleteResult.Message);
        }
    }
}
