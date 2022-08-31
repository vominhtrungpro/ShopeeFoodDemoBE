using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface ISearchRepository
    {
        Task<List<Restaurant>> GetRestaurantByText(string text);

        Task<List<Restaurant>> GetRestaurantByTextWithPaging(int page,string text);

        Task<List<Restaurant>> GetResByTextWithPaging(string text, int page);
    }
}
