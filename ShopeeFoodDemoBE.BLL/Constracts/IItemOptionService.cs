using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IItemOptionService
    {
        Task<List<ItemOption>> GetAllItemOption();

        Task<ItemOption> GetItemOptionById(int id);

        Task<Boolean> AddItemOption(ItemOptionRequest request);

        Task<Boolean> UpdateItemOption(ItemOptionRequest request);

        Task<Boolean> DeleteItemOption(int id);
    }
}
