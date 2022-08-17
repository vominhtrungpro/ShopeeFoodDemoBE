using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class ItemOptionService : IItemOptionService
    {
        private readonly IItemOptionRepository _itemoptionRepository;
        public ItemOptionService(IItemOptionRepository itemoptionRepository)
        {
            _itemoptionRepository = itemoptionRepository;
        }

        public async Task<List<DtoItemOption>> GetAllItemOption()
        {
            var dtoItemOption = new List<DtoItemOption>();
            var dbItemOption = await _itemoptionRepository.GetAllItemOption();
            dtoItemOption = dbItemOption.Select(c => new DtoItemOption
            {
                ItemOptionId = c.ItemOptionId,
                ProductId = c.ProductId,
                OptionId = c.OptionId,
            }).ToList();
            return dtoItemOption;
        }

        public async Task<DtoItemOption> GetItemOptionById(int id)
        {
            var dtoItemOption = new DtoItemOption();
            var dbItemOption = await _itemoptionRepository.GetItemOptionById(id);
            if (dbItemOption == null)
            {
                return await Task.FromResult<DtoItemOption>(null);
            }
            else
            {
                dtoItemOption.ItemOptionId = dbItemOption.ItemOptionId;
                dtoItemOption.ProductId = dbItemOption.ProductId;
                dtoItemOption.OptionId = dbItemOption.OptionId;
                return dtoItemOption;
            }
        }

        public async Task<ActionResponse> AddItemOption(ItemOptionRequest request)
        {
            var result = new ActionResponse();
            var itemoption = new ItemOption()
            {
                ItemOptionId = request.ItemOptionId,
                ProductId = request.ProductId,
                OptionId = request.OptionId
            };
            var addResult = await _itemoptionRepository.AddItemOption(itemoption);
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

        public async Task<ActionResponse> UpdateItemOption(ItemOptionRequest request)
        {
            var result = new ActionResponse();
            var dbItemoption = await _itemoptionRepository.GetItemOptionById(request.ItemOptionId);
            if (dbItemoption == null)
            {
                result.Success = false;
                result.Message = "ItemOption not found!";
                return result;
            }
            dbItemoption.ProductId = request.ProductId;
            dbItemoption.OptionId = request.OptionId;
            var updateResult = await _itemoptionRepository.UpdateItemOption(dbItemoption);
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

        public async Task<ActionResponse> DeleteItemOption(int id)
        {
            var result = new ActionResponse();
            var dbItemoption = await _itemoptionRepository.GetItemOptionById(id);
            if (dbItemoption == null)
            {
                result.Success = false;
                result.Message = "ItemOption not found!";
                return result;
            }
            var deleteResult = await _itemoptionRepository.DeleteItemOption(id);
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
    }
}
