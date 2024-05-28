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

        public async Task<ApiResponseModel> PlaceOrder(int userId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var isUserExists = await _dbContext.tblUser.Where(x => x.Id == userId && x.IsActive == true).FirstOrDefaultAsync();

                if (isUserExists != null)
                {
                    var isDeliveryAddress = await _dbContext.tblAddress.Where(x => x.UserId == userId && x.IsDeliveryAddress == true).FirstOrDefaultAsync();

                    if (isDeliveryAddress != null)
                    {
                        var orderList = (from c in _dbContext.tblCart
                                         join p in _dbContext.tblProduct
                                         on c.ProductId equals p.Id
                                         where c.UserId == userId && c.IsPlaced == false

                                         select new OrderModel()
                                         {
                                             ProductId = c.ProductId,
                                             Quantity = c.Quantity,
                                             MRP = p.MRP,
                                             Discount = p.Discount,
                                             DiscountPrice = p.DiscountPrice,
                                             PriceAfterDiscount = p.PriceAfterDiscount,
                                         }).ToList();

                        if (orderList != null && orderList.Count > 0)
                        {

                            foreach (var order in orderList)
                            {
                            var customerOrderObj = new CustomerOrder();

                                customerOrderObj.UserId = userId;
                                customerOrderObj.OrderNumber = "ETB-" + new Random().Next().ToString();
                                customerOrderObj.OrderDate = DateTime.Now;
                                customerOrderObj.StatusId = 1;
                                customerOrderObj.ProductId = order.ProductId;
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
                                customerOrderStatusLog.CreatedBy = userId;
                                customerOrderStatusLog.CreatedOn = DateTime.Now;
                                await _dbContext.AddAsync(customerOrderStatusLog);

                                await _dbContext.SaveChangesAsync();

                            }


                            var objCart = await _dbContext.tblCart.Where(x => x.UserId == userId && x.IsPlaced == false).ToListAsync();

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
        public async Task<IEnumerable<SPGetOrderList_Result>> GetOrdersList(int vendorId, int customerId, string? searchText, string? statusId, DateTime? firstDate, DateTime? secondDate)
        {
            var orderList = new List<SPGetOrderList_Result>();

            try
            {
                var sqlQuery = "exec spGetOrderList @CustomerId,@VendorId,@SearchText,@StatusId,@FirstDate,@SecondDate";

                SqlParameter parameter1 = new SqlParameter("@CustomerId", customerId < 1 ? DBNull.Value : customerId);
                SqlParameter parameter2 = new SqlParameter("@VendorId", vendorId < 1 ? DBNull.Value : vendorId);
                SqlParameter parameter3 = new SqlParameter("@SearchText", string.IsNullOrEmpty(searchText) ? DBNull.Value : searchText);
                SqlParameter parameter4 = new SqlParameter("@StatusId", statusId == "0" ? DBNull.Value : statusId); 
                SqlParameter parameter5 = new SqlParameter("@FirstDate", firstDate == null ? DBNull.Value : firstDate);
                SqlParameter parameter6 = new SqlParameter("@SecondDate", secondDate == null ? DBNull.Value : secondDate);

                orderList = await _dbContext.orderList_Results.FromSqlRaw(sqlQuery, parameter1, parameter2, parameter3, parameter4, parameter5, parameter6).ToListAsync();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return orderList;
        }
        public async Task<IEnumerable<SPGetTrackingStatusListByOrderId_Result>> GetOrderStatusTrackingList(int orderId)
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
