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
    public class ItemOptionRepository : IItemOptionRepository
    {
        private readonly DataContext _dataContext;
        public ItemOptionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ItemOption>> GetAllItemOption()
        {
            return await _dataContext.ItemOption.ToListAsync();
        }

        public async Task<ItemOption> GetItemOptionById(int id)
        {
            return await _dataContext.ItemOption.FindAsync(id);
        }

        public async Task<Boolean> AddItemOption(ItemOption itemoption)
        {
            _dataContext.ItemOption.Add(itemoption);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateItemOption(ItemOption itemoption)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteItemOption(int id)
        {
            var itemoption = await GetItemOptionById(id);
            _dataContext.ItemOption.Remove(itemoption);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
