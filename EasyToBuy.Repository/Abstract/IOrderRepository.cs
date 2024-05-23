using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IOrderRepository
    {
        Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList(int vendorId, int customerId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate);
        Task<ApiResponseModel> PlaceOrder(int userId);
        Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(int orderId);
    }
}
