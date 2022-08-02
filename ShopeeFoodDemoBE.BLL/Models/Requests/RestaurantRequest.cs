using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class RestaurantRequest
    {
        public int RestaurantId { get; set; }
        public int CityId { get; set; }
        public int RestaurantTypeId { get; set; }
        public string RestaurantName { get; set; }
        public string RestaurantAddress { get; set; }
        public string RestaurantImage { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
