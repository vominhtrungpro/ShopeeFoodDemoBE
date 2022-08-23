using Moq;
using Newtonsoft.Json;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

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

        [Theory]
        [InlineData(1)]
        [InlineData(2)]
        [InlineData(99)]
        [InlineData(-99)]
        public async void GetOrderById(int id)
        {
            mockOrderRepository.Setup(p => p.GetOrderById(1)).ReturnsAsync(order[0]);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var getResult = await orderService.GetOrderById(id);
            if (id == 1)
            {
                var dbOrder = new Order();
                dbOrder.OrderId = getResult.OrderId;
                dbOrder.CustomerId = getResult.CustomerId;
                dbOrder.TotalPrice = getResult.TotalPrice;
                dbOrder.TimeOrder = getResult.TimeOrder;
                dbOrder.PlaceOrder = getResult.PlaceOrder;
                dbOrder.Description = getResult.Description;
                dbOrder.Status = getResult.Status;
                var obj1Str = JsonConvert.SerializeObject(order[0]);
                var obj2Str = JsonConvert.SerializeObject(dbOrder);
                Assert.Equal(obj1Str, obj2Str);
            }
            else
            {
                Assert.Null(getResult);
            }
            
        }

        [Theory]
        [InlineData(1, 1, 200000, "2022-08-09T02:23:12.927", "Tien Giang", "200000", "Active")]
        [InlineData(1, 1, 200000, "2022-08-09T02:23:12.927", "Tien Giang", "200000", "Unactive")]

        public async Task AddOrder(int orderId,int customerId, int totalPrice, DateTime timeOrder, string placeOrder, string description, string status)
        {
            OrderRequest request = new OrderRequest()
            {
                OrderId = orderId,
                CustomerId = customerId,
                TotalPrice = totalPrice,
                TimeOrder = Convert.ToDateTime(timeOrder),
                PlaceOrder = placeOrder,
                Description = description,
                Status = status
            };
            var dbOrder = order[0];
            mockOrderRepository.Setup(r => r.AddOrder(It.IsAny<Order>())).ReturnsAsync(dbOrder);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            if (status == "Active")
            {

                var addResult = await orderService.AddOrder(request);
                var obj1Str = JsonConvert.SerializeObject(dbOrder);
                var obj2Str = JsonConvert.SerializeObject(addResult);
                Assert.Equal(obj1Str, obj2Str);
            }
            else
            {
                var exception = await Assert.ThrowsAsync<Exception>(() => orderService.AddOrder(request));
                Assert.Equal("Status invalid!", exception.Message);
            }
        }

        [Theory]
        [InlineData("Successful", 1,1,200000, "2022-08-09T02:23:12.927","Tien Giang","200000","Active")]
        [InlineData("Order not found!", 2, 1, 200000, "2022 -08-09T02:23:12.927", "Tien Giang", "200000", "Active")]
        [InlineData("Status invalid!", 1, 1, 200000, "2022-08-09T02:23:12.927", "Tien Giang", "200000", "Unactive")]
        [InlineData("Successful", 1, 1, 200000, "2022-08-09T02:23:12.927", "", "", "Active")]
        public async void UpdateOrder(string result,int orderId, int customerId, double totalPrice, DateTime timeOrder, string placeOrder, string description, string status)
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
                OrderId = orderId,
                CustomerId = customerId,
                TotalPrice = totalPrice,
                TimeOrder = Convert.ToDateTime(timeOrder),
                PlaceOrder = placeOrder,
                Description = description,
                Status = status
            };
            var updateResult = await orderService.UpdateOrder(request);
            Assert.Equal(result, updateResult.Message);
        }


        [Theory]
        [InlineData(1,"Successful")]
        [InlineData(2, "Order not found!")]
        [InlineData(99, "Order not found!")]
        [InlineData(-99, "Order not found!")]
        public async void DeleteOrder(int id,string result)
        {
            mockOrderRepository.Setup(p => p.GetOrderById(id)).ReturnsAsync(order[0]);
            mockOrderRepository.Setup(p => p.DeleteOrder(id)).ReturnsAsync(true);
            OrderService orderService = new OrderService(mockOrderRepository.Object);
            var deleteResult = await orderService.DeleteOrder(1);
            Assert.Equal(deleteResult.Message, result);
        }
    }
}
