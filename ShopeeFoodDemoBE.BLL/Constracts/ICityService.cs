using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopeeFoodDemoBE.BLL.Constracts
{
    public interface ICityService
    {
        Task<List<DtoCity>> GetAllCity();

        Task<DtoCity> GetCityById(int id);

        Task<ActionResponse> AddCity(CityRequest request);

        Task<ActionResponse> UpdateCity(CityRequest request);

        Task<ActionResponse> DeleteCity(int id);
    }
}
