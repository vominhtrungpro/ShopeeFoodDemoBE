using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Models.Requests
{
    public class RestaurantRequestListCityListRestaurantType
    {

        public List<int> RestaurantTypeId { get; set; }

        public List<int> CityId { get; set; }
    }
}
