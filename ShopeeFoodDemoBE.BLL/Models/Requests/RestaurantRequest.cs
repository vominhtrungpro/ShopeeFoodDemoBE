using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class RestaurantRequest
    {


        public int RestaurantId { get; set; }
        [Required(ErrorMessage = "City Id is required")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "RestaurantType Id is required")]
        public int RestaurantTypeId { get; set; }
        [Required(ErrorMessage = "Restaurant Name is required")]
        public string RestaurantName { get; set; }
        [Required(ErrorMessage = "Restaurant Address is required")]
        public string RestaurantAddress { get; set; }
        [Required(ErrorMessage = "Restaurant Image is required")]
        public string RestaurantImage { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
