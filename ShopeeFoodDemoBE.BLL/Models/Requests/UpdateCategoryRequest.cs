using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Models.Requests
{
    public class UpdateCategoryRequest
    {
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Category name is required")]
        public string CategoryName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }
    }
}
