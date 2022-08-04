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
    public class RestaurantTypeService : IRestaurantTypeService
    {
        private readonly IRestaurantTypeRepository _restauranttypeRepository;
        public RestaurantTypeService(IRestaurantTypeRepository restauranttypeRepository)
        {
            _restauranttypeRepository = restauranttypeRepository;
        }

        public Task<List<RestaurantType>> GetAllRestaurantType()
        {
            return _restauranttypeRepository.GetAllRestaurantType();
        }

        public Task<RestaurantType> GetRestaurantTypeById(int id)
        {
            return _restauranttypeRepository.GetRestaurantTypeById(id);
        }

        public Task<List<RestaurantType>> GetRestaurantTypeByCategoryId(int id)
        {
            return _restauranttypeRepository.GetRestaurantTypeByCategoryId(id);
        }

        public Task<Boolean> AddRestaurantType(RestaurantTypeRequest request)
        {
            var restauranttype = new RestaurantType()
            {
                RestaurantTypeName = request.RestaurantTypeName,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Status = request.Status
            };
            return _restauranttypeRepository.AddRestaurantType(restauranttype);
        }

        public async Task<Boolean> UpdateRestaurantType(RestaurantTypeRequest request)
        {
            var restauranttype = await _restauranttypeRepository.GetRestaurantTypeById(request.RestaurantTypeId);
            restauranttype.RestaurantTypeName = request.RestaurantTypeName;
            restauranttype.CategoryId = request.CategoryId;
            restauranttype.Description = request.Description;
            restauranttype.Status = request.Status;
            await _restauranttypeRepository.UpdateRestaurantType(restauranttype);
            return true;
        }

        public Task<Boolean> DeleteRestaurantType(int id)
        {
            return _restauranttypeRepository.DeleteRestaurantType(id);
        }
    }
}
