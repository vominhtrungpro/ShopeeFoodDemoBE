using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Responses
{
    public class RestaurantResponse
    {

        public List<int> CityIds { get; set; }

        public List<int> RestaurantTypeIds { get; set; }

        public int Page { get; set; }

    }
}
