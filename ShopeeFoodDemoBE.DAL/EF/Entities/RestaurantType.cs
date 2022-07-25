using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class RestaurantType
    {
        [Key]
        public int RestaurantTypeId { get; set; }
        [Required(ErrorMessage = "RestaurantType name is needed")]
        public string RestaurantTypeName { get; set; }
        [Required(ErrorMessage = "Category id is needed")]
        public int CategoryId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Category Category { get; set; }

        public List<Restaurant> Restaurant { get; set; }
    }
}
