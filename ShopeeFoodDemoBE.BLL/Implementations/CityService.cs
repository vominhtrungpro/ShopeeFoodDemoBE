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
    public class CityService : ICityService
    {
        private readonly ICityRepository _icityRepository;
        public CityService(ICityRepository icityRepository)
        {
            _icityRepository = icityRepository;
        }

        public Task<List<City>> GetAllCity()
        {
            return _icityRepository.GetAllCity();
        }

        public Task<City> GetCityById(int id)
        {
            return _icityRepository.GetCityById(id);
        }

        public Task<Boolean> AddCity(CityRequest request)
        {
            var city = new City()
            {
                CityName = request.CityName,
                Description = request.Description,
                Status = request.Status
            };
            return _icityRepository.AddCity(city);
        }

        public async Task<Boolean> UpdateCity(CityRequest request)
        {
            var city = await _icityRepository.GetCityById(request.CityId);
            city.CityName = request.CityName;
            city.Description = request.Description;
            city.Status = request.Status;
            await _icityRepository.UpdateCity(city);
            return true;
        }

        public Task<Boolean> DeleteCity(int id)
        {
            return _icityRepository.DeleteCity(id);
        }
    }
}
