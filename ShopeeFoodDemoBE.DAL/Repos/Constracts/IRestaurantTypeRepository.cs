using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IRestaurantTypeRepository
    {
        Task<List<RestaurantType>> GetAllRestaurantType();

        Task<RestaurantType> GetRestaurantTypeById(int id);

        Task<List<RestaurantType>> GetRestaurantTypeByCategoryId(int id);

        Task<Boolean> AddRestaurantType(RestaurantType restauranttype);

        Task<Boolean> UpdateRestaurantType(RestaurantType restauranttype);

        Task<Boolean> DeleteRestaurantType(int id);
    }
}
