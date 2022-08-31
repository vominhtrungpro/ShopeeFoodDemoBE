using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class RestaurantService : IRestaurantService
    {
        private readonly IRestaurantRepository _restaurantRepository;
        public RestaurantService(IRestaurantRepository restaurantRepository)
        {
            _restaurantRepository = restaurantRepository;
        }

        public async Task<List<DtoRestaurant>> GetAllRestaurant()
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetAllRestaurant();
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status,

            }).ToList();
            return dtoRestaurant;
        }

        public async Task<DtoRestaurant> GetRestaurantById(int id)
        {
            var dtoRestaurant = new DtoRestaurant();
            var dbMdbRestaurantenu = await _restaurantRepository.GetRestaurantById(id);
            if (dbMdbRestaurantenu == null)
            {
                return await Task.FromResult<DtoRestaurant>(null);
            }
            else
            {
                dtoRestaurant.RestaurantId = dbMdbRestaurantenu.RestaurantId;
                dtoRestaurant.CityId = dbMdbRestaurantenu.CityId;
                dtoRestaurant.RestaurantTypeId = dbMdbRestaurantenu.RestaurantTypeId;
                dtoRestaurant.RestaurantName = dbMdbRestaurantenu.RestaurantName;
                dtoRestaurant.RestaurantAddress = dbMdbRestaurantenu.RestaurantAddress;
                dtoRestaurant.RestaurantImage = dbMdbRestaurantenu.RestaurantImage;
                dtoRestaurant.Description = dbMdbRestaurantenu.Description;
                dtoRestaurant.Status = dbMdbRestaurantenu.Status;
                return dtoRestaurant;
            }
        }

        public async Task<List<DtoRestaurant>> GetRestaurantByCategoryId(int id)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetRestaurantByCategoryId(id);
            if (!dbRestaurant.Any())
            {
                return await Task.FromResult<List<DtoRestaurant>>(null);
            }
            else
            {
                dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
                {
                    RestaurantId = c.RestaurantId,
                    CityId = c.CityId,
                    RestaurantTypeId = c.RestaurantTypeId,
                    RestaurantName = c.RestaurantName,
                    RestaurantAddress = c.RestaurantAddress,
                    RestaurantImage = c.RestaurantImage,
                    Description = c.Description,
                    Status = c.Status

                }).ToList();
                return dtoRestaurant;
            }
        }

        public async Task<List<DtoRestaurant>> GetRestaurantByCityId(int id)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetRestaurantByCityId(id);
            if (!dbRestaurant.Any())
            {
                return await Task.FromResult<List<DtoRestaurant>>(null);
            }
            else
            {
                dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
                {
                    RestaurantId = c.RestaurantId,
                    CityId = c.CityId,
                    RestaurantTypeId = c.RestaurantTypeId,
                    RestaurantName = c.RestaurantName,
                    RestaurantAddress = c.RestaurantAddress,
                    RestaurantImage = c.RestaurantImage,
                    Description = c.Description,
                    Status = c.Status

                }).ToList();
                return dtoRestaurant;
            }
        }

        public async Task<List<DtoRestaurant>> GetRestaurantByRestaurantTypeId(int id)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetRestaurantByRestaurantTypeId(id);
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurant;
        }

        public async Task<List<DtoRestaurant>> GetRestaurantByCategoryIdAndCityId(int cateId, int cityId)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetRestaurantByCategoryIdAndCityId(cateId, cityId);
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurant;
        }

        public async Task<List<DtoRestaurant>> GetResByCityIdsAndResTypeIds(RestaurantRequestListCityListRestaurantType request)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetResByCityIdsAndResTypeIds(request.CityIds, request.RestaurantTypeIds);
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurant;
        }

        public async Task<List<DtoRestaurant>> GetResByCityIdsAndResTypeIdsWithPaging(RestaurantResponse respone)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetResByCityIdsAndResTypeIdsWithPaging(respone.CityIds, respone.RestaurantTypeIds, respone.Page);
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurant;
        }

        public async Task<List<DtoRestaurant>> GetResByCityIdsAndResTypeIdsAndTextWithPaging(RestaurantResponseWithText respone)
        {
            var dtoRestaurant = new List<DtoRestaurant>();
            var dbRestaurant = await _restaurantRepository.GetResByCityIdsAndResTypeIdsAndTextWithPaging(respone.CityIds, respone.RestaurantTypeIds,respone.Text, respone.Page);
            dtoRestaurant = dbRestaurant.Select(c => new DtoRestaurant
            {
                RestaurantId = c.RestaurantId,
                CityId = c.CityId,
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantName = c.RestaurantName,
                RestaurantAddress = c.RestaurantAddress,
                RestaurantImage = c.RestaurantImage,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurant;
        }

        public async Task<ActionResponse> AddRestaurant(RestaurantRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var restaurant = new Restaurant()
            {
                CityId = request.CityId,
                RestaurantTypeId = request.RestaurantTypeId,
                RestaurantName = request.RestaurantName,
                RestaurantAddress = request.RestaurantAddress,
                RestaurantImage = request.RestaurantImage,
                Description = request.Description,
                Status = request.Status,
            };
            var addResult = await _restaurantRepository.AddRestaurant(restaurant);
            if (addResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Add failed!";
            }
            return result;
        }

        public async Task<ActionResponse> UpdateRestaurant(RestaurantRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbRestaurant = await _restaurantRepository.GetRestaurantById(request.RestaurantId);
            if (dbRestaurant == null)
            {
                result.Success = false;
                result.Message = "Restaurant not found!";
                return result;
            }
            dbRestaurant.CityId = request.CityId;
            dbRestaurant.RestaurantTypeId = request.RestaurantTypeId;
            dbRestaurant.RestaurantName = request.RestaurantName;
            dbRestaurant.RestaurantAddress = request.RestaurantAddress;
            dbRestaurant.RestaurantImage = request.RestaurantImage;
            dbRestaurant.Description = request.Description;
            dbRestaurant.Status = request.Status;
            var updateResult = await _restaurantRepository.UpdateRestaurant(dbRestaurant);
            if (updateResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Update failed!";
            }
            return result;
        }

        public async Task<ActionResponse> DeleteRestaurant(int id)
        {
            var result = new ActionResponse();
            var dbMenu = await _restaurantRepository.GetRestaurantById(id);
            if (dbMenu == null)
            {
                result.Success = false;
                result.Message = "Restaurant not found!";
                return result;
            }
            var deleteResult = await _restaurantRepository.DeleteRestaurant(id);
            if (deleteResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Delete failed";
            }
            return result;
        }
    }
}
