using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class MenuRequest
    {
        public int MenuId { get; set; }
        [Required(ErrorMessage = "Menu Name is required")]
        public string MenuName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        [Required(ErrorMessage = "Restaurant Id is required")]
        public int RestaurantId { get; set; }
    }
}
