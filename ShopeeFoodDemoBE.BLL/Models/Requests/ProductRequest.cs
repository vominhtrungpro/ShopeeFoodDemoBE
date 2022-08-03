using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class ProductRequest
    {

        public int ProductId { get; set; }

        public int MenuId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductImage { get; set; }
 
        public int AmountStock { get; set; }

        public int AmountPurchased { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
