using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepository;
        public CityService(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        public async Task<List<DtoCity>> GetAllCity()
        {
            var dtoCity = new List<DtoCity>();
            var dbCity = await _cityRepository.GetAllCity();
            dtoCity = dbCity.Select(c => new DtoCity
            {
                CityId = c.CityId,
                CityName = c.CityName,
                Description = c.Description,
                Status = c.Status

            }).ToList();
            return dtoCity;
        }

        public async Task<DtoCity> GetCityById(int id)
        {
            var dtoCity = new DtoCity();
            var dbCity = await _cityRepository.GetCityById(id);
            if (dbCity == null)
            {
                return await Task.FromResult<DtoCity>(null);
            }
            else
            {
                dtoCity.CityId = dbCity.CityId;
                dtoCity.CityName = dbCity.CityName;
                dtoCity.Description = dbCity.Description;
                dtoCity.Status = dbCity.Status;
                return dtoCity;
            }
        }

        public async Task<ActionResponse> AddCity(CityRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var city = new City()
            {
                CityName = request.CityName,
                Description = request.Description,
                Status = request.Status
            };
            var addResult = await _cityRepository.AddCity(city);
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

        public async Task<ActionResponse> UpdateCity(CityRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbCity = await _cityRepository.GetCityById(request.CityId);
            if (dbCity == null)
            {
                result.Success = false;
                result.Message = "City not found!";
                return result;
            }
            dbCity.CityName = request.CityName;
            dbCity.Description = request.Description;
            dbCity.Status = request.Status;
            var updateResult = await _cityRepository.UpdateCity(dbCity);
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

        public async Task<ActionResponse> DeleteCity(int id)
        {
            var result = new ActionResponse();
            var dbCity = await _cityRepository.GetCityById(id);
            if (dbCity == null)
            {
                result.Success = false;
                result.Message = "City not found!";
                return result;
            }
            var deleteResult = await _cityRepository.DeleteCity(id);
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
