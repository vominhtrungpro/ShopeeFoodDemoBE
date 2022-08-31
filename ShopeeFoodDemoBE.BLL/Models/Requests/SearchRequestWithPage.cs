using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class SearchRequestWithPage
    {
        public string Text { get; set; }

        public int Page { get; set; }
    }
}
