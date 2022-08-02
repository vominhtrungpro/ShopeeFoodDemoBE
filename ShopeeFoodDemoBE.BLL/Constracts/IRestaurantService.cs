using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IRestaurantService
    {
        Task<List<Restaurant>> GetAllRestaurant();

        Task<Restaurant> GetRestaurantById(int id);

        Task<List<Restaurant>> GetRestaurantByCategoryId(int id);

        Task<List<Restaurant>> GetRestaurantByCityId(int id);

        Task<List<Restaurant>> GetRestaurantByRestaurantTypeId(int id);

        Task<List<Restaurant>> GetRestaurantByCategoryIdAndCityId(int id1, int id2);

        public Task<List<Restaurant>> GetRestaurantByListCityIdAndListRestaurantType(RestaurantRequestListCityListRestaurantType request);

        Task<Boolean> AddRestaurant(RestaurantRequest request);

        Task<Boolean> UpdateRestaurant(RestaurantRequest request);

        Task<Boolean> DeleteRestaurant(int id);
    }
}
