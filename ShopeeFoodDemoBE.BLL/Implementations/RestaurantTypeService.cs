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
        private readonly IRestaurantTypeRepository _irestauranttypeRepository;
        public RestaurantTypeService(IRestaurantTypeRepository irestauranttypeRepository)
        {
            _irestauranttypeRepository = irestauranttypeRepository;
        }

        public Task<List<RestaurantType>> GetAllRestaurantType()
        {
            return _irestauranttypeRepository.GetAllRestaurantType();
        }

        public Task<RestaurantType> GetRestaurantTypeById(int id)
        {
            return _irestauranttypeRepository.GetRestaurantTypeById(id);
        }

        public Task<List<RestaurantType>> GetRestaurantTypeByCategoryId(int id)
        {
            return _irestauranttypeRepository.GetRestaurantTypeByCategoryId(id);
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
            return _irestauranttypeRepository.AddRestaurantType(restauranttype);
        }

        public async Task<Boolean> UpdateRestaurantType(RestaurantTypeRequest request)
        {
            var restauranttype = await _irestauranttypeRepository.GetRestaurantTypeById(request.RestaurantTypeId);
            restauranttype.RestaurantTypeName = request.RestaurantTypeName;
            restauranttype.CategoryId = request.CategoryId;
            restauranttype.Description = request.Description;
            restauranttype.Status = request.Status;
            await _irestauranttypeRepository.UpdateRestaurantType(restauranttype);
            return true;
        }

        public Task<Boolean> DeleteRestaurantType(int id)
        {
            return _irestauranttypeRepository.DeleteRestaurantType(id);
        }
    }
}
