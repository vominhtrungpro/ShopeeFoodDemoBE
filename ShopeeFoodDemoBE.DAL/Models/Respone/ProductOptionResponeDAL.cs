using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Models.Respone
{
    public class ProductOptionResponeDAL
    {
        public int ProductId { get; set; }

        public int MenuId { get; set; }

        public string ProductName { get; set; }

        public double ProductPrice { get; set; }

        public string ProductImage { get; set; }

        public int AmountStock { get; set; }

        public int AmountPurchased { get; set; }

        public int ItemOptionId { get; set; }

        public int OptionId { get; set; }

        public string OptionName { get; set; }

        public int OptionTypeId { get; set; }

        public string OptionTypeName { get; set; }


    }
}
