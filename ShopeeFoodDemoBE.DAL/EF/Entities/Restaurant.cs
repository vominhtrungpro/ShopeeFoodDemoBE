using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        [Required(ErrorMessage = "City id is needed")]
        public int CityId { get; set; }
        [Required(ErrorMessage = "RestaurantType id is needed")]
        public int RestaurantTypeId { get; set; }
        [Required(ErrorMessage = "Restaurant name is needed")]
        public string RestaurantName { get; set; }
        [Required(ErrorMessage = "Restaurant address is needed")]
        public string RestaurantAddress { get; set; }
        [Required(ErrorMessage = "Restaurant image is needed")]
        public string RestaurantImage { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public List<Menu> Menu { get; set; }

        public City City { get; set; }

        public RestaurantType RestaurantType { get; set; }
    }
}
