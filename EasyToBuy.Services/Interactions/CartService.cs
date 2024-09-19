using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

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
                if (cartInputModel.RequestFrom == "Cart")
                {
                    var isProductExists = await _dbContext.tblCart.Where(x => x.VariationId == cartInputModel.VariationId && x.CustomerId == cartInputModel.CustomerId && x.IsPlaced == false).FirstOrDefaultAsync();
                    if (isProductExists != null)
                    {
                        isProductExists.Quantity = cartInputModel.Quantity;

                        await _dbContext.SaveChangesAsync();
                        apiResponseModel.Status = true;
                        apiResponseModel.Message = "Quantity is successfully updated.";
                    }
                    else

                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "This product does not exist in cart.";
                    }
                }
                else
                {
                    var checkStockQuantity = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == cartInputModel.VariationId).Select(x => x.StockQuantity).FirstOrDefaultAsync();
                    if (checkStockQuantity == 0)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "This product is out of stock.";
                    }
                    else
                    {
                        var isProductExists = await _dbContext.tblCart.Where(x => x.VariationId == cartInputModel.VariationId && x.CustomerId == cartInputModel.CustomerId && x.IsPlaced == false).FirstOrDefaultAsync();
                        if (isProductExists != null)
                        {
                            apiResponseModel.Status = false;
                            apiResponseModel.Message = "This product already exists in your cart.";
                        }
                        else
                        {
                            var cartObj = new Cart();

                            cartObj.CustomerId = cartInputModel.CustomerId;
                            cartObj.VariationId = cartInputModel.VariationId;
                            cartObj.Quantity = cartInputModel.Quantity;
                            cartObj.AddedDate = DateTime.Now;
                            cartObj.IsPlaced = false;

                            await _dbContext.AddAsync(cartObj);
                            await _dbContext.SaveChangesAsync();

                            apiResponseModel.Status = true;
                            apiResponseModel.Message = "Product added to cart successfully.";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                apiResponseModel.Status = false;
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

                cartListByCustomerId.priceDetails.TotalProductPrice = cartListByCustomerId._cartListItems.Sum(x => x.MRP);
                cartListByCustomerId.priceDetails.TotalDiscountPrice = cartListByCustomerId._cartListItems.Sum(x => x.DiscountPrice);
                cartListByCustomerId.priceDetails.TotalCartPrice = cartListByCustomerId._cartListItems.Sum(x => x.TotalProductPrice);

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return cartListByCustomerId;
        }
        public async Task<ApiResponseModel> RemoveProductFromCart(int cartId)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                var cartObj = await _dbContext.tblCart.Where(x => x.Id == cartId).FirstOrDefaultAsync();
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
        public async Task<ApiResponseModel> CheckProductInCart(int variationId, int customerId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var isProductExist = await _dbContext.tblCart.Where(x => x.VariationId == variationId && x.CustomerId == customerId && x.IsPlaced == false).FirstOrDefaultAsync();
                var isDefault = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == variationId).Select(x => x.SetAsDefault).FirstOrDefaultAsync();

                if (isProductExist != null && isDefault == false)
                {
                    apiResponseModel.Status = true;
                }
                else
                {
                    apiResponseModel.Status = false;
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
