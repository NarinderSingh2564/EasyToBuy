using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.SPResults;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class ProductRepository :  IProductRepository
    {
        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            using(ProductService productService = new ProductService())
            {
                return await productService.GetCategoryList();
            }
        }
        public async Task<IEnumerable<CategoryModel>> GetCategoryById(int Id)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetCategoryById(Id);
            }
        }
        public async Task<ApiResponseModel> CategoryAddEdit(CategoryInputModel categoryInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.CategoryAddEdit(categoryInputModel);
            }
        }
        public async Task<ApiResponseModel> CategoryDelete(int Id)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.CategoryDelete(Id);
            }
        }
        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductList();
            }
        }
        public async Task<IEnumerable<ProductModel>> GetProductById(int Id)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductById(Id);
            }
        }
        public async Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductByCategory(categoryId);
            }
        }
        public async Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductAddEdit(productInputModel);
            }
        }
        public async Task<ApiResponseModel> ProductDelete(int Id)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductDelete(Id);
            }
        }
        public async Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.AddToCart(cartInputModel);
            }
        }
        public async Task<IEnumerable<CartModel>> GetCartList()
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetCartList();
            }
        }
        public async Task<IEnumerable<SPGetCartDetailsByCustomerId_Result>> GetCartListByCustomerId(int customerId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetCartListByCustomerId(customerId);
            }
        }
        public async Task<ApiResponseModel> RemoveProductFromCart(int id)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.RemoveProductFromCart(id);
            }
        }
    }
}
