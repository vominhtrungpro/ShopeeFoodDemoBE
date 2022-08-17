using ShopeeFoodDemoBE.BLL.Models.Dto;
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
        Task<List<DtoRestaurant>> GetAllRestaurant();

        Task<DtoRestaurant> GetRestaurantById(int id);

        Task<List<Restaurant>> GetRestaurantByCategoryId(int id);

        Task<List<Restaurant>> GetRestaurantByCityId(int id);

        Task<List<Restaurant>> GetRestaurantByRestaurantTypeId(int id);

        Task<List<Restaurant>> GetRestaurantByCategoryIdAndCityId(int cateId, int cityId);

        Task<List<Restaurant>> GetResByCityIdsAndResTypeIds(RestaurantRequestListCityListRestaurantType request);

        Task<List<Restaurant>> GetResByCityIdsAndResTypeIdsWithPaging(RestaurantResponse respone);

        Task<ActionResponse> AddRestaurant(RestaurantRequest request);

        Task<ActionResponse> UpdateRestaurant(RestaurantRequest request);

        Task<ActionResponse> DeleteRestaurant(int id);
    }
}
