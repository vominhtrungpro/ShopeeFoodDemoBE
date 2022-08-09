using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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

        Task<List<Restaurant>> GetRestaurantByCategoryIdAndCityId(int cateId, int cityId);

        Task<List<Restaurant>> GetResByCityIdsAndResTypeIds(RestaurantRequestListCityListRestaurantType request);

        Task<List<Restaurant>> GetResByCityIdsAndResTypeIdsWithPaging(RestaurantRespone respone);

        Task<Boolean> AddRestaurant(RestaurantRequest request);

        Task<Boolean> UpdateRestaurant(RestaurantRequest request);

        Task<Boolean> DeleteRestaurant(int id);
    }
}
