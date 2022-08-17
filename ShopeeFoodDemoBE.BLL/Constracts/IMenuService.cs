using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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
        Task<List<DtoMenu>> GetAllMenu();

        Task<DtoMenu> GetMenuById(int id);

        Task<List<DtoMenu>> GetMenuByRestaurantId(int id);

        Task<ActionResponse> AddMenu(MenuRequest request);

        Task<ActionResponse> UpdateMenu(MenuRequest request);

        Task<ActionResponse> DeleteMenu(int id);
    }
}
