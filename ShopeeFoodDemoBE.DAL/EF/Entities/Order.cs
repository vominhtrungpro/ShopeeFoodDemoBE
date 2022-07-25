using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Customer id is needed")]
        public int CustomerId { get; set; }
        [Required(ErrorMessage = "Total price is needed")]
        public double TotalPrice { get; set; }
        [Required(ErrorMessage = "Time order is needed")]
        public DateTime TimeOrder { get; set; }
        [Required(ErrorMessage = "Place order is needed")]
        public string PlaceOrder { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public Customer Customer { get; set; }

        public List<OrderDetail> OrderDetail { get; set; }
    }
}
