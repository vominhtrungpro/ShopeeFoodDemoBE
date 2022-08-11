using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Models.Respone;
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
        private readonly IOptionTypeRepository _optiontypeRepository;
        public OptionTypeService(IOptionTypeRepository optiontypeRepository)
        {
            _optiontypeRepository = optiontypeRepository;
        }

        public Task<List<OptionType>> GetAllOptionType()
        {
            return _optiontypeRepository.GetAllOptionType();
        }

        public Task<OptionType> GetOptionTypeById(int id)
        {
            return _optiontypeRepository.GetOptionTypeById(id);
        }

        public Task<Boolean> AddOptionType(OptionTypeRequest request)
        {
            var optiontype = new OptionType()
            {
                OptionTypeName = request.OptionTypeName,
                Description = request.Description,
                Status = request.Status
            };
            return _optiontypeRepository.AddOptionType(optiontype);
        }

        public async Task<Boolean> UpdateOptionType(OptionTypeRequest request)
        {
            var optiontype = await _optiontypeRepository.GetOptionTypeById(request.OptionTypeId);
            optiontype.OptionTypeName = request.OptionTypeName;
            optiontype.Description = request.Description;
            optiontype.Status = request.Status;
            await _optiontypeRepository.UpdateOptionType(optiontype);
            return true;
        }

        public Task<Boolean> DeleteOptionType(int id)
        {
            return _optiontypeRepository.DeleteOptionType(id);
        }

        public async Task<List<OptionType>> GetOptionTypeByProductId(int id)
        {
            return await _optiontypeRepository.GetOptionTypeByProductId(id);
        }

        public async Task<List<ProductOptionResponeDAL>> GetOptionTypeDetailByProductId(int id)
        {
            return await _optiontypeRepository.GetOptionTypeDetailByProductId(id);
        }
    }
}
