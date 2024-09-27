using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IOrderRepository
    {
        Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList( int customerId, int userId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate);
        Task<ApiResponseModel> PlaceOrder(int CustomerId);
        Task<IEnumerable<SPGetUserOrdersListByUserId_Result>> GetUserOrdersListByUserId(int userId, string? searchText, int statusId);
        Task<IEnumerable<SPGetProductDetailsByOrderNumberAndUserId_Result>> GetProductDetailsByOrderNumberAndUserId(string orderNumber, int userId);
        Task<ApiResponseModel> CustomerOrderStatusUpdate(int userId, string orderNumber, int statusId);
        Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(int orderId);
    }
}
