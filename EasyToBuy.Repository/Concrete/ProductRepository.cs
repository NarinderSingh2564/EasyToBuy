using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class ProductRepository :  IProductRepository
    {
        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText, int vendorId, string role)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductList(categoryId,searchText,vendorId,role);
            }
        }
        public async Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductAddEdit(productInputModel);
            }
        }
        public async Task<IEnumerable<SPGetProductDescriptionById_Result>> GetProductDescriptionById(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductDescriptionById(productId);
            }
        }
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductWeightList();
            }
        }
        public async Task<IEnumerable<SPGetProductSpecificationById_Result>> GetProductSpecificationById(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductSpecificationById(productId);
            }
        }
        public async Task<IEnumerable<SPGetProductVariationListById_Result>> GetProductVariationListById(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductVariationListById(productId);
            }
        }
        public async Task<IEnumerable<SPGetProductVariationImageById_Result>> GetProductVariationImageById(int variationId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductVariationImageById(variationId);
            }
        }

        public async Task<ApiResponseModel> SetDefaultVariation(int productId, int variationId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.SetDefaultVariation(productId, variationId);

            }
        }
    }
}
