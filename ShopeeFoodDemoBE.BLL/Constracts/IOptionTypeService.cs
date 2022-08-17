using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Models.Respone;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface IOptionTypeService
    {
        Task<List<DtoOptionType>> GetAllOptionType();

        Task<DtoOptionType> GetOptionTypeById(int id);

        Task<ActionResponse> AddOptionType(OptionTypeRequest request);

        Task<ActionResponse> UpdateOptionType(OptionTypeRequest request);

        Task<ActionResponse> DeleteOptionType(int id);

        Task<List<DtoOptionType>> GetOptionTypeByProductId(int id);

        Task<List<ProductOptionResponeDAL>> GetOptionTypeDetailByProductId(int id);
    }
}
