using Microsoft.EntityFrameworkCore;
using Moq;
using ShopeeFoodDemoBE.BLL.Implementations;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using ShopeeFoodDemoBE.DAL.Repos.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBEnUnitTest
{
    [TestFixture]
    public class OrderTest
    {

        private DataContext _dbContext;

        [SetUp]
        public void Setup()
        {
            var options =
            new DbContextOptionsBuilder<DataContext>()
                .UseSqlServer("EFConnection")
                .Options;
            _dbContext = new DataContext(options);
        }

        [Test]
        public async Task GetOrderById()
        {
            OrderRepository repo = new OrderRepository(_dbContext);
            var result1 = await repo.GetOrderById(1);
            Assert.IsNull(result1);
        }
    }
}
