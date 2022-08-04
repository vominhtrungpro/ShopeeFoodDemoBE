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
    public class ItemOptionService : IItemOptionService
    {
        private readonly IItemOptionRepository _itemoptionRepository;
        public ItemOptionService(IItemOptionRepository itemoptionRepository)
        {
            _itemoptionRepository = itemoptionRepository;
        }

        public Task<List<ItemOption>> GetAllItemOption()
        {
            return _itemoptionRepository.GetAllItemOption();
        }

        public Task<ItemOption> GetItemOptionById(int id)
        {
            return _itemoptionRepository.GetItemOptionById(id);
        }

        public Task<Boolean> AddItemOption(ItemOptionRequest request)
        {
            var itemoption = new ItemOption()
            {
                ProductId = request.ProductId,
                OptionId = request.OptionId
            };
            return _itemoptionRepository.AddItemOption(itemoption);
        }

        public async Task<Boolean> UpdateItemOption(ItemOptionRequest request)
        {
            var itemoption = await _itemoptionRepository.GetItemOptionById(request.ItemOptionId);
            itemoption.ProductId = request.ProductId;
            itemoption.OptionId = request.OptionId;
            await _itemoptionRepository.UpdateItemOption(itemoption);
            return true;
        }

        public Task<Boolean> DeleteItemOption(int id)
        {
            return _itemoptionRepository.DeleteItemOption(id);
        }
    }
}
