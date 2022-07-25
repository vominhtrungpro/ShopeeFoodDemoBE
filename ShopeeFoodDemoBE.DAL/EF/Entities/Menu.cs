using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class Menu
    {
        [Key]
        public int MenuId { get; set; }
        [Required(ErrorMessage = "Menu name is needed")]
        public string MenuName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
        [Required(ErrorMessage = "Restaurant id is needed")]
        public int RestaurantId { get; set; }

        public List<Product> Product { get; set; }

        public Restaurant Restaurant { get; set; }
    }
}
