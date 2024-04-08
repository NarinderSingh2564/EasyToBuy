using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.SPResults;

namespace EasyToBuy.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<IEnumerable<SPGetProductDetails_Result>> GetProductDetails(int categoryId);
        Task<IEnumerable<ProductModel>> GetProductById(int Id);
        Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel);
        Task<ApiResponseModel> ProductDelete(int Id);
       
    }
}
