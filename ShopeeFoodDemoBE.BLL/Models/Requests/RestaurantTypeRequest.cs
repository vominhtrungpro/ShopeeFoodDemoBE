using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class RestaurantTypeRequest
    {
        public int RestaurantTypeId { get; set; }
        [Required(ErrorMessage = "RestaurantType Name is required")]
        public string RestaurantTypeName { get; set; }
        [Required(ErrorMessage = "Category Id is required")]
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
