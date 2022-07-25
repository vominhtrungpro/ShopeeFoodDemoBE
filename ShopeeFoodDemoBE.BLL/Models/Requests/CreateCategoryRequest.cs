﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class CreateCategoryRequest
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
