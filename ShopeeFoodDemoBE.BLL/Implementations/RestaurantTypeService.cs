using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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

        public async Task<List<DtoRestaurantType>> GetAllRestaurantType()
        {
            var dtoRestaurantType = new List<DtoRestaurantType>();
            var dbRestaurantType = await _restauranttypeRepository.GetAllRestaurantType();
            dtoRestaurantType = dbRestaurantType.Select(c => new DtoRestaurantType
            {
                RestaurantTypeId = c.RestaurantTypeId,
                RestaurantTypeName = c.RestaurantTypeName,
                CategoryId = c.CategoryId,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoRestaurantType;
        }

        public async Task<DtoRestaurantType> GetRestaurantTypeById(int id)
        {
            var dtoRestaurantType = new DtoRestaurantType();
            var dbRestaurantType = await _restauranttypeRepository.GetRestaurantTypeById(id);
            if (dbRestaurantType == null)
            {
                return await Task.FromResult<DtoRestaurantType>(null);
            }
            else
            {
                dtoRestaurantType.RestaurantTypeId = dbRestaurantType.RestaurantTypeId;
                dtoRestaurantType.RestaurantTypeName = dbRestaurantType.RestaurantTypeName;
                dtoRestaurantType.CategoryId = dbRestaurantType.CategoryId;
                dtoRestaurantType.Description = dbRestaurantType.Description;
                dtoRestaurantType.Status = dbRestaurantType.Status;
                return dtoRestaurantType;
            }
        }

        public async Task<List<DtoRestaurantType>> GetRestaurantTypeByCategoryId(int id)
        {
            var dtoRestaurantType = new List<DtoRestaurantType>();
            var dbRestaurantType = await _restauranttypeRepository.GetRestaurantTypeByCategoryId(id);
            if (!dbRestaurantType.Any())
            {
                return await Task.FromResult<List<DtoRestaurantType>>(null);
            }
            else
            {
                dtoRestaurantType = dbRestaurantType.Select(c => new DtoRestaurantType
                {
                    RestaurantTypeId = c.RestaurantTypeId,
                    RestaurantTypeName = c.RestaurantTypeName,
                    CategoryId = c.CategoryId,
                    Description = c.Description,
                    Status = c.Status

                }).ToList();
                return dtoRestaurantType;
            }
        }

        public async Task<ActionResponse> AddRestaurantType(RestaurantTypeRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var restauranttype = new RestaurantType()
            {
                RestaurantTypeName = request.RestaurantTypeName,
                CategoryId = request.CategoryId,
                Description = request.Description,
                Status = request.Status

            };
            var addResult = await _restauranttypeRepository.AddRestaurantType(restauranttype);
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

        public async Task<ActionResponse> UpdateRestaurantType(RestaurantTypeRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbRestaurantType = await _restauranttypeRepository.GetRestaurantTypeById(request.RestaurantTypeId);
            if (dbRestaurantType == null)
            {
                result.Success = false;
                result.Message = "RestaurantType not found!";
                return result;
            }
            dbRestaurantType.RestaurantTypeName = request.RestaurantTypeName;
            dbRestaurantType.CategoryId = request.CategoryId;
            dbRestaurantType.Description = request.Description;
            dbRestaurantType.Status = request.Status;
            var updateResult = await _restauranttypeRepository.UpdateRestaurantType(dbRestaurantType);
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

        public async Task<ActionResponse> DeleteRestaurantType(int id)
        {
            var result = new ActionResponse();
            var dbRestaurantType = await _restauranttypeRepository.GetRestaurantTypeById(id);
            if (dbRestaurantType == null)
            {
                result.Success = false;
                result.Message = "RestaurantType not found!";
                return result;
            }
            var deleteResult = await _restauranttypeRepository.DeleteRestaurantType(id);
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
