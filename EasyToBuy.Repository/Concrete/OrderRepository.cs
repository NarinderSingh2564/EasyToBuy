using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class OrderRepository : IOrderRepository
    {
        public async Task<ApiResponseModel> PlaceOrder(int cutomerId)
        {
            using (OrderService orderService = new OrderService())
            {
                return await orderService.PlaceOrder(cutomerId);
            }
        }

        public async Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList( int customerId, int userId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate)
        {
            using (OrderService orderService = new OrderService())
            {
                return await orderService.GetOrdersList(customerId, userId, searchText, statusId, firstDate, secondDate);
            }
        }
        public async Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(int orderId)
        {
            using (OrderService orderService = new OrderService())
            {
                return await orderService.GetOrderStatusTrackingList(orderId);
            }
        }
    }
}
