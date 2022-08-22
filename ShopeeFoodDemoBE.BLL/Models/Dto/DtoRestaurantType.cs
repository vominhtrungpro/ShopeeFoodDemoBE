using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Dto
{
    public class DtoRestaurantType
    {
        public int RestaurantTypeId { get; set; }

        public string RestaurantTypeName { get; set; }

        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
