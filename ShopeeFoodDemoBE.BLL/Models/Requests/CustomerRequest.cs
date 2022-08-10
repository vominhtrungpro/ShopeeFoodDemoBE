using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class CustomerRequest
    {
 
        public int CustomerId { get; set; }

        public string CustomerUsername { get; set; }


        public string CustomerPassword { get; set; }

        public string CustomerFullname { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerPhone { get; set; }

        public string CustomerEmail { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
