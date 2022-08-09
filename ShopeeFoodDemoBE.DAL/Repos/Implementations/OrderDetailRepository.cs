using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly DataContext _dataContext;
        public OrderDetailRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<OrderDetail>> GetAllOrderDetail()
        {
            return await _dataContext.OrderDetail.ToListAsync();
        }

        public async Task<OrderDetail> GetOrderDetailById(int id)
        {
            return await _dataContext.OrderDetail.FindAsync(id);
        }

        public async Task<Boolean> AddOrderDetail(OrderDetail orderdetail)
        {
            _dataContext.OrderDetail.Add(orderdetail);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateOrderDetail(OrderDetail orderdetail)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteOrderDetail(int id)
        {
            var orderdtail = await GetOrderDetailById(id);
            _dataContext.OrderDetail.Remove(orderdtail);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
