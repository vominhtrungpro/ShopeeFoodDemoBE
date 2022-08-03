using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.DAL.Repos.Constracts
{
    public interface IOptionRepository
    {
        Task<List<Option>> GetAllOption();

        Task<Option> GetOptionById(int id);

        Task<Boolean> AddOption(Option option);

        Task<Boolean> UpdateOption(Option option);

        Task<Boolean> DeleteOption(int id);
    }
}
