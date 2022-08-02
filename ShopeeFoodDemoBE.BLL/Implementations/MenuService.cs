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
        private readonly IMenuRepository _imenuRepository;
        public MenuService(IMenuRepository imenuRepository)
        {
            _imenuRepository = imenuRepository;
        }

        public Task<List<Menu>> GetAllMenu()
        {
            return _imenuRepository.GetAllMenu();
        }

        public Task<Menu> GetMenuById(int id)
        {
            return _imenuRepository.GetMenuById(id);
        }

        public Task<List<Menu>> GetMenuByRestaurantId(int id)
        {
            return _imenuRepository.GetMenuByRestaurantId(id);
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
            return _imenuRepository.AddMenu(menu);
        }

        public async Task<Boolean> UpdateMenu(MenuRequest request)
        {
            var menu = await _imenuRepository.GetMenuById(request.MenuId);
            menu.MenuName = request.MenuName;
            menu.Description = request.Description;
            menu.Status = request.Status;
            menu.RestaurantId = request.RestaurantId;
            await _imenuRepository.UpdateMenu(menu);
            return true;
        }

        public Task<Boolean> DeleteMenu(int id)
        {
            return _imenuRepository.DeleteMenu(id);
        }
    }
}
