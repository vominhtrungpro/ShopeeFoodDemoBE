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
        private readonly IOptionRepository _optionRepository;
        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public Task<List<Option>> GetAllOption()
        {
            return _optionRepository.GetAllOption();
        }

        public Task<Option> GetOptionById(int id)
        {
            return _optionRepository.GetOptionById(id);
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
            return _optionRepository.AddOption(option);
        }

        public async Task<Boolean> UpdateOption(OptionRequest request)
        {
            var option = await _optionRepository.GetOptionById(request.OptionId);
            option.OptionName = request.OptionName;
            option.Description = request.Description;
            option.Status = request.Status;
            option.OptionTypeId = request.OptionTypeId;
            await _optionRepository.UpdateOption(option);
            return true;
        }

        public Task<Boolean> DeleteOption(int id)
        {
            return _optionRepository.DeleteOption(id);
        }

        public async Task<List<Option>> GetOptionByProductId(int id)
        {
            return await _optionRepository.GetOptionByProductId(id);
        }
    }
}
