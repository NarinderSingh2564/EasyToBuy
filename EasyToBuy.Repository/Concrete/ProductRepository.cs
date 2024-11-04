using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;
using static System.Net.Mime.MediaTypeNames;

namespace EasyToBuy.Repository.Concrete
{
    public class ProductRepository : IProductRepository
    {
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductWeightList();
            }
        }
        public async Task<IEnumerable<ProductPackingModel>> GetProductPackingList()
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductPackingList();
            }
        }
        public async Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductAddEdit(productInputModel);
            }
        }
        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int productCategoryId, string? searchText, int userId, string role)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductList(productCategoryId, searchText, userId, role);
            }
        }
        public async Task<ApiResponseModel> ProductVariationAndRateAddEdit(ProductVariationAndRateInputModel productVariationAndRateInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductVariationAndRateAddEdit(productVariationAndRateInputModel);
            }
        }
        public async Task<ApiResponseModel> SetShowProductWeight(int variationId, bool showProductWeight)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.SetShowProductWeight(variationId, showProductWeight);
            }
        }
        public async Task<ApiResponseModel> SetVariationIsActive(int variationId, bool isActive)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.SetVariationIsActive(variationId, isActive);
            }
        }
        public async Task<ApiResponseModel> DeleteProductVariation(int variationId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.DeleteProductVariation(variationId);
            }
        }
        public async Task<SPGetProductDescriptionById_Result> GetProductDescriptionById(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductDescriptionById(productId);
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
        public async Task<ApiResponseModel> SetDefaultVariation(int productId, int variationId, bool status)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.SetDefaultVariation(productId, variationId,status);

            }
        }
        public async Task<ApiResponseModel> ProductSpecificationAddEdit(ProductSpecificationInputModel productSpecificationInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductSpecificationAddEdit(productSpecificationInputModel);
            }
        }
        public async Task<SPGetProductSpecificationById_Result> GetProductSpecificationById(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductSpecificationById(productId);
            }
        }
        public async Task<IEnumerable<ProductVariationModel>> GetProductVariationListByProductId(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductVariationListByProductId(productId);
            }
        }
        public async Task<ApiResponseModel> CheckVariationImagesCountById(int variationId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.CheckVariationImagesCountById(variationId);
            }
        }
        public void ProductVariationImagesAdd(ProductVariationImagesInputModel productVariationImagesInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                productService.ProductVariationImagesAdd(productVariationImagesInputModel);
            }
        }
        public async Task<IEnumerable<ProductVariationImagesModel>> GetVariationImagesListByProductId(int productId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetVariationImagesListByProductId(productId);
            }
        }
        public async Task<IEnumerable<SPGetProductSliderItemsByCategoryId_Result>> GetProductSliderItemsByCategoryId(int categoryId, int productId, string dataTypes)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.GetProductSliderItemsByCategoryId(categoryId, productId, dataTypes);
                }
        }
        public async Task<ApiResponseModel> DeleteProductVariationImage(int productImageId)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.DeleteProductVariationImage(productImageId);
            }
        }
        public async Task<ApiResponseModel> ProductRatingAdd(ProductRatingInputModel productRatingInputModel)
        {
            using (ProductService productService = new ProductService())
            {
                return await productService.ProductRatingAdd(productRatingInputModel);
            }
        }
        public void ProductRatingImageAdd(ProductRatingInputModel productRatingInputMode)
        {
            using (ProductService productService = new ProductService())
            {
                productService.ProductRatingImageAdd(productRatingInputMode);
            }
        }

        
    }
}
