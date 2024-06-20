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
        Task<IEnumerable<SPGetProductDescriptionById_Result>> GetProductDescriptionById(int productId);
        Task<IEnumerable<ProductWeightModel>> GetProductWeightList();
        Task<IEnumerable<SPGetProductSpecificationById_Result>> GetProductSpecificationById(int productId);
        Task<IEnumerable<SPGetProductVariationListById_Result>> GetProductVariationListById(int productId);
        Task<IEnumerable<SPGetProductVariationImageById_Result>> GetProductVariationImageById(int variationId);
        Task<ApiResponseModel> SetDefaultVariation(int productId, int variationId);
    }
}
