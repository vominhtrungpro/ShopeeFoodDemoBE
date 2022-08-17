using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
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

        public async Task<List<DtoOptionType>> GetAllOptionType()
        {
            var dtoOptionType = new List<DtoOptionType>();
            var dbOptionType = await _optiontypeRepository.GetAllOptionType();
            dtoOptionType = dbOptionType.Select(c => new DtoOptionType
            {
                OptionTypeId = c.OptionTypeId,
                OptionTypeName = c.OptionTypeName,
                Description = c.Description,
                Status = c.Status
            }).ToList();
            return dtoOptionType;
        }

        public async Task<DtoOptionType> GetOptionTypeById(int id)
        {
            var dtoOptionType = new DtoOptionType();
            var dbOptionType = await _optiontypeRepository.GetOptionTypeById(id);
            if (dbOptionType == null)
            {
                return await Task.FromResult<DtoOptionType>(null);
            }
            else
            {
                dtoOptionType.OptionTypeId = dbOptionType.OptionTypeId;
                dtoOptionType.OptionTypeName = dbOptionType.OptionTypeName;
                dtoOptionType.Description = dbOptionType.Description;
                dtoOptionType.Status = dbOptionType.Status;
                return dtoOptionType;
            }
        }

        public async Task<ActionResponse> AddOptionType(OptionTypeRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var optiontype = new OptionType()
            {
                OptionTypeName = request.OptionTypeName,
                Description = request.Description,
                Status = request.Status
            };
            var addResult = await _optiontypeRepository.AddOptionType(optiontype);
            if (addResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Add failed!";
            }
            return result;
        }

        public async Task<ActionResponse> UpdateOptionType(OptionTypeRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbOptionType = await _optiontypeRepository.GetOptionTypeById(request.OptionTypeId);
            if (dbOptionType == null)
            {
                result.Success = false;
                result.Message = "OptionType not found!";
                return result;
            }
            dbOptionType.OptionTypeName = request.OptionTypeName;
            dbOptionType.Description = request.Description;
            dbOptionType.Status = request.Status;
            var updateResult = await _optiontypeRepository.UpdateOptionType(dbOptionType);
            if (updateResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Update failed!";
            }
            return result;
        }

        public async Task<ActionResponse> DeleteOptionType(int id)
        {
            var result = new ActionResponse();
            var dbOptionType = await _optiontypeRepository.GetOptionTypeById(id);
            if (dbOptionType == null)
            {
                result.Success = false;
                result.Message = "OptionType not found!";
                return result;
            }
            var deleteResult = await _optiontypeRepository.DeleteOptionType(id);
            if (deleteResult)
            {
                result.Success = true;
                result.Message = "Successful";
            }
            else
            {
                result.Success = false;
                result.Message = "Delete failed";
            }
            return result;
        }

        public async Task<List<DtoOptionType>> GetOptionTypeByProductId(int id)
        {
            var dtoOptionType = new List<DtoOptionType>();
            var dbOptionType = await _optiontypeRepository.GetOptionTypeByProductId(id);
            if (!dbOptionType.Any())
            {
                return await Task.FromResult<List<DtoOptionType>>(null);
            }
            else
            {
                dtoOptionType = dbOptionType.Select(c => new DtoOptionType
                {
                    OptionTypeId = c.OptionTypeId,
                    OptionTypeName = c.OptionTypeName,
                    Description = c.Description,
                    Status = c.Status,
                }).ToList();
                return dtoOptionType;
            }
        }

        public async Task<List<ProductOptionResponeDAL>> GetOptionTypeDetailByProductId(int id)
        {
            return await _optiontypeRepository.GetOptionTypeDetailByProductId(id);
        }
    }
}
