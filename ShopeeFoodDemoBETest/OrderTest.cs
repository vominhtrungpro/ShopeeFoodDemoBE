using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Moq;
using ShopeeFoodDemoBE.BLL.Constracts;
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

        [Fact]
        public async void GetOrderById()
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>()
                .UseInMemoryDatabase(databaseName: "ShopeeDatabase");
            var context = new DataContext(optionBuilder.Options);

            var repository = new OrderRepository(context);
            var result = await repository.GetOrderById(1);
            Assert.Null(result);
        }
    }
}
