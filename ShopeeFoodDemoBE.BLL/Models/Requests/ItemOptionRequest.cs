using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class ItemOptionRequest
    {

        public int ItemOptionId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Option Id is required")]

        public int OptionId { get; set; }

    }
}
