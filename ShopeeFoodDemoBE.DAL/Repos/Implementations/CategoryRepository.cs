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
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DataContext _dataContext;

        public CategoryRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<Category>> GetAllCategory()
        {
            return await _dataContext.Category.ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _dataContext.Category.FindAsync(id);
        }

        public async Task<Boolean> AddCategory(Category category)
        {
            _dataContext.Category.Add(category);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateCategory(Category category)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteCategory(int id)
        {
            var category = await GetCategoryById(id);
            _dataContext.Category.Remove(category);
            await _dataContext.SaveChangesAsync();
            return true;
        }
    }
}
