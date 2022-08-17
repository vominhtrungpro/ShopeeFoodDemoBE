using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Models.Respone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IOptionTypeRepository
    {
        Task<List<OptionType>> GetAllOptionType();

        Task<OptionType> GetOptionTypeById(int id);

        Task<Boolean> AddOptionType(OptionType optiontype);

        Task<Boolean> UpdateOptionType(OptionType optiontype);

        Task<Boolean> DeleteOptionType(int id);

        Task<List<OptionType>> GetOptionTypeByProductId(int id);

        Task<List<ProductOptionResponeDAL>> GetOptionTypeDetailByProductId(int id);
    }
}
