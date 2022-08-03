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
    public class OptionTypeRepository : IOptionTypeRepository
    {
        private readonly DataContext _dataContext;
        public OptionTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<OptionType>> GetAllOptionType()
        {
            return await _dataContext.OptionType.ToListAsync();
        }

        public async Task<OptionType> GetOptionTypeById(int id)
        {
            return await _dataContext.OptionType.FindAsync(id);
        }

        public async Task<Boolean> AddOptionType(OptionType optiontype)
        {
            _dataContext.OptionType.Add(optiontype);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateOptionType(OptionType optiontype)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteOptionType(int id)
        {
            var optiontype = await GetOptionTypeById(id);
            _dataContext.OptionType.Remove(optiontype);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
