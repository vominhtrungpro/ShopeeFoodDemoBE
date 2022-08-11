using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IRestaurantTypeService
    {
        Task<List<RestaurantType>> GetAllRestaurantType();

        Task<RestaurantType> GetRestaurantTypeById(int id);

        Task<List<RestaurantType>> GetRestaurantTypeByCategoryId(int id);

        Task<Boolean> AddRestaurantType(RestaurantTypeRequest request);

        Task<Boolean> UpdateRestaurantType(RestaurantTypeRequest request);

        Task<Boolean> DeleteRestaurantType(int id);
    }
}
