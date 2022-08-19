using Moq;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBeUnitTest
{
    [TestFixture]
    public class OrderTest
    {
        private readonly OrderService _orderService;
        private readonly Mock<IOrderRepository> mockOrderRepository;
        
        [SetUp]
        public void Setup()
        {
            _orderService = new OrderService(mockOrderRepository);
        }
    }
}
