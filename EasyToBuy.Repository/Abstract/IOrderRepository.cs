using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IOrderRepository
    {
        Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList( int customerId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate);
        Task<ApiResponseModel> PlaceOrder(int CustomerId);
        Task<ApiResponseModel> CustomerOrderStatusUpdate(int userId, int orderId, int statusId);
        Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(string orderId);
    }
}
