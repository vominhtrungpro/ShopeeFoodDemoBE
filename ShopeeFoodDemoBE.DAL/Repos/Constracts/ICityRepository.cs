using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface ICityRepository
    {
        Task<List<City>> GetAllCity();

        Task<City> GetCityById(int id);

        Task<Boolean> AddCity(City city);

        Task<Boolean> UpdateCity(City city);

        Task<Boolean> DeleteCity(int id);

    }
}
