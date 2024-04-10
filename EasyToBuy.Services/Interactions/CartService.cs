using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.SPResults;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EasyToBuy.Services.Interactions
{
    public class CartService : IDisposable
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

        public CartService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~CartService()
        {
            Dispose(false);
        }

        #endregion

        public async Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                var isProductExists = await _dbContext.tblCart.Where(x => x.ProductId == cartInputModel.ProductId && x.CustomerId == cartInputModel.CustomerId).FirstOrDefaultAsync();
                if (isProductExists != null)
                {
                    isProductExists.Quantity += cartInputModel.Quantity;
                }
                else
                {
                    var cartObj = new Cart();

                    cartObj.CustomerId = cartInputModel.CustomerId;
                    cartObj.ProductId = cartInputModel.ProductId;
                    cartObj.Quantity = cartInputModel.Quantity;
                    cartObj.AddedDate = DateTime.Now;

                    await _dbContext.AddAsync(cartObj);
                }
                await _dbContext.SaveChangesAsync();

                apiResponseModel.Status = true;
                apiResponseModel.Message = "Product added to cart successfully.";
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
        public async Task<GetCartDetailsByCustomerId> GetCartDetailsByCustomerId(int customerId)
        {
            var cartListByCustomerId = new GetCartDetailsByCustomerId();

            try
            {
                var sqlQuery = "exec spGetCartDetailsByCustomerId @CustomerId";

                SqlParameter parameter = new SqlParameter("@CustomerId", customerId); 

                cartListByCustomerId._cartListItems = await _dbContext.cartDetailsByCustomerId_Results.FromSqlRaw(sqlQuery, parameter).ToListAsync();


                cartListByCustomerId.priceDetails.TotalProductPrice = cartListByCustomerId._cartListItems.Sum(x => x.ProductPrice);
                cartListByCustomerId.priceDetails.TotalDiscountPrice = cartListByCustomerId._cartListItems.Sum(x =>x.ProductDiscountPrice);
                cartListByCustomerId.priceDetails.TotalCartPrice = cartListByCustomerId._cartListItems.Sum(x => x.ProductPriceAfterDiscount);

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return cartListByCustomerId;
        }
        public async Task<ApiResponseModel> RemoveProductFromCart(int id)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                var cartObj = await _dbContext.tblCart.Where(x => x.Id == id).FirstOrDefaultAsync();
                if (cartObj != null)
                {
                    _dbContext.tblCart.Remove(cartObj);
                    await _dbContext.SaveChangesAsync();
                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Product removed from cart successfully.";
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
