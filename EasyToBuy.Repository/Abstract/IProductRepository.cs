using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductWeightModel>> GetProductWeightList();
        Task<IEnumerable<ProductPackingModel>> GetProductPackingList();
        Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel);
        Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText, int vendorId, string role);
        Task<SPGetProductDescriptionById_Result> GetProductDescriptionById(int productId);
        Task<ApiResponseModel> ProductVariationAndRateAddEdit(ProductVariationAndRateInputModel productVariationAndRateInputModel);
        Task<IEnumerable<SPGetProductVariationListById_Result>> GetProductVariationListById(int productId);
        Task<IEnumerable<SPGetProductVariationImageById_Result>> GetProductVariationImageById(int variationId);
        Task<ApiResponseModel> SetDefaultVariation(int productId, int variationId);
        Task<ApiResponseModel> ProductSpecificationAddEdit(ProductSpecificationInputModel productSpecificationInputModel);
        Task<SPGetProductSpecificationById_Result> GetProductSpecificationById(int productId);
        Task<IEnumerable<ProductVariationModel>> GetProductVariationListByProductId(int productId);
        Task<ApiResponseModel> CheckVariationImagesCountById(int variationId);
        void ProductVariationImagesAdd(ProductVariationImagesInputModel productVariationImagesInputModel);
        Task<IEnumerable<ProductVariationImagesModel>> GetVariationImagesListByProductId(int productId);
        Task<IEnumerable<SPGetProductSliderItemsByCategoryId_Result>> GetProductSliderItemsByCategoryId(int categoryId , int productId);
        Task<ApiResponseModel> DeleteProductVariationImage(int imageId);
    }
}
