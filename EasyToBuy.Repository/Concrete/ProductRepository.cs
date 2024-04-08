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
        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductList();
            }
        }
        public async Task<IEnumerable<SPGetProductDetails_Result>> GetProductDetails(int categoryId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductDetails(categoryId);
            }
        }
        public async Task<IEnumerable<ProductModel>> GetProductById(int Id)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductById(Id);
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

    }
}
