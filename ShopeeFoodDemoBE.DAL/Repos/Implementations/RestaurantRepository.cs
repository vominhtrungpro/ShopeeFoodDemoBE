using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Models.Respone;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class RestaurantRepository : IRestaurantRepository
    {
        private readonly DataContext _dataContext;
        public RestaurantRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Restaurant>> GetAllRestaurant()
        {
            return await _dataContext.Restaurant.ToListAsync();
        }

        public async Task<Restaurant> GetRestaurantById(int id)
        {
            return await _dataContext.Restaurant.FindAsync(id);
        }

        public async Task<List<Restaurant>> GetRestaurantByCategoryId(int id)
        {
            var query = from r in _dataContext.Restaurant
                        join t in _dataContext.RestaurantType on r.RestaurantTypeId equals t.RestaurantTypeId
                        join c in _dataContext.Category on t.CategoryId equals c.CategoryId
                        where c.CategoryId == id
                        select new { r };

            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantByRestaurantTypeId(int id)
        {
            var query = from r in _dataContext.Restaurant
                        join t in _dataContext.RestaurantType on r.RestaurantTypeId equals t.RestaurantTypeId
                        where t.RestaurantTypeId == id
                        select new { r };
            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantByCityId(int id)
        {
            var query = from r in _dataContext.Restaurant
                        join c in _dataContext.City on r.CityId equals c.CityId
                        where c.CityId == id
                        select new { r };
            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantByCategoryIdAndCityId(int cateId, int cityId)
        {
            var query = from r in _dataContext.Restaurant
                        join c in _dataContext.City on r.CityId equals c.CityId
                        join t in _dataContext.RestaurantType on r.RestaurantTypeId equals t.RestaurantTypeId
                        join ca in _dataContext.Category on t.CategoryId equals ca.CategoryId
                        where c.CityId == cityId && ca.CategoryId == cateId
                        select new { r };

            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<List<Restaurant>> GetResByCityIdsAndResTypeIds(List<int> cityIds,List<int> resTypeIds) 
        {

            var query = from r in _dataContext.Restaurant
                        join c in _dataContext.City on r.CityId equals c.CityId
                        join t in _dataContext.RestaurantType on r.RestaurantTypeId equals t.RestaurantTypeId
                        where r.Status == "Active"
                        select new { r };

            if (cityIds.Any())
                query = query.Where(a => cityIds.Contains(a.r.CityId));
            if (resTypeIds.Any())
                query = query.Where(a => resTypeIds.Contains(a.r.RestaurantTypeId));

            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<List<Restaurant>> GetResByCityIdsAndResTypeIdsWithPaging(List<int> cityIds, List<int> resTypeIds, int page)
        {

            var query = from r in _dataContext.Restaurant
                        join c in _dataContext.City on r.CityId equals c.CityId
                        join t in _dataContext.RestaurantType on r.RestaurantTypeId equals t.RestaurantTypeId
                        where r.Status == "Active"
                        select new { r };

            if (cityIds.Any())
                query = query.Where(a => cityIds.Contains(a.r.CityId));
            if (resTypeIds.Any())
                query = query.Where(a => resTypeIds.Contains(a.r.RestaurantTypeId));

            var pageResults = 5f;
            var pageCount = Math.Ceiling(_dataContext.Restaurant.Count() / pageResults);

            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            })
                .Skip((page -1)*(int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();

            
        }

        public async Task<List<Restaurant>> GetRestaurantByListCityId(List<int> id)
        {
            var query = from r in _dataContext.Restaurant
                        join c in _dataContext.City on r.CityId equals c.CityId
                        where id.Contains(c.CityId)
                        select new { r };

            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<List<Restaurant>> GetRestaurantByListRestaurantTypeId(List<int> id)
        {

            var query = from r in _dataContext.Restaurant
                        join t in _dataContext.RestaurantType on r.RestaurantTypeId equals t.RestaurantTypeId
                        where id.Contains(t.RestaurantTypeId)
                        select new { r };

            return await query.Select(x => new Restaurant()
            {
                RestaurantId = x.r.RestaurantId,
                CityId = x.r.CityId,
                RestaurantTypeId = x.r.RestaurantTypeId,
                RestaurantName = x.r.RestaurantName,
                RestaurantAddress = x.r.RestaurantAddress,
                RestaurantImage = x.r.RestaurantImage,
                Description = x.r.Description,
                Status = x.r.Status
            }).ToListAsync();
        }

        public async Task<Boolean> AddRestaurant(Restaurant restaurant)
        {
            _dataContext.Restaurant.Add(restaurant);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateRestaurant(Restaurant restaurant)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteRestaurant(int id)
        {
            var restaurant = await GetRestaurantById(id);
            _dataContext.Restaurant.Remove(restaurant);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
