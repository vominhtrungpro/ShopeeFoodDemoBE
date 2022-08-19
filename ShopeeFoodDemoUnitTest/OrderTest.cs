using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using NLog;
using ShopeeFoodDemoBE.API.Controllers;
using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Results;

namespace ShopeeFoodDemoUnitTest
{
    public class OrderTest
    {
        public Mock<IOrderService> mockOrderService = new Mock<IOrderService>();
        public Mock<ILogger<OrderController>> mockLogger = new Mock<ILogger<OrderController>>();
        [Fact]
        public async Task GetOrderById()
        {
            DtoOrder dtoOrder = new DtoOrder()
            {
                OrderId = 1,
                CustomerId = 1,
                TotalPrice = 200000,
                TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                PlaceOrder = "Tien Giang",
                Description = "200000",
                Status = "Active"
            };
            mockOrderService.Setup(p => p.GetOrderById(1)).ReturnsAsync(dtoOrder);
            OrderController orderController = new OrderController(mockOrderService.Object, mockLogger.Object);


        }
    }
}
