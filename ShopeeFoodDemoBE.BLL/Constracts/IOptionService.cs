using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IOptionService
    {
        Task<List<Option>> GetAllOption();

        Task<Option> GetOptionById(int id);

        Task<Boolean> AddOption(OptionRequest request);

        Task<Boolean> UpdateOption(OptionRequest request);

        Task<Boolean> DeleteOption(int id);

        Task<List<Option>> GetOptionByProductId(int id);
    }
}
