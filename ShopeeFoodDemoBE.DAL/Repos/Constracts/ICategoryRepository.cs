using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategory();

        Task<Category> GetCategoryById(int id);

        Task<Boolean> AddCategory(Category category);

        Task<Boolean> UpdateCategory(Category category);

        Task<Boolean> DeleteCategory(int id);
    }
}
