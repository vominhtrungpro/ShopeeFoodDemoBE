using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IOptionTypeService
    {
        Task<List<OptionType>> GetAllOptionType();

        Task<OptionType> GetOptionTypeById(int id);

        Task<Boolean> AddOptionType(OptionTypeRequest request);

        Task<Boolean> UpdateOptionType(OptionTypeRequest request);

        Task<Boolean> DeleteOptionType(int id);
    }
}
