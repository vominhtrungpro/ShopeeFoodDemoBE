using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class CityRepository : ICityRepository
    {
        private readonly DataContext _dataContext;
        public CityRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<City>> GetAllCity()
        {
            return await _dataContext.City.ToListAsync();
        }

        public async Task<City> GetCityById(int id)
        {
            return await _dataContext.City.FindAsync(id);
        }

        public async Task<Boolean> AddCity(City city)
        {
            _dataContext.City.Add(city);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateCity(City city)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteCity(int id)
        {
            var city = await GetCityById(id);
            _dataContext.City.Remove(city);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
