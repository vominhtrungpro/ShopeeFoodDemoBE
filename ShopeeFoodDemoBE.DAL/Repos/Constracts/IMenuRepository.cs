using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IMenuRepository
    {
        Task<List<Menu>> GetAllMenu();

        Task<Menu> GetMenuById(int id);

        Task<Boolean> AddMenu(Menu menu);

        Task<Boolean> UpdateMenu(Menu menu);

        Task<Boolean> DeleteMenu(int id);

        Task<List<Menu>> GetMenuByRestaurantId(int id);
    }
}
