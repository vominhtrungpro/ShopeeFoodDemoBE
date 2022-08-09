using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IMenuService
    {
        Task<List<Menu>> GetAllMenu();

        Task<Menu> GetMenuById(int id);

        Task<List<Menu>> GetMenuByRestaurantId(int id);

        Task<Boolean> AddMenu(MenuRequest request);

        Task<Boolean> UpdateMenu(MenuRequest request);

        Task<Boolean> DeleteMenu(int id);
    }
}
