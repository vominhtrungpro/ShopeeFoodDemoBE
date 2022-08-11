using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface ICityService
    {
        Task<List<City>> GetAllCity();

        Task<City> GetCityById(int id);

        Task<Boolean> AddCity(CityRequest request);

        Task<Boolean> UpdateCity(CityRequest request);

        Task<Boolean> DeleteCity(int id);
    }
}
