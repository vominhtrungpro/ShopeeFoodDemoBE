﻿using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Models.Respone
{
    public class RestaurantRespone
    {
        public List<Restaurant> Restaurant { get; set; } 

        public int Pages { get; set; }
        public int CurrentPage { get; set; }

    }
}
