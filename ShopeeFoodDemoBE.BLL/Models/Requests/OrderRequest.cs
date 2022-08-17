using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class OrderRequest
    {

        public int OrderId { get; set; }
        [Required(ErrorMessage = "Customer Id is required")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Total Price is required")]
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Time Order is required")]
        public DateTime TimeOrder { get; set; }
        [Required(ErrorMessage = "Place Order is required")]
        public string PlaceOrder { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
