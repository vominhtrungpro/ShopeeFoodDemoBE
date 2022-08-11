using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IItemOptionRepository
    {
        Task<List<ItemOption>> GetAllItemOption();

        Task<ItemOption> GetItemOptionById(int id);

        Task<Boolean> AddItemOption(ItemOption itemOption);

        Task<Boolean> UpdateItemOption(ItemOption itemOption);

        Task<Boolean> DeleteItemOption(int id);
    }
}
