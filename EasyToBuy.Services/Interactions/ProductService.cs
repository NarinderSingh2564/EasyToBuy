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

            //try
            //{
            //    var defaultVariation  = await _dbContext.tblProductVariationAndRate.Where(x => x.ProductId == productId).ToListAsync();

            //    if (defaultVariation.Count > 0)
            //    {
            //        foreach (var item in defaultVariation)
            //        {
            //            item.SetAsDefault = false;
            //        }
            //    }

            //    var deliveryAddress = await _dbContext.tblProductVariationAndRate.Where(x => x.VariationId == variationId).FirstOrDefaultAsync();
            //    if (deliveryAddress != null)
            //    {
            //        deliveryAddress.IsDeliveryAddress = true;
            //        apiResponseModel.Status = true;
            //        apiResponseModel.Message = "Delivery address updated successfully";
            //    }
            //    await _dbContext.SaveChangesAsync();
            //}

            //catch (Exception ex)
            //{
            //    var msg = ex.Message;
            //}

            return apiResponseModel;
        }
    }
}