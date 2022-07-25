using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class OptionType
    {
        [Key]
        public int OptionTypeId { get; set; }
        [Required(ErrorMessage = "OptionType name is needed")]
        public string OptionTypeName { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public List<Option> Option { get; set; }

    }
}
