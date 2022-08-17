using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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

        public async Task<List<DtoMenu>> GetAllMenu()
        {
            var dtoMenu = new List<DtoMenu>();
            var dbMenu = await _menuRepository.GetAllMenu();
            dtoMenu = dbMenu.Select(c => new DtoMenu
            {
                MenuId = c.MenuId,
                MenuName = c.MenuName,
                Description = c.Description,
                Status = c.Status,
                RestaurantId = c.RestaurantId

            }).ToList();
            return dtoMenu;
        }

        public async Task<DtoMenu> GetMenuById(int id)
        {
            var dtoMenu = new DtoMenu();
            var dbMenu = await _menuRepository.GetMenuById(id);
            if (dbMenu == null)
            {
                return await Task.FromResult<DtoMenu>(null);
            }
            else
            {
                dtoMenu.MenuId = dbMenu.MenuId;
                dtoMenu.MenuName = dbMenu.MenuName;
                dtoMenu.Description = dbMenu.Description;
                dtoMenu.Status = dbMenu.Status;
                dtoMenu.RestaurantId = dbMenu.RestaurantId;
                return dtoMenu;
            }
        }

        public async Task<List<DtoMenu>> GetMenuByRestaurantId(int id)
        {
            var dtoMenu = new List<DtoMenu>();
            var dbMenu = await _menuRepository.GetMenuByRestaurantId(id);
            if (!dbMenu.Any())
            {
                return await Task.FromResult<List<DtoMenu>>(null);
            }
            else
            {
                dtoMenu = dbMenu.Select(c => new DtoMenu
                {
                    MenuId = c.MenuId,
                    MenuName = c.MenuName,
                    Description = c.Description,
                    Status = c.Status,
                    RestaurantId = c.RestaurantId

                }).ToList();
                return dtoMenu;
            }
        }

        public async Task<ActionResponse> AddMenu(MenuRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var menu = new Menu()
            {
                MenuName = request.MenuName,
                Description = request.Description,
                Status = request.Status,
                RestaurantId = request.RestaurantId
                
            };
            var addResult = await _menuRepository.AddMenu(menu);
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

        public async Task<ActionResponse> UpdateMenu(MenuRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbMenu = await _menuRepository.GetMenuById(request.MenuId);
            if (dbMenu == null)
            {
                result.Success = false;
                result.Message = "Menu not found!";
                return result;
            }
            dbMenu.MenuName = request.MenuName;
            dbMenu.Description = request.Description;
            dbMenu.Status = request.Status;
            dbMenu.RestaurantId = request.RestaurantId;
            var updateResult = await _menuRepository.UpdateMenu(dbMenu);
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

        public async Task<ActionResponse> DeleteMenu(int id)
        {
            var result = new ActionResponse();
            var dbMenu = await _menuRepository.GetMenuById(id);
            if (dbMenu == null)
            {
                result.Success = false;
                result.Message = "Menu not found!";
                return result;
            }
            var deleteResult = await _menuRepository.DeleteMenu(id);
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
