using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface ISearchService
    {
        Task<List<DtoRestaurant>> GetRestaurantByText(string text);

        Task<List<DtoRestaurant>> GetRestaurantByTextWithPaging(int page,string text);

        Task<List<DtoRestaurant>> GetResByTextWithPaging(SearchResponse respone);
    }
}
