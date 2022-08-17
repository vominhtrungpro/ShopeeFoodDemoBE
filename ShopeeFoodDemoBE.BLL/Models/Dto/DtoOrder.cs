using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Dto
{
    public class DtoOrder
    {
        public int OrderId { get; set; }

        public int CustomerId { get; set; }
   
        public double TotalPrice { get; set; }
 
        public DateTime TimeOrder { get; set; }
   
        public string PlaceOrder { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
