﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Dto
{
    public class DtoOption
    {
        public int OptionId { get; set; }

        public string OptionName { get; set; }

        public int OptionTypeId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
