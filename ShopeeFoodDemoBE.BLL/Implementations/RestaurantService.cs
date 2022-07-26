using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
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
        private readonly IRestaurantRepository _irestaurantRepository;
        public RestaurantService(IRestaurantRepository irestaurantRepository)
        {
            _irestaurantRepository = irestaurantRepository;
        }

        public Task<List<Restaurant>> GetAllRestaurant()
        {
            return _irestaurantRepository.GetAllRestaurant();
        }

        public Task<Restaurant> GetRestaurantById(int id)
        {
            return _irestaurantRepository.GetRestaurantById(id);
        }

        public Task<List<Restaurant>> GetRestaurantByCategoryId(int id)
        {
            return _irestaurantRepository.GetRestaurantByCategoryId(id);
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
            return _irestaurantRepository.AddRestaurant(restaurant);
        }

        public async Task<Boolean> UpdateRestaurant(RestaurantRequest request)
        {
            var restaurant = await _irestaurantRepository.GetRestaurantById(request.RestaurantId);
            restaurant.CityId = request.CityId;
            restaurant.RestaurantTypeId = request.RestaurantTypeId;
            restaurant.RestaurantName = request.RestaurantName;
            restaurant.RestaurantAddress = request.RestaurantAddress;
            restaurant.RestaurantImage = request.RestaurantImage;
            restaurant.Description = request.Description;
            restaurant.Status = request.Status;
            await _irestaurantRepository.UpdateRestaurant(restaurant);
            return true;
        }

        public Task<Boolean> DeleteRestaurant(int id)
        {
            return _irestaurantRepository.DeleteRestaurant(id);
        }
    }
}
