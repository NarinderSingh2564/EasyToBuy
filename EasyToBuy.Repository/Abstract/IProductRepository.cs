using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.SPResults;

namespace EasyToBuy.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText,int vendorId,string role);
        Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel);
        Task<IEnumerable<SPGetProductDetailsById_Result>> GetProductDetailsById(int productId);
        Task<IEnumerable<ProductWeightModel>> GetProductWeightList();
    }
}
