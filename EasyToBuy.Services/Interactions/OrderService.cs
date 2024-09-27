using System.ComponentModel;
using System.Data;
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
                var isUserExists = await _dbContext.tblCustomer.Where(x => x.Id == customerId && x.IsActive == true).FirstOrDefaultAsync();

                if (isUserExists != null)
                {
                    var isDeliveryAddress = await _dbContext.tblCustomerAddress.Where(x => x.CustomerId == customerId && x.IsDeliveryAddress == true).FirstOrDefaultAsync();
                    if (isDeliveryAddress != null)
                    {
                        var orderList = (from c in _dbContext.tblCart
                                         join tpv in _dbContext.tblProductVariationAndRate
                                         on c.VariationId equals tpv.Id
                                         where c.CustomerId == customerId && c.IsPlaced == false && tpv.IsActive == true && tpv.IsDeleted == false

                                         select new OrderModel()
                                         {
                                             VariationId = c.VariationId,
                                             Quantity = c.Quantity,
                                             MRP = tpv.MRP,
                                             Discount = tpv.Discount,
                                             DiscountPrice = tpv.DiscountPrice,
                                             PriceAfterDiscount = tpv.PriceAfterDiscount,
                                         }).ToList();

                        if (orderList != null && orderList.Count > 0)
                        {
                            foreach (var order in orderList)
                            {
                                var customerOrderObj = new CustomerOrder();

                                var dbVariation = _dbContext.tblProductVariationAndRate.Where(x => x.Id == order.VariationId).FirstOrDefault();

                                if (dbVariation != null)
                                {
                                    dbVariation.StockQuantity = dbVariation.StockQuantity <= 0 ? 0 : order.StockQuantity - order.Quantity;
                                }

                                customerOrderObj.CustomerId = customerId;
                                customerOrderObj.OrderNumber = "ETB-" + new Random().Next().ToString();
                                customerOrderObj.OrderDate = DateTime.Now;
                                customerOrderObj.StatusId = 1;
                                customerOrderObj.VariationId = order.VariationId;
                                customerOrderObj.Quantity = order.Quantity;
                                customerOrderObj.MRP = order.MRP;
                                customerOrderObj.Discount = order.Discount;
                                customerOrderObj.DiscountPrice = order.DiscountPrice;
                                customerOrderObj.AmountToBePaid = order.Quantity * order.PriceAfterDiscount;

                                await _dbContext.AddAsync(customerOrderObj);
                                await _dbContext.SaveChangesAsync();

                                var customerOrderStatusLog = new CustomerOrderStatusLog();

                                customerOrderStatusLog.OrderId = customerOrderObj.Id;
                                customerOrderStatusLog.StatusId = 1;
                                customerOrderStatusLog.CreatedBy = customerId;
                                customerOrderStatusLog.CreatedOn = DateTime.Now;
                                await _dbContext.AddAsync(customerOrderStatusLog);

                                await _dbContext.SaveChangesAsync();

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
                    apiResponseModel.Message = "User does not exists.";
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
        public async Task<ApiResponseModel> CustomerOrderStatusUpdate(int userId, int orderId, int statusId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbUser = await _dbContext.tblUser.Where(x => x.Id == userId && x.IsActive == true).FirstOrDefaultAsync();

                if (dbUser != null)
                {
                    var dbOrder = await _dbContext.tblCustomerOrder.Include(x => x.OrderStatus).Where(x => x.Id == orderId).FirstOrDefaultAsync();
                    
                    if (dbOrder != null)
                    {
                        if (dbOrder.StatusId == statusId)
                        {
                            apiResponseModel.Status = false;
                            apiResponseModel.Message = "This order is already " + dbOrder.OrderStatus.Status.ToLower() + ".";
                        }
                        else
                        {
                            dbOrder.StatusId = statusId;
                            dbOrder.UpdatedBy = userId;
                            dbOrder.UpdatedOn = DateTime.Now;

                            var objCustomerOrderStatusLog = new CustomerOrderStatusLog();

                            objCustomerOrderStatusLog.OrderId = orderId;
                            objCustomerOrderStatusLog.StatusId = statusId;
                            objCustomerOrderStatusLog.CreatedBy = userId;
                            objCustomerOrderStatusLog.CreatedOn = DateTime.Now;

                            await _dbContext.tblCustomerOrderStatusLog.AddAsync(objCustomerOrderStatusLog);
                            await _dbContext.SaveChangesAsync();

                            apiResponseModel.Status = true;
                            apiResponseModel.Message = "Order status updated successfully.";
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
