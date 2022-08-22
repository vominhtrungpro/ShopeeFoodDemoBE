using ShopeeFoodDemoBE.BLL.Constracts;
using ShopeeFoodDemoBE.BLL.Models.Dto;
using ShopeeFoodDemoBE.BLL.Models.Requests;
using ShopeeFoodDemoBE.BLL.Models.Responses;
using ShopeeFoodDemoBE.DAL.EF.Entities;
using ShopeeFoodDemoBE.DAL.Repos.Constracts;

namespace ShopeeFoodDemoBE.BLL.Implementations
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderdetailRepository;
        public OrderDetailService(IOrderDetailRepository orderdetailRepository)
        {
            _orderdetailRepository = orderdetailRepository;
        }

        public async Task<List<DtoOrderDetail>> GetAllOrderDetail()
        {
            var dtoOrderDetail = new List<DtoOrderDetail>();
            var dbOrderDetail = await _orderdetailRepository.GetAllOrderDetail();
            dtoOrderDetail = dbOrderDetail.Select(c => new DtoOrderDetail
            {
                OrderDetailId = c.OrderDetailId,
                OrderId = c.OrderId,
                ProductId = c.ProductId,
                Amount = c.Amount,
                Price = c.Price
            }).ToList();
            return dtoOrderDetail;
        }

        public async Task<DtoOrderDetail> GetOrderDetailById(int id)
        {
            var dtoOrderDetail = new DtoOrderDetail();
            var dbOrderDetail = await _orderdetailRepository.GetOrderDetailById(id);
            if (dbOrderDetail == null)
            {
                return await Task.FromResult<DtoOrderDetail>(null);
            }
            else
            {
                dtoOrderDetail.OrderDetailId = dbOrderDetail.OrderDetailId;
                dtoOrderDetail.OrderId = dbOrderDetail.OrderId;
                dtoOrderDetail.ProductId = dbOrderDetail.ProductId;
                dtoOrderDetail.Amount = dbOrderDetail.Amount;
                dtoOrderDetail.Price = dbOrderDetail.Price;
                return dtoOrderDetail;
            }
        }

        public async Task<ActionResponse> AddOrderDetail(OrderDetailRequest request)
        {
            var result = new ActionResponse();
            var orderdetail = new OrderDetail()
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Amount = request.Amount,
                Price = request.Price
            };
            var addResult = await _orderdetailRepository.AddOrderDetail(orderdetail);
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

        public async Task<ActionResponse> UpdateOrderDetail(OrderDetailRequest request)
        {
            var result = new ActionResponse();
            var dbOrderDetail = await _orderdetailRepository.GetOrderDetailById(request.OrderDetailId);
            if (dbOrderDetail == null)
            {
                result.Success = false;
                result.Message = "OptionType not found!";
                return result;
            }
            dbOrderDetail.OrderId = request.OrderId;
            dbOrderDetail.ProductId = request.ProductId;
            dbOrderDetail.Amount = request.Amount;
            dbOrderDetail.Price = request.Price;
            var updateResult = await _orderdetailRepository.UpdateOrderDetail(dbOrderDetail);
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

        public async Task<ActionResponse> DeleteOrderDetail(int id)
        {
            var result = new ActionResponse();
            var dbOrderDetail = await _orderdetailRepository.GetOrderDetailById(id);
            if (dbOrderDetail == null)
            {
                result.Success = false;
                result.Message = "OptionType not found!";
                return result;
            }
            var deleteResult = await _orderdetailRepository.DeleteOrderDetail(id);
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
