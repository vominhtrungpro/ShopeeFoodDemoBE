using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is needed")]

        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public List<RestaurantType> RestaurantType { get; set; }
    }
}
