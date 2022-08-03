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
    public class OptionTypeService : IOptionTypeService
    {
        private readonly IOptionTypeRepository _ioptiontypeRepository;
        public OptionTypeService(IOptionTypeRepository ioptiontypeRepository)
        {
            _ioptiontypeRepository = ioptiontypeRepository;
        }

        public Task<List<OptionType>> GetAllOptionType()
        {
            return _ioptiontypeRepository.GetAllOptionType();
        }

        public Task<OptionType> GetOptionTypeById(int id)
        {
            return _ioptiontypeRepository.GetOptionTypeById(id);
        }

        public Task<Boolean> AddOptionType(OptionTypeRequest request)
        {
            var optiontype = new OptionType()
            {
                OptionTypeName = request.OptionTypeName,
                Description = request.Description,
                Status = request.Status
            };
            return _ioptiontypeRepository.AddOptionType(optiontype);
        }

        public async Task<Boolean> UpdateOptionType(OptionTypeRequest request)
        {
            var optiontype = await _ioptiontypeRepository.GetOptionTypeById(request.OptionTypeId);
            optiontype.OptionTypeName = request.OptionTypeName;
            optiontype.Description = request.Description;
            optiontype.Status = request.Status;
            await _ioptiontypeRepository.UpdateOptionType(optiontype);
            return true;
        }

        public Task<Boolean> DeleteOptionType(int id)
        {
            return _ioptiontypeRepository.DeleteOptionType(id);
        }
    }
}
