using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Responses
{
    public class RestaurantResponseWithText
    {
        public List<int> CityIds { get; set; }

        public List<int> RestaurantTypeIds { get; set; }

        public string Text { get; set; }

        public int Page { get; set; }
    }
}
