using System.ComponentModel;
using System.Data;
using System.Linq;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.Migrations;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace EasyToBuy.Services.Interactions
{
    public class OrderService : IDisposable
    {

        #region Private Variables

        private ApplicationDbContext _dbContext;

        private Component component = new Component();
        private bool disposed = false;
        private IntPtr handle;

        private void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                    component.Dispose();
                CloseHandle(handle);
                handle = IntPtr.Zero;
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        [System.Runtime.InteropServices.DllImport("Kernel32")]
        private extern static Boolean CloseHandle(IntPtr handle);

        #endregion

        #region Constructor

        public OrderService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~OrderService()
        {
            Dispose(false);
        }

        #endregion

        public async Task<ApiResponseModel> PlaceOrder(int customerId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbCustomer = await _dbContext.tblCustomer.Where(x => x.Id == customerId).FirstOrDefaultAsync();

                if (dbCustomer != null)
                {
                    if (dbCustomer.IsActive)
                    {
                        var isDeliveryAddress = await _dbContext.tblCustomerAddress.Where(x => x.CustomerId == customerId && x.IsDeliveryAddress == true).FirstOrDefaultAsync();

                        if (isDeliveryAddress != null)
                        {
                            var orderList = (from tc in _dbContext.tblCart
                                             join tpv in _dbContext.tblProductVariationAndRate on tc.VariationId equals tpv.Id
                                             join tp in _dbContext.tblProduct on tpv.ProductId equals tp.Id
                                             where tc.CustomerId == customerId && tc.IsPlaced == false && tpv.IsActive == true && tpv.IsDeleted == false

                                             select new OrderModel()
                                             {
                                                 VariationId = tc.VariationId,
                                                 VendorId = tp.UserId,
                                                 Quantity = tc.Quantity,
                                                 MRP = tpv.MRP,
                                                 Discount = tpv.Discount,
                                                 DiscountPrice = tpv.DiscountPrice,
                                                 PriceAfterDiscount = tpv.PriceAfterDiscount,
                                             }).ToList();

                            if (orderList != null && orderList.Count > 0)
                            {
                                var maxOrderNumber = _dbContext.tblCustomerOrder.ToList().Max(x => x.OrderNumber);

                                foreach (var order in orderList.Select((item,i)=> new {item,i}) )
                                {
                                    var customerOrderObj = new CustomerOrder();

                                    var dbVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == order.item.VariationId).FirstOrDefaultAsync();

                                    if (dbVariation != null)
                                    {
                                        dbVariation.StockQuantity = dbVariation.StockQuantity - order.item.Quantity;
                                    }

                                    customerOrderObj.CustomerId = customerId;
                                    customerOrderObj.VendorId = order.item.VendorId;
                                    customerOrderObj.OrderNumber = maxOrderNumber == null ? "ETB-10000" : "ETB-" + (Convert.ToUInt16(maxOrderNumber.Substring(4)) + 1).ToString();
                                    customerOrderObj.OrderDate = (DateTime.Now).Date;
                                    customerOrderObj.StatusId = 1;
                                    customerOrderObj.VariationId = order.item.VariationId;
                                    customerOrderObj.Quantity = order.item.Quantity;
                                    customerOrderObj.MRP = order.item.MRP;
                                    customerOrderObj.Discount = order.item.Discount;
                                    customerOrderObj.DiscountPrice = order.item.DiscountPrice;
                                    customerOrderObj.AmountToBePaid = order.item.Quantity * order.item.PriceAfterDiscount;

                                    await _dbContext.AddAsync(customerOrderObj);

                                    if (order.i == 0)
                                    {
                                        var customerOrderStatusLog = new CustomerOrderStatusLog();

                                        customerOrderStatusLog.OrderNumber = customerOrderObj.OrderNumber;
                                        customerOrderStatusLog.VendorId = order.item.VendorId;
                                        customerOrderStatusLog.StatusId = 1;
                                        customerOrderStatusLog.CreatedBy = customerId;
                                        customerOrderStatusLog.CreatedOn = DateTime.Now;

                                        await _dbContext.AddAsync(customerOrderStatusLog);
                                    }
                                }

                                var objCart = await _dbContext.tblCart.Where(x => x.CustomerId == customerId && x.IsPlaced == false).ToListAsync();

                                foreach (var item in objCart)
                                {
                                    item.IsPlaced = true;
                                }

                                await _dbContext.SaveChangesAsync();

                                apiResponseModel.Status = true;
                                apiResponseModel.Message = "Order placed successfully.";
                            }
                            else
                            {
                                apiResponseModel.Status = false;
                                apiResponseModel.Message = "Kindly add products to cart to place order.";
                            }
                        }
                        else
                        {
                            apiResponseModel.Status = false;
                            apiResponseModel.Message = "Kindly set your delivery address to place order.";
                        }
                    }
                    else
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Customer is not active.";
                    }
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "Customer does not exists.";
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList(int customerId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate)
        {
            var orderList = new List<SPGetOrderList_Result>();

            try
            {
                var sqlQuery = "exec spGetOrderList @CustomerId,@SearchText,@StatusId,@FirstDate,@SecondDate";

                SqlParameter parameter1 = new SqlParameter("@CustomerId", customerId < 1 ? DBNull.Value : customerId);
                SqlParameter parameter3 = new SqlParameter("@SearchText", string.IsNullOrEmpty(searchText) ? DBNull.Value : searchText);
                SqlParameter parameter4 = new SqlParameter("@StatusId", statusId == "0" ? DBNull.Value : statusId);
                SqlParameter parameter5 = new SqlParameter("@FirstDate", firstDate == null ? DBNull.Value : firstDate);
                SqlParameter parameter6 = new SqlParameter("@SecondDate", secondDate == null ? DBNull.Value : secondDate);

                orderList = await _dbContext.orderList_Results.FromSqlRaw(sqlQuery, parameter1, parameter3, parameter4, parameter5, parameter6).ToListAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return orderList;
        }
        public async Task<IEnumerable<SPGetUserOrdersListByUserId_Result>> GetUserOrdersListByUserId(int userId, string? searchText, int statusId)
        {
            var orderList = new List<SPGetUserOrdersListByUserId_Result>();

            try
            {
                var sqlQuery = "exec spGetUserOrdersListByUserId @UserId,@SearchText,@StatusId";

                SqlParameter parameter1 = new SqlParameter("@UserId", userId == 0 ? DBNull.Value : userId);
                SqlParameter parameter2 = new SqlParameter("@SearchText", string.IsNullOrEmpty(searchText) ? DBNull.Value : searchText);
                SqlParameter parameter3 = new SqlParameter("@StatusId", statusId == 0 ? DBNull.Value : statusId);

                orderList = await _dbContext.userOrdersListByUserId_Result.FromSqlRaw(sqlQuery, parameter1, parameter2, parameter3).ToListAsync();
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return orderList;
        }
        public async Task<IEnumerable<SPGetProductDetailsByOrderNumberAndUserId_Result>> GetProductDetailsByOrderNumberAndUserId(string orderNumber, int userId)
        {
            var productDetails = new List<SPGetProductDetailsByOrderNumberAndUserId_Result>();

            try
            {
                var sqlQuery = "exec spGetProductDetailsByOrderNumberAndUserId @OrderNumber,@UserId";

                SqlParameter parameter1 = new SqlParameter("@OrderNumber", string.IsNullOrEmpty(orderNumber) ? DBNull.Value : orderNumber);
                SqlParameter parameter2 = new SqlParameter("@UserId", userId == 0 ? DBNull.Value : userId);

                productDetails = await _dbContext.productDetailsByOrderNumberAndUserId_Result.FromSqlRaw(sqlQuery, parameter1, parameter2).ToListAsync();
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productDetails;
        }
        public async Task<ApiResponseModel> CustomerOrderStatusUpdate(int userId, string orderNumber, int statusId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbUser = await _dbContext.tblUser.Where(x => x.Id == userId && x.IsActive == true).FirstOrDefaultAsync();

                if (dbUser != null)
                {
                    var dbOrdersList = await _dbContext.tblCustomerOrder.Include(x => x.OrderStatus).Where(x => x.OrderNumber == orderNumber && x.VendorId == userId).ToListAsync();

                    if (dbOrdersList.Count > 0)
                    {
                        foreach (var order in dbOrdersList.Select((item,index)=>(item,index)))
                        {
                            if (order.item.StatusId == statusId)
                            {
                                apiResponseModel.Status = false;
                                apiResponseModel.Message = "This order is already " + order.item.OrderStatus.Status.ToLower() + ".";
                            }
                            else
                            {
                                order.item.StatusId = statusId;
                                order.item.UpdatedBy = userId;
                                order.item.UpdatedOn = DateTime.Now;

                                if (order.index == 0)
                                {
                                    var objCustomerOrderStatusLog = new CustomerOrderStatusLog();

                                    objCustomerOrderStatusLog.OrderNumber = orderNumber;
                                    objCustomerOrderStatusLog.VendorId = order.item.VendorId;
                                    objCustomerOrderStatusLog.StatusId = statusId;
                                    objCustomerOrderStatusLog.CreatedBy = userId;
                                    objCustomerOrderStatusLog.CreatedOn = DateTime.Now;

                                    await _dbContext.tblCustomerOrderStatusLog.AddAsync(objCustomerOrderStatusLog);
                                }
                                await _dbContext.SaveChangesAsync();

                                apiResponseModel.Status = true;
                                apiResponseModel.Message = "Order status updated successfully.";
                            }
                        }
                    }
                    else
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Order not found.";
                    }
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "Sorry, you can not update order status as you are not an active user.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(string orderId)
        {
            var orderStatusTrackingList = new List<SPGetTrackingStatusListByOrderId_Result>();

            try
            {
                var sqlQuery = "exec spGetTrackingStatusListByOrderId @OrderId";

                SqlParameter parameter1 = new SqlParameter("@OrderId", orderId);

                orderStatusTrackingList = await _dbContext.getTrackingStatusListByOrderId_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return orderStatusTrackingList;
        }
    }
}
