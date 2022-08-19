using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class CityRequest
    {
        public int CityId { get; set; }
        [Required(ErrorMessage = "City name is required")]
        public string CityName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
