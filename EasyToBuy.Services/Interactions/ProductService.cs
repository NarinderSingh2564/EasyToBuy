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

        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText, int vendorId, string role)
        {
            var productList = new List<SPGetProductList_Result>();

            try
            {
                var sqlQuery = "exec spGetProductList @CategoryId,@SearchText,@VendorId,@Role";

                SqlParameter parameter1 = new SqlParameter("@CategoryId", categoryId != 0 ? categoryId : "0");
                SqlParameter parameter2 = new SqlParameter("@SearchText", string.IsNullOrEmpty(searchText) ? DBNull.Value : searchText);
                SqlParameter parameter3 = new SqlParameter("@VendorId", vendorId < 1 ? DBNull.Value : vendorId);
                SqlParameter parameter4 = new SqlParameter("@Role", string.IsNullOrEmpty(role) ? DBNull.Value : role);

                productList = await _dbContext.productList_Results.FromSqlRaw(sqlQuery, parameter1, parameter2, parameter3, parameter4).ToListAsync();

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
                        dbProduct.ProductDescription = productInputModel.ProductDescription;
                        dbProduct.ProductImage = productInputModel.ProductImage;
                        dbProduct.CategoryId = productInputModel.CategoryId;
                        dbProduct.UpdatedBy = productInputModel.UpdatedBy;
                        dbProduct.UpdatedOn = DateTime.Now;
                        dbProduct.IsActive = productInputModel.IsActive;
                    }

                    else
                    {
                        var productObj = new Product();

                        productObj.VendorId = productInputModel.VendorId;
                        productObj.ProductName = productInputModel.ProductName;
                        productObj.ProductDescription = productInputModel.ProductDescription;
                        productObj.ProductImage = productInputModel.ProductImage;
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

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }

        public async Task<ApiResponseModel> ProductVariationAndRateAddEdit(ProductVariationAndRateInputModel productVariationAndRateInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var checkVariationDuplicacy = await _dbContext.tblProductVariationAndRate.Where(x => x.ProductId == productVariationAndRateInputModel.ProductId && x.ProductPackingId == productVariationAndRateInputModel.ProductPackingId && x.Quantity == productVariationAndRateInputModel.Quantity && x.ProductWeightId == productVariationAndRateInputModel.ProductWeightId && x.Id != productVariationAndRateInputModel.Id).FirstOrDefaultAsync();

                if (checkVariationDuplicacy != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This product variation already exists.";
                }

                else
                {
                    var dbVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == productVariationAndRateInputModel.Id).FirstOrDefaultAsync();

                    if (dbVariation != null)
                    {
                        dbVariation.ProductPackingId = productVariationAndRateInputModel.ProductPackingId;
                        dbVariation.Quantity = productVariationAndRateInputModel.Quantity;
                        dbVariation.ProductWeightId = productVariationAndRateInputModel.ProductWeightId;
                        dbVariation.MRP = productVariationAndRateInputModel.MRP;
                        dbVariation.Discount = productVariationAndRateInputModel.Discount;
                        dbVariation.DiscountPrice = productVariationAndRateInputModel.DiscountPrice;
                        dbVariation.PriceAfterDiscount = productVariationAndRateInputModel.PriceAfterDiscount;
                        dbVariation.StockQuantity = productVariationAndRateInputModel.StockQuantity;
                        dbVariation.ShowProductWeight = productVariationAndRateInputModel.ShowProductWeight;
                        dbVariation.UpdatedBy = productVariationAndRateInputModel.UpdatedBy;
                        dbVariation.UpdatedOn = DateTime.Now;
                        dbVariation.SetAsDefault = productVariationAndRateInputModel.SetAsDefault;
                        dbVariation.IsActive = productVariationAndRateInputModel.IsActive;
                    }

                    else
                    {
                        var objVariation = new ProductVariationAndRate();

                        objVariation.ProductId = productVariationAndRateInputModel.ProductId;
                        objVariation.ProductPackingId = productVariationAndRateInputModel.ProductPackingId;
                        objVariation.Quantity = productVariationAndRateInputModel.Quantity;
                        objVariation.ProductWeightId = productVariationAndRateInputModel.ProductWeightId;
                        objVariation.MRP = productVariationAndRateInputModel.MRP;
                        objVariation.Discount = productVariationAndRateInputModel.Discount;
                        objVariation.DiscountPrice = productVariationAndRateInputModel.DiscountPrice;
                        objVariation.PriceAfterDiscount = productVariationAndRateInputModel.PriceAfterDiscount;
                        objVariation.StockQuantity = productVariationAndRateInputModel.StockQuantity;
                        objVariation.ShowProductWeight = productVariationAndRateInputModel.ShowProductWeight;
                        objVariation.CreatedBy = productVariationAndRateInputModel.CreatedBy;
                        objVariation.CreatedOn = DateTime.Now;
                        objVariation.SetAsDefault = productVariationAndRateInputModel.SetAsDefault;
                        objVariation.IsActive = productVariationAndRateInputModel.IsActive;

                        await _dbContext.tblProductVariationAndRate.AddAsync(objVariation);
                    }

                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = productVariationAndRateInputModel.Id > 0 ? "Product variation updated successfully." : "Product variation added successfully.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
                public async Task<IEnumerable<SPGetProductDescriptionById_Result>> GetProductDescriptionById(int productId)

        {
            var productDescription = new List<SPGetProductDescriptionById_Result>();

            try
            {
                var sqlQuery = "exec spGetProductDescriptionById @ProductId";
                SqlParameter parameter1 = new SqlParameter("@ProductId", productId);
                productDescription = await _dbContext.productDescriptionById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

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
        public async Task<IEnumerable<SPGetProductSpecificationById_Result>> GetProductSpecificationById(int productId)
        {
            var productSpecification = new List<SPGetProductSpecificationById_Result>();

            try
            {
                var sqlQuery = "exec SPGetProductSpecificationById @ProductId";
                SqlParameter parameter1 = new SqlParameter("@ProductId", productId);
                productSpecification = await _dbContext.productSpecificationById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productSpecification;
        }
        public async Task<IEnumerable<SPGetProductVariationListById_Result>> GetProductVariationListById(int productId)
        {
            var productVariationList = new List<SPGetProductVariationListById_Result>();

            try
            {
                var sqlQuery = "exec SPGetProductVariationListById @ProductId";
                SqlParameter parameter1 = new SqlParameter("@ProductId", productId);
                productVariationList = await _dbContext.productVariationListById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productVariationList;
        }
        public async Task<IEnumerable<SPGetProductVariationImageById_Result>> GetProductVariationImageById(int variationId)
        {
            var productVariationImage = new List<SPGetProductVariationImageById_Result>();

            try
            {
                var sqlQuery = "exec SPGetProductVariationImageById @VariationId";
                SqlParameter parameter1 = new SqlParameter("@VariationId", variationId);
                productVariationImage = await _dbContext.productVariationImageById_Results.FromSqlRaw(sqlQuery, parameter1).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productVariationImage;
        }

        public async Task<ApiResponseModel> SetDefaultVariation(int productId, int variationId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var getDefaultVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.ProductId == productId).ToListAsync();

                if (getDefaultVariation.Count > 0)
                {
                    foreach (var item in getDefaultVariation)
                    {
                        item.SetAsDefault = false;
                    }
                }

                var defaultVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == variationId).FirstOrDefaultAsync();

                if (defaultVariation != null)
                {
                    defaultVariation.SetAsDefault = true;
                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Default variation updated successfully";
                }
                await _dbContext.SaveChangesAsync();
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
    }
}