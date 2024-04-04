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

        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var categoryList = new List<CategoryModel>();

            try
            {
                var dbCategoryList = await _dbContext.tblCategory.ToListAsync();
                foreach (var category in dbCategoryList)
                {
                    categoryList.Add(new CategoryModel
                    {
                       Id = category.Id,
                       CategoryName = category.CategoryName,
                       PackingMode = category.PackingMode,
                       IsActive = category.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return categoryList;
        }
        public async Task<IEnumerable<CategoryModel>> GetCategoryById(int Id)
        {
            var categoryById = new List<CategoryModel>();

            try
            {
                var dbCategoryById = await _dbContext.tblCategory.Where(x => x.Id == Id).ToListAsync();
                foreach (var category in dbCategoryById)
                {
                    categoryById.Add(new CategoryModel
                    {
                        Id = category.Id,
                        CategoryName= category.CategoryName,
                        PackingMode=category.PackingMode,
                        IsActive = category.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return categoryById;
        }
        public async Task<ApiResponseModel> CategoryAddEdit(CategoryInputModel categoryInputModel)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                //var isCategoryExists = await _dbContext.tblCategory.Where(x => x.CategoryName == categoryInputModel.CategoryName && x.Id != categoryInputModel.Id).FirstOrDefaultAsync();

                //if (isCategoryExists != null)
                //{
                //    apiResponseModel.Status = false;
                //    apiResponseModel.Message = "This category already exists.";
                //}
                //else
                //{
                    var dbCategory = await _dbContext.tblCategory.Where(x => x.Id == categoryInputModel.Id).FirstOrDefaultAsync();

                    if (dbCategory != null)
                    {
                        dbCategory.CategoryName = categoryInputModel.CategoryName;
                        dbCategory.PackingMode = categoryInputModel.PackingMode;
                        dbCategory.UpdatedBy = categoryInputModel.UpdatedBy;
                        dbCategory.UpdatedOn = DateTime.Now;
                        dbCategory.IsActive = categoryInputModel.IsActive;
                    }
                    else
                    {
                        var categoryObj = new Category();

                        categoryObj.CategoryName = categoryInputModel.CategoryName;
                        categoryObj.PackingMode = categoryInputModel.PackingMode;
                        categoryObj.CreatedBy = categoryInputModel.CreatedBy;
                        categoryObj.CreatedOn = DateTime.Now;
                        categoryObj.IsActive = categoryInputModel.IsActive;

                        await _dbContext.AddAsync(categoryObj);
                    }

                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = categoryInputModel.Id > 0 ? "Category updated successfully." : "Category added successfully.";
                //}
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
        public async Task<ApiResponseModel> CategoryDelete(int Id)
        {
            var apiResponseModel = new ApiResponseModel();

            try
            {
                var dbCategory = await _dbContext.tblCategory.FindAsync(Id);

                if (dbCategory != null)
                {
                    dbCategory.IsActive = false;
                    await _dbContext.SaveChangesAsync();

                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Category deleted successfully.";
                }
            }

            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return apiResponseModel;
        }
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
                       
                       Id= product.Id,
                       ProductSku = product.ProductSku,
                       ProductName = product.ProductName,
                       ProductPrice = product.ProductPrice,
                       ProductShortName = product.ProductShortName,
                       ProductDescription = product.ProductDescription,
                       ProductImageUrl = product.ProductImageUrl,
                       ProductTimeSpan = product.ProductTimeSpan,
                       CategoryId = product.CategoryId,
                       //CategoryName = product.Categorys?.CategoryName,
                       IsActive= product.IsActive,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return productList;
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
        public async Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId)
        {
            var productByCategory = new List<ProductModel>();

            try
            {
                var dbProductByCategory = await _dbContext.tblProduct.Where(x => x.CategoryId == categoryId).ToListAsync();
                foreach (var product in dbProductByCategory)
                {
                    productByCategory.Add(new ProductModel
                    {

                        Id = product.Id,
                        ProductSku = product.ProductSku,
                        ProductName = product.ProductName,
                        ProductPrice = product.ProductPrice,
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

            return productByCategory;
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
        public async Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel)
        {
            var apiResponseModel = new ApiResponseModel();
            try
            {
                var cartObj = new Cart();

                cartObj.CustomerId = cartInputModel.CustomerId;
                cartObj.ProductId = cartInputModel.ProductId;
                cartObj.Quantity = cartInputModel.Quantity;
                cartObj.AddedDate = DateTime.Now;

                await _dbContext.AddAsync(cartObj);
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
        public async Task<IEnumerable<CartModel>> GetCartList()
        {
            var cartList = new List<CartModel>();

            try
            {
                var dbCartList = await _dbContext.tblCart.ToListAsync();
                foreach (var cart in dbCartList)
                {
                    cartList.Add(new CartModel
                    {
                        Id = cart.Id,
                        CustomerId = cart.CustomerId,
                        ProductId = cart.ProductId,
                        Quantity = cart.Quantity,
                        AddedDate = DateTime.Now,
                    });
                }
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
            }

            return cartList;
        }
        public async Task<IEnumerable<SPGetCartDetailsByCustomerId_Result>> GetCartListByCustomerId(int customerId)
        {
            var cartListByCustomerId = new List<SPGetCartDetailsByCustomerId_Result>();

            try
            {
                  var sqlQuery = "exec spGetCartDetailsByCustomerId @CustomerId";

                  SqlParameter parameter = new SqlParameter("@CustomerId", customerId);

                  cartListByCustomerId = await _dbContext.cartDetailsByCustomerId_Results.FromSqlRaw(sqlQuery,parameter).ToListAsync();
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
                if(cartObj != null)
                {
                    _dbContext.tblCart.Remove(cartObj);
                    await _dbContext.SaveChangesAsync();
                    apiResponseModel.Status = true;
                    apiResponseModel.Message = "Product removed from cart successfully.";
                }
            }
            catch(Exception ex)
            {
                var msg = ex.Message;
            }
            return apiResponseModel;
        }
    }
}