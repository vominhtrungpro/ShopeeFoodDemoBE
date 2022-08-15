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
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        public MenuService(IMenuRepository menuRepository)
        {
            _menuRepository = menuRepository;
        }

        public Task<List<Menu>> GetAllMenu()
        {
            return _menuRepository.GetAllMenu();
        }

        public Task<Menu> GetMenuById(int id)
        {
            return _menuRepository.GetMenuById(id);
        }

        public Task<List<Menu>> GetMenuByRestaurantId(int id)
        {
            return _menuRepository.GetMenuByRestaurantId(id);
        }

        public Task<Boolean> AddMenu(MenuRequest request)
        {
            var menu = new Menu()
            {
                MenuName = request.MenuName,
                Description = request.Description,
                Status = request.Status,
                RestaurantId = request.RestaurantId
            };
            return _menuRepository.AddMenu(menu);
        }

        public async Task<Boolean> UpdateMenu(MenuRequest request)
        {
            var menu = await _menuRepository.GetMenuById(request.MenuId);
            menu.MenuName = request.MenuName;
            menu.Description = request.Description;
            menu.Status = request.Status;
            menu.RestaurantId = request.RestaurantId;
            await _menuRepository.UpdateMenu(menu);
            return true;
        }

        public Task<Boolean> DeleteMenu(int id)
        {
            return _menuRepository.DeleteMenu(id);
        }
    }
}
