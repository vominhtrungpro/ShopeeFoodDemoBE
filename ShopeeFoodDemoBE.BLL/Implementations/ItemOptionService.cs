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
        private readonly IItemOptionRepository _iitemoptionRepository;
        public ItemOptionService(IItemOptionRepository iitemoptionRepository)
        {
            _iitemoptionRepository = iitemoptionRepository;
        }

        public Task<List<ItemOption>> GetAllItemOption()
        {
            return _iitemoptionRepository.GetAllItemOption();
        }

        public Task<ItemOption> GetItemOptionById(int id)
        {
            return _iitemoptionRepository.GetItemOptionById(id);
        }

        public Task<Boolean> AddItemOption(ItemOptionRequest request)
        {
            var itemoption = new ItemOption()
            {
                ProductId = request.ProductId,
                OptionId = request.OptionId
            };
            return _iitemoptionRepository.AddItemOption(itemoption);
        }

        public async Task<Boolean> UpdateItemOption(ItemOptionRequest request)
        {
            var itemoption = await _iitemoptionRepository.GetItemOptionById(request.ItemOptionId);
            itemoption.ProductId = request.ProductId;
            itemoption.OptionId = request.OptionId;
            await _iitemoptionRepository.UpdateItemOption(itemoption);
            return true;
        }

        public Task<Boolean> DeleteItemOption(int id)
        {
            return _iitemoptionRepository.DeleteItemOption(id);
        }
    }
}
