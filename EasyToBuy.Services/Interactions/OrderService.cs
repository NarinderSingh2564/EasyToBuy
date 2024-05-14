﻿using System.ComponentModel;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.Models;
using Microsoft.EntityFrameworkCore;

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
                    var orderList = (from c in _dbContext.tblCart
                                     join p in _dbContext.tblProduct
                                     on c.ProductId equals p.Id
                                     where c.UserId == userId && c.IsPlaced == false

                                 select new OrderModel()
                                 {
                                    UserId = userId,
                                    ProductId = c.ProductId,
                                    Quantity = c.Quantity,
                                    MRP = p.MRP,
                                    Discount = p.Discount,
                                    DiscountPrice = p.DiscountPrice,
                                    PriceAfterDiscount = p.PriceAfterDiscount,
                                 }).ToList();

                    if (orderList != null && orderList.Count > 0)
                    {
                        var orderObj = new Order();

                        orderObj.UserId = userId;
                        orderObj.OrderNumber = "ETB" + new Random().Next().ToString();
                       
                        orderObj.OrderDate = DateTime.Now;
                        orderObj.StatusId = 1;

                        await _dbContext.AddAsync(orderObj);


                        foreach (var order in orderList)
                        {
                            var orderDetailObj = new Order();

                            orderDetailObj.OrderNumber = orderObj.OrderNumber;
                            orderDetailObj.ProductId = order.ProductId;
                            orderDetailObj.Quantity = order.Quantity;
                            orderDetailObj.MRP = order.MRP;
                            orderDetailObj.Discount = order.Discount;
                            orderDetailObj.DiscountPrice = order.DiscountPrice;
                            orderDetailObj.AmountToBePaid = order.Quantity * order.PriceAfterDiscount;

                            await _dbContext.AddAsync(orderDetailObj);

                        }

                        await _dbContext.SaveChangesAsync();

                        var objCart = await _dbContext.tblCart.Where(x=>x.UserId == userId && x.IsPlaced == false).ToListAsync();

                        foreach(var item in objCart)
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
                    apiResponseModel.Message = "User does not exists.";
                }


            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
    }
}
