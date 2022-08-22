using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class ProductRequest
    {

        public int ProductId { get; set; }
        [Required(ErrorMessage = "Menu Id is required")]
        public int MenuId { get; set; }
        [Required(ErrorMessage = "Product Name is required")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "Product Price is required")]
        public double ProductPrice { get; set; }
        [Required(ErrorMessage = "Product Image is required")]
        public string ProductImage { get; set; }
        [Required(ErrorMessage = "Amount Stock is required")]
        public int AmountStock { get; set; }
        [Required(ErrorMessage = "Amount Purchased is required")]
        public int AmountPurchased { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
