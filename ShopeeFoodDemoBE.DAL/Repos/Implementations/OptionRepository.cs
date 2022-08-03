﻿using Microsoft.EntityFrameworkCore;
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
    public class OptionRepository : IOptionRepository
    {
        private readonly DataContext _dataContext;
        public OptionRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Option>> GetAllOption()
        {
            return await _dataContext.Option.ToListAsync();
        }

        public async Task<Option> GetOptionById(int id)
        {
            return await _dataContext.Option.FindAsync(id);
        }

        public async Task<Boolean> AddOption(Option option)
        {
            _dataContext.Option.Add(option);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateOption(Option option)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteOption(int id)
        {
            var option = await GetOptionById(id);
            _dataContext.Option.Remove(option);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}