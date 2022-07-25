using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class ItemOption
    {
        [Key]
        public int ItemOptionId { get; set; }
        [Required(ErrorMessage = "Product id is needed")]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "Option id is needed")]
        public int OptionId { get; set; }

        public Product Product { get; set; }

        public Option Option { get; set; }
    }
}
