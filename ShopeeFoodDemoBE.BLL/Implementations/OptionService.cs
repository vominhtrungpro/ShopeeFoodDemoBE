using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class OptionService : IOptionService
    {
        private readonly IOptionRepository _optionRepository;
        public OptionService(IOptionRepository optionRepository)
        {
            _optionRepository = optionRepository;
        }

        public async Task<List<DtoOption>> GetAllOption()
        {
            var dtoOption = new List<DtoOption>();
            var dbOption = await _optionRepository.GetAllOption();
            dtoOption = dbOption.Select(c => new DtoOption
            {
                OptionId = c.OptionId,
                OptionName = c.OptionName,
                Description = c.Description,
                Status = c.Status,
                OptionTypeId = c.OptionTypeId,
            }).ToList();
            return dtoOption;
        }

        public async Task<DtoOption> GetOptionById(int id)
        {
            var dtoOption = new DtoOption();
            var dbOption = await _optionRepository.GetOptionById(id);
            if (dbOption == null)
            {
                return await Task.FromResult<DtoOption>(null);
            }
            else
            {
                dtoOption.OptionId = dbOption.OptionId;
                dtoOption.OptionName = dbOption.OptionName;
                dtoOption.Description = dbOption.Description;
                dtoOption.Status = dbOption.Status;
                dtoOption.OptionTypeId = dbOption.OptionTypeId;
                return dtoOption;
            }
        }

        public async Task<ActionResponse> AddOption(OptionRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var option = new Option()
            {
                OptionName = request.OptionName,
                Description = request.Description,
                Status = request.Status,
                OptionTypeId = request.OptionTypeId
            };
            var addResult = await _optionRepository.AddOption(option);
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

        public async Task<ActionResponse> UpdateOption(OptionRequest request)
        {
            var result = new ActionResponse();
            if (request.Status != "Active")
            {
                result.Success = false;
                result.Message = "Status invalid!";
                return result;
            }
            var dbOption = await _optionRepository.GetOptionById(request.OptionId);
            if (dbOption == null)
            {
                result.Success = false;
                result.Message = "Option not found!";
                return result;
            }
            dbOption.OptionName = request.OptionName;
            dbOption.Description = request.Description;
            dbOption.Status = request.Status;
            dbOption.OptionTypeId = request.OptionTypeId;
            var updateResult = await _optionRepository.UpdateOption(dbOption);
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

        public async Task<ActionResponse> DeleteOption(int id)
        {
            var result = new ActionResponse();
            var dbOption = await _optionRepository.GetOptionById(id);
            if (dbOption == null)
            {
                result.Success = false;
                result.Message = "Option not found!";
                return result;
            }
            var deleteResult = await _optionRepository.DeleteOption(id);
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

        public async Task<List<DtoOption>> GetOptionByProductId(int id)
        {
            var dtoOption = new List<DtoOption>();
            var dbOption = await _optionRepository.GetOptionByProductId(id);
            if (!dbOption.Any())
            {
                return await Task.FromResult<List<DtoOption>>(null);
            }
            else
            {
                dtoOption = dbOption.Select(c => new DtoOption
                {
                    OptionId = c.OptionId,
                    OptionName = c.OptionName,
                    Description = c.Description,
                    Status = c.Status,
                    OptionTypeId = c.OptionTypeId

                }).ToList();
                return dtoOption;
            }
        }
    }
}
