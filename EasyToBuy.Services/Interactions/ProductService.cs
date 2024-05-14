using System.ComponentModel;
using EasyToBuy.Data;
using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
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

        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText, int vendorId,string role)
        {
            var productList = new List<SPGetProductList_Result>();

            try
            {
                var sqlQuery = "exec spGetProductList @CategoryId,@SearchText,@VendorId,@Role";

                SqlParameter parameter1 = new SqlParameter("@CategoryId", categoryId != 0 ? categoryId : "0");
                SqlParameter parameter2 = new SqlParameter("@SearchText", string.IsNullOrEmpty(searchText) ? DBNull.Value : searchText);
                SqlParameter parameter3 = new SqlParameter("@VendorId", vendorId < 1 ? DBNull.Value : vendorId);
                SqlParameter parameter4 = new SqlParameter("@Role", string.IsNullOrEmpty(role) ? DBNull.Value : role);

                productList = await _dbContext.productList_Results.FromSqlRaw(sqlQuery, parameter1, parameter2, parameter3,parameter4).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productList;
        }
        public async Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var checkProductDuplicacy = await _dbContext.tblProduct.Where(x => x.ProductName == productInputModel.ProductName && x.VendorId == productInputModel.VendorId && x.Id != productInputModel.Id).FirstOrDefaultAsync();

                if (checkProductDuplicacy != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This product already exists.";
                }

                else
                {
                    var dbProduct = await _dbContext.tblProduct.Where(x => x.Id == productInputModel.Id).FirstOrDefaultAsync();

                    if (dbProduct != null)
                    {
                        dbProduct.ProductName = productInputModel.ProductName;
                        dbProduct.MRP = productInputModel.MRP;
                        dbProduct.Discount = productInputModel.Discount;
                        dbProduct.DiscountPrice = productInputModel.DiscountPrice;
                        dbProduct.PriceAfterDiscount = productInputModel.PriceAfterDiscount;
                        dbProduct.ProductDescription = productInputModel.ProductDescription;
                        dbProduct.ProductImage = productInputModel.ProductImage;
                        dbProduct.CategoryId = productInputModel.CategoryId;
                        dbProduct.ProductWeightId = productInputModel.ProductWeightId;
                        dbProduct.ShowProductWeight = productInputModel.ShowProductWeight;
                        dbProduct.UpdatedBy = productInputModel.UpdatedBy;
                        dbProduct.UpdatedOn = DateTime.Now;
                        dbProduct.IsActive = productInputModel.IsActive;
                    }
                   
                    else
                    {
                        var productObj = new Product();

                        productObj.VendorId = productInputModel.VendorId;
                        productObj.ProductName = productInputModel.ProductName;
                        productObj.MRP = productInputModel.MRP;
                        productObj.Discount = productInputModel.Discount;
                        productObj.DiscountPrice = productInputModel.DiscountPrice;
                        productObj.PriceAfterDiscount = productInputModel.PriceAfterDiscount;
                        productObj.ProductDescription = productInputModel.ProductDescription;
                        productObj.ProductImage = productInputModel.ProductImage;
                        productObj.CategoryId = productInputModel.CategoryId;
                        productObj.ProductWeightId = productInputModel.ProductWeightId;
                        productObj.ShowProductWeight = productInputModel.ShowProductWeight;
                        productObj.CreatedBy = productInputModel.CreatedBy;
                        productObj.CreatedOn = DateTime.Now;
                        productObj.IsActive = productInputModel.IsActive;

                        await _dbContext.AddAsync(productObj);
                    }

                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = productInputModel.Id > 0 ? "Product updated successfully." : "Product added successfully.";
                }

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<IEnumerable<SPGetProductDetailsById_Result>> GetProductDetailsById(int productId)
        {
            var productDescription = new List<SPGetProductDetailsById_Result>();

            try
            {
                var sqlQuery = "exec spGetProductDetailsById @ProductId";
                SqlParameter parameter1 = new SqlParameter("@ProductId", productId);
                productDescription = await _dbContext.productDetailsById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productDescription;
        }
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            var productWeightList = new List<ProductWeightModel>();

            try
            {
                var dbProductWeightList = await _dbContext.tblProductWeight.ToListAsync();
                foreach (var weight in dbProductWeightList)
                {
                    productWeightList.Add(new ProductWeightModel()
                    {
                        Id = weight.Id,
                        ProductWeight = weight.ProductWeight,
                        IsActive = weight.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productWeightList;
        }

    }
}