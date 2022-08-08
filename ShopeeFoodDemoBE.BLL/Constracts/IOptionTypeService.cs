using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Models.Respone;
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

        Task<List<OptionType>> GetOptionTypeByProductId(int id);

        Task<List<ProductOptionResponeDAL>> GetOptionTypeDetailByProductId(int id);
    }
}
