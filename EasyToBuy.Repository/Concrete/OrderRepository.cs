using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<ApiResponseModel> PlaceOrder(int userId)
        {
            using (OrderService orderService = new OrderService())
            {
                return await orderService.PlaceOrder(userId);
            }
        }

        public async Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList(int vendorId, int customerId, string? searchText, string? statusId)
        {
            using (OrderService orderService = new OrderService())
            {
                return await orderService.GetOrdersList(vendorId, customerId, searchText, statusId);
            }
        }
    }
}
