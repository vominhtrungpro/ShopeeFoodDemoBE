using Moq;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.BLL.Models.Dto;
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
        private Mock<IOrderRepository> mockOrderRepository = new Mock<IOrderRepository>();

        [Fact]
        public async void GetOrderById()
        {
            var dtoOrder = new DtoOrder()
            {
                OrderId = 1,
                CustomerId = 1,
                TimeOrder = Convert.ToDateTime("2022-08-09T02:23:12.927"),
                PlaceOrder = "Tien Giang",
                Description = "200000",
                Status = "Active"
            };
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var result = await orderService.GetOrderById(1);
            Assert.Equal(dtoOrder.OrderId, result.OrderId);
        }
    }
}
