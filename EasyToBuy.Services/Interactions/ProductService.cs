using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;
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
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            var productWeightList = new List<ProductWeightModel>();

            try
            {
                var dbProductWeightList = await _dbContext.tblProductWeight.Where(x => x.IsActive == true).ToListAsync();
                foreach (var weight in dbProductWeightList)
                {
                    productWeightList.Add(new ProductWeightModel()
                    {
                        Id = weight.Id,
                        ProductWeight = weight.ProductWeight,
                        ProductWeightValue = weight.ProductWeightValue,
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
        public async Task<IEnumerable<ProductPackingModel>> GetProductPackingList()
        {
            var productPackingList = new List<ProductPackingModel>();

            try
            {
                var dbProductPackingList = await _dbContext.tblProductPacking.Where(x => x.IsActive == true).ToListAsync();
                foreach (var packing in dbProductPackingList)
                {
                    productPackingList.Add(new ProductPackingModel()
                    {
                        Id = packing.Id,
                        PackingType = packing.PackingType,
                        PackingModeId = packing.PackingModeId,
                        IsActive = packing.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productPackingList;
        }
        public async Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var checkProductDuplicacy = await _dbContext.tblProduct.Where(x => x.ProductName == productInputModel.ProductName && x.UserId == productInputModel.UserId && x.Id != productInputModel.Id).FirstOrDefaultAsync();

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
                        dbProduct.TotalVolume = productInputModel.TotalVolume;
                        dbProduct.UpdatedBy = productInputModel.UpdatedBy;
                        dbProduct.UpdatedOn = DateTime.Now;
                        dbProduct.IsActive = productInputModel.IsActive;
                    }

                    else
                    {
                        var productObj = new Product();

                        productObj.UserId = productInputModel.UserId;
                        productObj.ProductName = productInputModel.ProductName;
                        productObj.ProductDescription = productInputModel.ProductDescription;
                        productObj.ProductImage = productInputModel.ProductImage;
                        productObj.CategoryId = productInputModel.CategoryId;
                        productObj.TotalVolume = productInputModel.TotalVolume;
                        productObj.PackingModeId = productInputModel.PackingModeId;
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
        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int productCategoryId, string? searchText, int userId, string role)
        {
            var productList = new List<SPGetProductList_Result>();

            try
            {
                var sqlQuery = "exec spGetProductList @CategoryId,@SearchText,@UserId,@Role";

                SqlParameter parameter1 = new SqlParameter("@CategoryId", productCategoryId != 0 ? productCategoryId : "0");
                SqlParameter parameter2 = new SqlParameter("@SearchText", string.IsNullOrEmpty(searchText) ? DBNull.Value : searchText);
                SqlParameter parameter3 = new SqlParameter("@UserId", userId < 1 ? DBNull.Value : userId);
                SqlParameter parameter4 = new SqlParameter("@Role", string.IsNullOrEmpty(role) ? DBNull.Value : role);

                productList = await _dbContext.productList_Results.FromSqlRaw(sqlQuery, parameter1, parameter2, parameter3, parameter4).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productList;
        }
        public async Task<ApiResponseModel> ProductVariationAndRateAddEdit(ProductVariationAndRateInputModel productVariationAndRateInputModel)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var checkVariationDuplicacy = await _dbContext.tblProductVariationAndRate.Where(x => x.ProductId == productVariationAndRateInputModel.ProductId && x.ProductPackingId == productVariationAndRateInputModel.ProductPackingId && x.Quantity == productVariationAndRateInputModel.Quantity && x.ProductWeightId == productVariationAndRateInputModel.ProductWeightId && x.Id != productVariationAndRateInputModel.Id && x.IsDeleted == false).FirstOrDefaultAsync();

                if (checkVariationDuplicacy != null)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This product variation already exists.";
                }

                else
                {
                    var productObject = await _dbContext.tblProduct.Include(x => x.ProductPackingMode).Where(x => x.Id == productVariationAndRateInputModel.ProductId).FirstOrDefaultAsync();

                    if (productObject != null)
                    {
                        var dbVariationList = await _dbContext.tblProductVariationAndRate.Include(x => x.ProductWeights).Where(x => x.ProductId == productVariationAndRateInputModel.ProductId && x.Id != productVariationAndRateInputModel.Id && x.IsDeleted == false).ToListAsync();
                        var productWeightValue = await _dbContext.tblProductWeight.Where(x => x.Id == productVariationAndRateInputModel.ProductWeightId).Select(x => x.ProductWeightValue).FirstOrDefaultAsync();

                        decimal dbTotalVolume = 0;

                        foreach (var variation in dbVariationList)
                        {
                            dbTotalVolume += variation.StockQuantity * variation.Quantity * (productObject.PackingModeId == 1 ? variation.ProductWeights.ProductWeightValue : 1);
                        }

                        if (dbTotalVolume == productObject.TotalVolume)
                        {
                            apiResponseModel.Status = false;
                            apiResponseModel.Message = "Sorry, you can not add more variations of this product.";
                        }
                        else
                        {
                            decimal remainingVolume = productObject.TotalVolume - (dbTotalVolume + (productVariationAndRateInputModel.StockQuantity * productVariationAndRateInputModel.Quantity * (productObject.PackingModeId == 1 ? productWeightValue : 1)));

                            if (remainingVolume < 0)
                            {
                                apiResponseModel.Status = false;
                                apiResponseModel.Message = "You can only add variation of " + (productObject.PackingModeId == 1 ? (productObject.TotalVolume - dbTotalVolume) : Convert.ToUInt32(productObject.TotalVolume - dbTotalVolume)) + " " + (productObject.ProductPackingMode.PackingMode).ToLower();
                                return apiResponseModel;
                            }

                            else
                            {
                                var dbVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == productVariationAndRateInputModel.Id).FirstOrDefaultAsync();

                                if (dbVariation != null)
                                {
                                    dbVariation.MRP = productVariationAndRateInputModel.MRP;
                                    dbVariation.Discount = productVariationAndRateInputModel.Discount;
                                    dbVariation.DiscountPrice = productVariationAndRateInputModel.DiscountPrice;
                                    dbVariation.PriceAfterDiscount = productVariationAndRateInputModel.PriceAfterDiscount;
                                    dbVariation.StockQuantity = productVariationAndRateInputModel.StockQuantity;
                                    dbVariation.UpdatedBy = productVariationAndRateInputModel.UpdatedBy;
                                    dbVariation.UpdatedOn = DateTime.Now;
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
                                    objVariation.CreatedBy = productVariationAndRateInputModel.CreatedBy;
                                    objVariation.CreatedOn = DateTime.Now;

                                    await _dbContext.tblProductVariationAndRate.AddAsync(objVariation);
                                }

                                await _dbContext.SaveChangesAsync();

                                apiResponseModel.Status = true;
                                apiResponseModel.Message = productVariationAndRateInputModel.Id > 0 ? "Product variation updated successfully." : "Product variation added successfully.";
                            }
                        }
                    }
                    else
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "This product does not exists.";
                    }
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> SetShowProductWeight(int variationId, bool showProductWeight)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == variationId).FirstOrDefaultAsync();

                if (dbVariation != null)
                {
                    dbVariation.ShowProductWeight = showProductWeight;
                    apiResponseModel.Status = true;
                    _dbContext.SaveChanges();
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This product variation does not exist.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> SetVariationIsActive(int variationId, bool isActive)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == variationId).FirstOrDefaultAsync();

                if (dbVariation != null)
                {
                    dbVariation.IsActive = isActive;
                    dbVariation.SetAsDefault = isActive == false ? false : dbVariation.SetAsDefault;

                    apiResponseModel.Status = true;
                    _dbContext.SaveChanges();
                }
                else
                {
                    apiResponseModel.Status = false;


                    apiResponseModel.Message = "This product variation does not exist.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> DeleteProductVariation(int variationId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == variationId).FirstOrDefaultAsync();

                if (dbVariation != null)
                {
                    var checkOrderByVariationId = await _dbContext.tblCustomerOrder.Where(x => x.VariationId == variationId).ToListAsync();

                    if (checkOrderByVariationId.Count == 0)
                    {
                        dbVariation.IsDeleted = true;
                        dbVariation.IsActive = false;

                        _dbContext.SaveChanges();
                        apiResponseModel.Status = true;

                    }
                    else
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Sorry, you can not delete this variation until the order is not delivered.";
                    }
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "This product variation does not exist.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
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
        public async Task<ApiResponseModel> SetDefaultVariation(int productId, int variationId, bool status)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbVariationList = await _dbContext.tblProductVariationAndRate.Where(x => x.ProductId == productId).ToListAsync();

                if (dbVariationList.Count > 0)
                {
                    foreach (var item in dbVariationList)
                    {
                        item.SetAsDefault = false;
                    }
                }

                var defaultVariation = await _dbContext.tblProductVariationAndRate.Where(x => x.Id == variationId).FirstOrDefaultAsync();

                if (defaultVariation != null)
                {
                    if (status && defaultVariation.IsActive == false)
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Variation must be active to make it default variation.";
                        defaultVariation.SetAsDefault = false;
                    }
                    else
                    {
                        defaultVariation.SetAsDefault = status;
                        apiResponseModel.Status = true;
                        apiResponseModel.Message = "Default variation updated successfully.";
                    }
                    await _dbContext.SaveChangesAsync();
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<ApiResponseModel> ProductSpecificationAddEdit(ProductSpecificationInputModel productSpecificationInputModel)

        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbProductSpecification = await _dbContext.tblProductSpecification.Where(x => x.Id == productSpecificationInputModel.Id).FirstOrDefaultAsync();

                if (dbProductSpecification != null)
                {
                    dbProductSpecification.ProductId = productSpecificationInputModel.ProductId;
                    dbProductSpecification.Speciality = productSpecificationInputModel.Speciality;
                    dbProductSpecification.Manufacturer = productSpecificationInputModel.Manufacturer;
                    dbProductSpecification.IngredientType = productSpecificationInputModel.IngredientType;
                    dbProductSpecification.Ingredients = productSpecificationInputModel.Ingredients;
                    dbProductSpecification.ShelfLife = productSpecificationInputModel.ShelfLife;
                    dbProductSpecification.Benefits = productSpecificationInputModel.Benefits;
                    dbProductSpecification.UpdatedBy = productSpecificationInputModel.UpdatedBy;
                    dbProductSpecification.UpdatedOn = DateTime.Now;
                    dbProductSpecification.IsActive = productSpecificationInputModel.IsActive;
                }
                else
                {
                    var objProductSpecification = new ProductSpecification();

                    objProductSpecification.ProductId = productSpecificationInputModel.ProductId;
                    objProductSpecification.Speciality = productSpecificationInputModel.Speciality;
                    objProductSpecification.Manufacturer = productSpecificationInputModel.Manufacturer;
                    objProductSpecification.IngredientType = productSpecificationInputModel.IngredientType;
                    objProductSpecification.Ingredients = productSpecificationInputModel.Ingredients;
                    objProductSpecification.ShelfLife = productSpecificationInputModel.ShelfLife;
                    objProductSpecification.Benefits = productSpecificationInputModel.Benefits;
                    objProductSpecification.CreatedBy = productSpecificationInputModel.CreatedBy;
                    objProductSpecification.CreatedOn = DateTime.Now;
                    objProductSpecification.IsActive = productSpecificationInputModel.IsActive;

                    await _dbContext.tblProductSpecification.AddAsync(objProductSpecification);
                }
                await _dbContext.SaveChangesAsync();

                apiResponseModel.Status = true;
                apiResponseModel.Message = productSpecificationInputModel.Id > 0 ? "Product specification updated successfully." : "Product specification added successfully.";

            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public async Task<SPGetProductDescriptionById_Result> GetProductDescriptionById(int productId)
        {
            var productDescription = new SPGetProductDescriptionById_Result();

            try
            {
                var sqlQuery = "exec spGetProductDescriptionById @ProductId";
                SqlParameter parameter = new SqlParameter("@ProductId", productId);
                productDescription =  _dbContext.productDescriptionById_Results.FromSqlRaw(sqlQuery, parameter).ToList().FirstOrDefault();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productDescription;
        }
        public async Task<SPGetProductSpecificationById_Result> GetProductSpecificationById(int productId)
        {
            var productSpecification = new SPGetProductSpecificationById_Result();

            try
            {
                var sqlQuery = "exec SPGetProductSpecificationById @ProductId";
                SqlParameter parameter1 = new SqlParameter("@ProductId", productId);
                productSpecification = _dbContext.productSpecificationById_Results.FromSqlRaw(sqlQuery, parameter1).ToList().FirstOrDefault();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productSpecification;
        }
        public async Task<IEnumerable<ProductVariationModel>> GetProductVariationListByProductId(int productId)
        {
            var productVariationList = new List<ProductVariationModel>();
            try
            {
                var query = (from tpv in _dbContext.tblProductVariationAndRate
                             join tp in _dbContext.tblProduct on tpv.ProductId equals tp.Id
                             join tpp in _dbContext.tblProductPacking on tpv.ProductPackingId equals tpp.Id
                             join tpw in _dbContext.tblProductWeight on tpv.ProductWeightId equals tpw.Id
                             orderby tpw.Id
                             where tpv.ProductId == productId
                             select new ProductVariationModel
                             {
                                 VariationId = tpv.Id,
                                 Variation = tp.ProductName + " (" + tpw.ProductWeight + " " + tpp.PackingType + ")",
                                 IsActive = tpv.IsActive
                             }).ToListAsync();

                productVariationList = await query.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return productVariationList;
        }
        public async Task<ApiResponseModel> CheckVariationImagesCountById(int variationId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbImagesCount = await _dbContext.tblProductImages.Where(x => x.VariationId == variationId).ToListAsync();

                if (dbImagesCount.Count == 5)
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "You have already uploaded 5 images of this variation. Please delete some images to upload.";
                }
                else if (dbImagesCount.Count < 5)
                {
                    apiResponseModel.Status = true;
                    apiResponseModel.Response = 5 - dbImagesCount.Count;
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
        public void ProductVariationImagesAdd(ProductVariationImagesInputModel productVariationImagesInputModel)
        {
            try
            {
                var variationImagesObj = new ProductImages();

                variationImagesObj.VariationId = productVariationImagesInputModel.VariationId;
                variationImagesObj.Image = productVariationImagesInputModel.Image;
                variationImagesObj.CreatedBy = productVariationImagesInputModel.CreatedBy;
                variationImagesObj.CreatedOn = DateTime.Now;
                variationImagesObj.IsActive = true;

                _dbContext.tblProductImages.Add(variationImagesObj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
        }
        public async Task<IEnumerable<ProductVariationImagesModel>> GetVariationImagesListByProductId(int productId)
        {
            var variationImagesList = new List<ProductVariationImagesModel>();
            try
            {
                var query = (from tpi in _dbContext.tblProductImages
                             join tpv in _dbContext.tblProductVariationAndRate on tpi.VariationId equals tpv.Id
                             join tp in _dbContext.tblProduct on tpv.ProductId equals tp.Id
                             join tpp in _dbContext.tblProductPacking on tpv.ProductPackingId equals tpp.Id
                             join tpw in _dbContext.tblProductWeight on tpv.ProductWeightId equals tpw.Id
                             where tpv.ProductId == productId
                             orderby tpw.Id
                             select new ProductVariationImagesModel
                             {
                                 Id = tpi.Id,
                                 VariationId = tpv.Id,
                                 Variation = tp.ProductName + " (" + tpw.ProductWeight + " " + tpp.PackingType + ")",
                                 Image = tpi.Image,
                             }).ToListAsync();

                variationImagesList = await query.ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return variationImagesList;
        }
        public async Task<IEnumerable<SPGetProductSliderItemsByCategoryId_Result>> GetProductSliderItemsByCategoryId(int categoryId, int productId, string dataTypes)
        {
            var productSliderItems = new List<SPGetProductSliderItemsByCategoryId_Result>();

            try
            {
                var sqlQuery = "exec SPGetProductSliderItemsByCategoryId @CategoryId, @ProductId, @DataTypes";
                SqlParameter parameter1 = new SqlParameter("@CategoryId", categoryId);
                SqlParameter parameter2 = new SqlParameter("@ProductId", productId < 1 ? DBNull.Value : productId);
                SqlParameter parameter3 = new SqlParameter("@DataTypes", string.IsNullOrEmpty(dataTypes) ? DBNull.Value : dataTypes);
                productSliderItems = await _dbContext.productSliderItemsByCategoryId_Results.FromSqlRaw(sqlQuery, parameter1, parameter2, parameter3).ToListAsync();

            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return productSliderItems;
        }
        public async Task<ApiResponseModel> DeleteProductVariationImage(int productImageId)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbImage = await _dbContext.tblProductImages.Where(x => x.Id == productImageId).FirstOrDefaultAsync();

                if (dbImage != null)
                {
                    var imageToDelete = Path.Combine(Directory.GetCurrentDirectory(), "Images", "ProductVariations", dbImage.Image);

                    if (System.IO.File.Exists(imageToDelete))
                    {
                        System.IO.File.Delete(imageToDelete);
                        _dbContext.tblProductImages.Remove(dbImage);
                        _dbContext.SaveChanges();

                        apiResponseModel.Status = true;
                        apiResponseModel.Message = "Image deleted successfully.";
                    }
                    else
                    {
                        apiResponseModel.Status = false;
                        apiResponseModel.Message = "Unable to delete the image as it doesn't exist.";
                    }
                }
                else
                {
                    apiResponseModel.Status = false;
                    apiResponseModel.Message = "Unable to delete the image as it doesn't exist.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
        public async Task<ApiResponseModel> ProductRatingAdd(ProductRatingInputModel productRatingInputModel)
        {
          var apiResponseModel = new ApiResponseModel();

            try
            {
                var productRatingObj = new ProductRating();

                productRatingObj.ProductId = productRatingInputModel.ProductId;
                productRatingObj.Rating = productRatingInputModel.Rating;
                productRatingObj.ReviewTitle = productRatingInputModel.ReviewTitle;
                productRatingObj.ReviewDescription = productRatingInputModel.ReviewDescription;
                productRatingObj.CreatedBy = productRatingInputModel.CreatedBy;
                productRatingObj.CreatedDate = DateTime.Now;
                productRatingObj.IsActive = productRatingInputModel.IsActive;

                await _dbContext.AddAsync(productRatingObj);

                await _dbContext.SaveChangesAsync();

                apiResponseModel.Status = true;
                apiResponseModel.Message = "Product RatingAndReview Add successfully.";
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
        public void ProductRatingImageAdd(ProductRatingImageInputModel productRatingImagesInputModel)
        {
            try
            {
                var ratingImagesObj = new ProductRatingImages();

                ratingImagesObj.ProductRatingId = productRatingImagesInputModel.ProductRatingId;
                ratingImagesObj.ProductImage = productRatingImagesInputModel.ProductRatingImage;
                ratingImagesObj.CreatedBy = productRatingImagesInputModel.CreatedBy;
                ratingImagesObj.CreatedOn = DateTime.Now;
                ratingImagesObj.IsActive = true;

                _dbContext.tblProductRatingImages.Add(ratingImagesObj);
                _dbContext.SaveChanges();
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

        }
    }
}