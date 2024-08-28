using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IOrderRepository
    {
        Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList( int customerId, int userId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate);
        Task<ApiResponseModel> PlaceOrder(int CustomerId);
        Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(int orderId);
    }
}
