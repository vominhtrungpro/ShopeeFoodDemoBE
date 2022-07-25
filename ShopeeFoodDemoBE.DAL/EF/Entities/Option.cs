using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.EF.Entities
{
    public class Option
    {
        [Key]
        public int OptionId { get; set; }
        [Required(ErrorMessage = "Option name is needed")]
        public string OptionName { get; set; }
        [Required(ErrorMessage = "OptionType id is needed")]
        public int OptionTypeId { get; set; }

        public string Description { get; set; }

        public string Status { get; set; }

        public OptionType OptionType { get; set; }

        public List<ItemOption> ItemOpstion { get; set; }
    }
}
