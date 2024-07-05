using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;

namespace EasyToBuy.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText,int vendorId,string role);
        Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel);
        Task<ApiResponseModel> ProductVariationAndRateAddEdit(ProductVariationAndRateInputModel productVariationAndRateInputModel);
        Task<IEnumerable<ProductWeightModel>> GetProductWeightList();
        Task<IEnumerable<ProductPackingModel>> GetProductPackingList();
        Task<SPGetProductDescriptionById_Result> GetProductDescriptionById(int productId);
        Task<SPGetProductSpecificationById_Result> GetProductSpecificationById(int productId);
        Task<IEnumerable<SPGetProductVariationListById_Result>> GetProductVariationListById(int productId);
        Task<IEnumerable<SPGetProductVariationImageById_Result>> GetProductVariationImageById(int variationId);
        Task<ApiResponseModel> GetDefaultVariation(int productId, int variationId);
    }
}
