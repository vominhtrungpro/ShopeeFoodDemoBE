using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _ioptionRepository;
        public OptionService(IOptionRepository ioptionRepository)
        {
            _ioptionRepository = ioptionRepository;
        }

        public Task<List<Option>> GetAllOption()
        {
            return _ioptionRepository.GetAllOption();
        }

        public Task<Option> GetOptionById(int id)
        {
            return _ioptionRepository.GetOptionById(id);
        }

        public Task<Boolean> AddOption(OptionRequest request)
        {
            var option = new Option()
            {
                OptionName = request.OptionName,
                Description = request.Description,
                Status = request.Status,
                OptionTypeId = request.OptionTypeId
            };
            return _ioptionRepository.AddOption(option);
        }

        public async Task<Boolean> UpdateOption(OptionRequest request)
        {
            var option = await _ioptionRepository.GetOptionById(request.OptionId);
            option.OptionName = request.OptionName;
            option.Description = request.Description;
            option.Status = request.Status;
            option.OptionTypeId = request.OptionTypeId;
            await _ioptionRepository.UpdateOption(option);
            return true;
        }

        public Task<Boolean> DeleteOption(int id)
        {
            return _ioptionRepository.DeleteOption(id);
        }
    }
}
