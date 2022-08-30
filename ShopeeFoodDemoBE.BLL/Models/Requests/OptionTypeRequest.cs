using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class OptionTypeRequest
    {

        public int OptionTypeId { get; set; }
        [Required(ErrorMessage = "OptionType Name is required")]
        public string OptionTypeName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

    }
}
