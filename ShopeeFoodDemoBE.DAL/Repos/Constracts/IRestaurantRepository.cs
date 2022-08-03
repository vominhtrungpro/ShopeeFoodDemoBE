using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IRestaurantRepository
    {
        Task<List<Restaurant>> GetAllRestaurant();

        Task<Restaurant> GetRestaurantById(int id);

        Task<List<Restaurant>> GetRestaurantByCategoryId(int id);

        Task<List<Restaurant>> GetRestaurantByCityId(int id);

        Task<List<Restaurant>> GetRestaurantByRestaurantTypeId(int id);

        Task<List<Restaurant>> GetRestaurantByCategoryIdAndCityId(int id1, int id2);

        Task<List<Restaurant>> GetRestaurantByListCityIdAndListRestaurantTypeId(List<int> id1,List<int> id2);

        Task<List<Restaurant>> GetRestaurantByListCityId(List<int> id);

        Task<List<Restaurant>> GetRestaurantByListRestaurantTypeId(List<int> id);

        Task<Boolean> AddRestaurant(Restaurant restaurant);

        Task<Boolean> UpdateRestaurant(Restaurant restaurant);

        Task<Boolean> DeleteRestaurant(int id);
    }
}
