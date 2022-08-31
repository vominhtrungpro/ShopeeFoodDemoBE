using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class OrderRepository : IOrderRepository
    {
        private readonly DataContext _dataContext;
        public OrderRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Order>> GetAllOrder()
        {
            return await _dataContext.Order.ToListAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            var result = await _dataContext.Order.FindAsync(id);
            return result;
        }

        public async Task<Order> AddOrder(Order order)
        {
            _dataContext.Order.Add(order);
            await _dataContext.SaveChangesAsync();
            return order;
        }

        public async Task<Boolean> UpdateOrder(Order order)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteOrder(int id)
        {
            var order = await GetOrderById(id);
            _dataContext.Order.Remove(order);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
