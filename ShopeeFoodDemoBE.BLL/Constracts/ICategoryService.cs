using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategory();

        Task<Category> GetCategoryById(int id);

        Task<Boolean> AddCategory(CreateCategoryRequest request);

        Task<Boolean> UpdateCategory(UpdateCategoryRequest request);

        Task<Boolean> DeleteCategory(int id);
    }
}
