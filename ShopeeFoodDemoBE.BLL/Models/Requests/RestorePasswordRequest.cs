using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class RestorePasswordRequest
    {
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Password is required")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "CustomerConfirm Password is required")]
        public string CustomerConfirmPassword { get; set; }


    }
}
