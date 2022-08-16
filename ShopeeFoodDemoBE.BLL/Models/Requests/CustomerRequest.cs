using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class CustomerRequest
    {
 
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Customer Username is required")]
        public string CustomerUsername { get; set; }
        [Required(ErrorMessage = "Customer Password is required")]
        public string CustomerPassword { get; set; }
        [Required(ErrorMessage = "Customer Fullname is required")]
        public string CustomerFullname { get; set; }
        [Required(ErrorMessage = "Customer Address is required")]
        public string CustomerAddress { get; set; }
        [Required(ErrorMessage = "Customer Phone is required")]
        public string CustomerPhone { get; set; }
        [Required(ErrorMessage = "Customer Email is required")]
        public string CustomerEmail { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
