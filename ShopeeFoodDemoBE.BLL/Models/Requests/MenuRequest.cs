﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class MenuRequest
    {
        public int MenuId { get; set; }
        public string MenuName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public int RestaurantId { get; set; }
    }
}
