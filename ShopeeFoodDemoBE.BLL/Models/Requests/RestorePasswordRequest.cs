using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class RestorePasswordRequest
    {
        public int CustomerId { get; set; }

        public string CustomerPassword { get; set; }

        public string CustomerConfirmPassword { get; set; }


    }
}
