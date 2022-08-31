using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        public SearchService(ISearchRepository searchRepository)
        {
            _searchRepository = searchRepository;
        }

        public async Task<List<DtoRestaurant>> GetRestaurantByText(string text)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _searchRepository.GetRestaurantByText(text);
            if (!dbRestaurant.Any())
            {
                return await Task.FromResult<List<DtoRestaurant>>(null);
            }
            else
            {
                dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
                {
                    RestaurantId = c.RestaurantId,
                    CityId = c.CityId,
                    RestaurantTypeId = c.RestaurantTypeId,
                    RestaurantName = c.RestaurantName,
                    RestaurantAddress = c.RestaurantAddress,
                    RestaurantImage = c.RestaurantImage,
                    Description = c.Description,
                    Status = c.Status

                }).ToList();
                return dtoRestaurant;
            }
        }

        public async Task<List<DtoRestaurant>> GetRestaurantByTextWithPaging(int page,string text)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _searchRepository.GetRestaurantByTextWithPaging(page,text);
            if (!dbRestaurant.Any())
            {
                return await Task.FromResult<List<DtoRestaurant>>(null);
            }
            else
            {
                dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
                {
                    RestaurantId = c.RestaurantId,
                    CityId = c.CityId,
                    RestaurantTypeId = c.RestaurantTypeId,
                    RestaurantName = c.RestaurantName,
                    RestaurantAddress = c.RestaurantAddress,
                    RestaurantImage = c.RestaurantImage,
                    Description = c.Description,
                    Status = c.Status

                }).ToList();
                return dtoRestaurant;
            }
        }

        public async Task<List<DtoRestaurant>> GetResByTextWithPaging(SearchResponse respone)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _searchRepository.GetResByTextWithPaging(respone.Text, respone.Page);
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurant;
        }
    }
}
