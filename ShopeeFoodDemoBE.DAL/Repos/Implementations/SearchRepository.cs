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
    public class SearchRepository : ISearchRepository
    {
        private readonly DataContext _dataContext;
        public SearchRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Restaurant>> GetRestaurantByText(string text)
        {
            var query = from r in _dataContext.Restaurant
                        select new { r };

            if (text != "")
                query = query.Where(a => a.r.RestaurantName.Contains(text));

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

        public async Task<List<Restaurant>> GetRestaurantByTextWithPaging(int page,string text)
        {
            var query = from r in _dataContext.Restaurant
                        where r.Status == "Active"
                        select new { r };

            if (text != "")
                query = query.Where(a => a.r.RestaurantName.Contains(text));

            var pageResults = 10f;
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
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
        }

        public async Task<List<Restaurant>> GetResByTextWithPaging(string text, int page)
        {

            var query = from r in _dataContext.Restaurant
                        where r.Status == "Active"
                        select new { r };

            if (text.Any())
                query = query.Where(a => a.r.RestaurantName.Contains(text));


            var pageResults = 10f;
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
                .Skip((page - 1) * (int)pageResults)
                .Take((int)pageResults)
                .ToListAsync();
        }
    }
}
