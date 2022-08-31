using Microsoft.EntityFrameworkCore;
using ShopeeFoodDemoBE.DAL.EF.Data;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Models.Respone;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.DAL.Repos.Implementations
{
    public class OptionTypeRepository : IOptionTypeRepository
    {
        private readonly DataContext _dataContext;
        public OptionTypeRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<OptionType>> GetAllOptionType()
        {
            return await _dataContext.OptionType.ToListAsync();
        }

        public async Task<OptionType> GetOptionTypeById(int id)
        {
            return await _dataContext.OptionType.FindAsync(id);
        }

        public async Task<Boolean> AddOptionType(OptionType optiontype)
        {
            _dataContext.OptionType.Add(optiontype);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> UpdateOptionType(OptionType optiontype)
        {
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<Boolean> DeleteOptionType(int id)
        {
            var optiontype = await GetOptionTypeById(id);
            _dataContext.OptionType.Remove(optiontype);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<OptionType>> GetOptionTypeByProductId(int id)
        {
            var query = from p in _dataContext.Product
                        join i in _dataContext.ItemOption on p.ProductId equals i.ProductId
                        join o in _dataContext.Option on i.OptionId equals o.OptionId
                        join t in _dataContext.OptionType on o.OptionTypeId equals t.OptionTypeId
                        where p.ProductId == id
                        select new { t };

            return await query.Select(x => new OptionType()
            {
                OptionTypeId = x.t.OptionTypeId,
                OptionTypeName = x.t.OptionTypeName,
                Description = x.t.Description,
                Status = x.t.Status
            }).ToListAsync();
        }

        public async Task<List<ProductOptionResponeDAL>> GetOptionTypeDetailByProductId(int id)
        {
            var query = from p in _dataContext.Product
                        join i in _dataContext.ItemOption on p.ProductId equals i.ProductId
                        join o in _dataContext.Option on i.OptionId equals o.OptionId
                        join t in _dataContext.OptionType on o.OptionTypeId equals t.OptionTypeId
                        where p.ProductId == id
                        select new { o,t };

            return await query.Select(x => new ProductOptionResponeDAL()
            {
                OptionId = x.o.OptionId,
                OptionName = x.o.OptionName,
                OptionTypeId = x.t.OptionTypeId,
                OptionTypeName = x.t.OptionTypeName
            }).ToListAsync();
        }
    }
}
