using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public Task<List<Restaurant>> GetAllRestaurant()
        {
            return _restaurantRepository.GetAllRestaurant();
        }

        public Task<Restaurant> GetRestaurantById(int id)
        {
            return _restaurantRepository.GetRestaurantById(id);
        }

        public Task<List<Restaurant>> GetRestaurantByCategoryId(int id)
        {
            return _restaurantRepository.GetRestaurantByCategoryId(id);
        }

        public Task<List<Restaurant>> GetRestaurantByCityId(int id)
        {
            return _restaurantRepository.GetRestaurantByCityId(id);
        }

        public Task<List<Restaurant>> GetRestaurantByRestaurantTypeId(int id)
        {
            return _restaurantRepository.GetRestaurantByRestaurantTypeId(id);
        }

        public Task<List<Restaurant>> GetRestaurantByCategoryIdAndCityId(int cateId, int cityId)
        {
            return _restaurantRepository.GetRestaurantByCategoryIdAndCityId(cateId, cityId);
        }

        public Task<List<Restaurant>> GetResByCityIdsAndResTypeIds(RestaurantRequestListCityListRestaurantType request)
        {
            return _restaurantRepository.GetResByCityIdsAndResTypeIds(request.CityIds, request.RestaurantTypeIds);
        }

        public Task<List<Restaurant>> GetResByCityIdsAndResTypeIdsWithPaging(RestaurantRespone respone)
        {
            return _restaurantRepository.GetResByCityIdsAndResTypeIdsWithPaging(respone.CityIds, respone.RestaurantTypeIds, respone.Page);

        }

        public Task<Boolean> AddRestaurant(RestaurantRequest request)
        {
            var restaurant = new Restaurant()
            {
                CityId = request.CityId,
                RestaurantTypeId = request.RestaurantTypeId,
                RestaurantName = request.RestaurantName,
                RestaurantAddress = request.RestaurantAddress,
                RestaurantImage = request.RestaurantImage,
                Description = request.Description,
                Status = request.Status
            };
            return _restaurantRepository.AddRestaurant(restaurant);
        }

        public async Task<Boolean> UpdateRestaurant(RestaurantRequest request)
        {
            var restaurant = await _restaurantRepository.GetRestaurantById(request.RestaurantId);
            restaurant.CityId = request.CityId;
            restaurant.RestaurantTypeId = request.RestaurantTypeId;
            restaurant.RestaurantName = request.RestaurantName;
            restaurant.RestaurantAddress = request.RestaurantAddress;
            restaurant.RestaurantImage = request.RestaurantImage;
            restaurant.Description = request.Description;
            restaurant.Status = request.Status;
            await _restaurantRepository.UpdateRestaurant(restaurant);
            return true;
        }

        public Task<Boolean> DeleteRestaurant(int id)
        {
            return _restaurantRepository.DeleteRestaurant(id);
        }
    }
}
