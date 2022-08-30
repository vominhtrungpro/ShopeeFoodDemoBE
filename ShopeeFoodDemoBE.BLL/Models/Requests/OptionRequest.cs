using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class OptionRequest
    {

        public int OptionId { get; set; }
        [Required(ErrorMessage = "Option Name is required")]

        public string OptionName { get; set; }
        [Required(ErrorMessage = "OptionType Id is required")]

        public int OptionTypeId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
