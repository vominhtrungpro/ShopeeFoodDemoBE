using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class OrderDetailRequest
    {

        public int OrderDetailId { get; set; }
        [Required(ErrorMessage = "Order Id is required")]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Product Id is required")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Amount is required")]
        public int Amount { get; set; }
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
    }
}
