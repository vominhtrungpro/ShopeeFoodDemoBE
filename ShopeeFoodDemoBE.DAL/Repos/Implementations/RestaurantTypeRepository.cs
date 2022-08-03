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
    public class RestaurantTypeRepository : IRestaurantTypeRepository
    {
        private readonly DataContext _dataContext;
        public RestaurantTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<RestaurantType>> GetAllRestaurantType()
        {
            return await _dataContext.RestaurantType.ToListAsync();
        }

        public async Task<RestaurantType> GetRestaurantTypeById(int id)
        {
            return await _dataContext.RestaurantType.FindAsync(id);
        }

        public async Task<Boolean> AddRestaurantType(RestaurantType restauranttype)
        {
            _dataContext.RestaurantType.Add(restauranttype);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<RestaurantType>> GetRestaurantTypeByCategoryId(int id)
        {
            var query = from r in _dataContext.RestaurantType
                        join c in _dataContext.Category
                        on r.CategoryId equals c.CategoryId
                        where c.CategoryId == id
                        select new { r };

            return await query.Select(x => new RestaurantType() { 
                RestaurantTypeId = x.r.RestaurantTypeId,
                CategoryId = x.r.CategoryId,
                RestaurantTypeName = x.r.RestaurantTypeName,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<Boolean> UpdateRestaurantType(RestaurantType restauranttype)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteRestaurantType(int id)
        {
            var restauranttype = await GetRestaurantTypeById(id);
            _dataContext.RestaurantType.Remove(restauranttype);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
