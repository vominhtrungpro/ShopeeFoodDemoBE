using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class MenuRepository : IMenuRepository
    {
        private readonly DataContext _dataContext;
        public MenuRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Menu>> GetAllMenu()
        {
            return await _dataContext.Menu.ToListAsync();
        }

        public async Task<Menu> GetMenuById(int id)
        {
            return await _dataContext.Menu.FindAsync(id);
        }

        public async Task<Boolean> AddMenu(Menu menu)
        {
            _dataContext.Menu.Add(menu);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateMenu(Menu menu)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteMenu(int id)
        {
            var menu = await GetMenuById(id);
            _dataContext.Menu.Remove(menu);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Menu>> GetMenuByRestaurantId(int id)
        {
            var query = from m in _dataContext.Menu
                        join r in _dataContext.Restaurant
                        on m.RestaurantId equals r.RestaurantId
                        where r.RestaurantId == id
                        select new { m };

            return await query.Select(x => new Menu()
            {
                MenuId = x.m.MenuId,
                MenuName = x.m.MenuName,
                RestaurantId = x.m.RestaurantId,
                Description = x.m.Description,
                Status = x.m.Status
            }).ToListAsync();
        }
    }
}
