using System.ComponentModel;
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
    public class ProductService : IDisposable
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

        public ProductService()
        {
            _dbContext = new ApplicationDbContext();
        }

        #endregion

        #region Destructor

        ~ProductService()
        {
            Dispose(false);
        }

        #endregion

        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var productList = new List<ProductModel>();

            try
            {
                var dbProductList = await _dbContext.tblProduct.ToListAsync();
                foreach (var product in dbProductList)
                {
                    productList.Add(new ProductModel()
                    {

                        Id = product.Id,
                        ProductSku = product.ProductSku,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductDiscount = product.ProductDiscount,
                        ProductPriceAfterDiscount = product.ProductPriceAfterDiscount,
                        ProductShortName = product.ProductShortName,
                        ProductDescription = product.ProductDescription,
                        ProductImageUrl = product.ProductImageUrl,
                        ProductTimeSpan = product.ProductTimeSpan,
                        CategoryId = product.CategoryId,
                        IsActive = product.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productList;
        }
        public async Task<IEnumerable<SPGetProductDetails_Result>> GetProductDetails(int categoryId)
        {
            var productDetails = new List<SPGetProductDetails_Result>();

            try
            {
                if (categoryId == 0)
                {
                    var sqlQuery = "exec spGetProductDetails @CategoryId";
                    SqlParameter parameter = new SqlParameter("@CategoryId", DBNull.Value);
                    productDetails = await _dbContext.productDetails_Results.FromSqlRaw(sqlQuery, parameter).ToListAsync();

                }
                else
                {
                    var sqlQuery = "exec spGetProductDetails @CategoryId";
                    SqlParameter parameter = new SqlParameter("@CategoryId", categoryId);
                    productDetails = await _dbContext.productDetails_Results.FromSqlRaw(sqlQuery, parameter).ToListAsync();
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productDetails;
        }
        public async Task<IEnumerable<ProductModel>> GetProductById(int Id)
        {
            var productById = new List<ProductModel>();

            try
            {
                var dbProductById = await _dbContext.tblProduct.Where(x => x.Id == Id).ToListAsync();
                foreach (var product in dbProductById)
                {
                    productById.Add(new ProductModel
                    {

                        Id = product.Id,
                        ProductSku = product.ProductSku,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
                        ProductDiscount = product.ProductDiscount,
                        ProductPriceAfterDiscount = product.ProductPriceAfterDiscount,
                        ProductShortName = product.ProductShortName,
                        ProductDescription = product.ProductDescription,
                        ProductImageUrl = product.ProductImageUrl,
                        ProductTimeSpan = product.ProductTimeSpan,
                        CategoryId = product.CategoryId,
                        IsActive = product.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productById;
        }
        public async Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                var dbProduct = await _dbContext.tblProduct.Where(x => x.Id == productInputModel.Id).FirstOrDefaultAsync();

                if (dbProduct != null)
                {
                    dbProduct.ProductSku = productInputModel.ProductSku;
                    dbProduct.ProductName = productInputModel.ProductName;
                    dbProduct.ProductPrice = productInputModel.ProductPrice;
                    dbProduct.ProductDiscount = productInputModel.ProductDiscount;
                    dbProduct.ProductDiscountPrice = productInputModel.ProductDiscountPrice;
                    dbProduct.ProductPriceAfterDiscount = productInputModel.ProductPriceAfterDiscount;
                    dbProduct.ProductShortName = productInputModel.ProductShortName;
                    dbProduct.ProductDescription = productInputModel.ProductDescription;
                    dbProduct.ProductImageUrl = productInputModel.ProductImageUrl;
                    dbProduct.ProductTimeSpan = productInputModel.ProductTimeSpan;
                    dbProduct.CategoryId = productInputModel.CategoryId;
                    dbProduct.UpdatedBy = productInputModel.UpdatedBy;
                    dbProduct.UpdatedOn = DateTime.Now;
                    dbProduct.IsActive = productInputModel.IsActive;
                }
                else
                {
                    var productObj = new Product();

                    productObj.ProductSku = productInputModel.ProductSku;
                    productObj.ProductName = productInputModel.ProductName;
                    productObj.ProductPrice = productInputModel.ProductPrice;
                    productObj.ProductDiscount = productInputModel.ProductDiscount;
                    productObj.ProductDiscountPrice = productInputModel.ProductDiscountPrice;
                    productObj.ProductPriceAfterDiscount = productInputModel.ProductPriceAfterDiscount;
                    productObj.ProductShortName = productInputModel.ProductShortName;
                    productObj.ProductDescription = productInputModel.ProductDescription;
                    productObj.ProductImageUrl = productInputModel.ProductImageUrl;
                    productObj.ProductTimeSpan = productInputModel.ProductTimeSpan;
                    productObj.CategoryId = productInputModel.CategoryId;
                    productObj.CreatedBy = productInputModel.CreatedBy;
                    productObj.CreatedOn = DateTime.Now;
                    productObj.IsActive = productInputModel.IsActive;

                    await _dbContext.AddAsync(productObj);
                }

                await _dbContext.SaveChangesAsync();

                apiResponseModel.Status = true;
                apiResponseModel.Message = productInputModel.Id > 0 ? "Product updated successfully." : "Product added successfully.";

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
        public async Task<ApiResponseModel> ProductDelete(int Id)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbProduct = await _dbContext.tblProduct.FindAsync(Id);

                if (dbProduct != null)
                {
                    dbProduct.IsActive = false;
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Product deleted successfully.";
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