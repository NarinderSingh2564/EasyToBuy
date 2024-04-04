using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.SPResults;

namespace EasyToBuy.Repository.Abstract
{
    public interface IProductRepository
    {
        Task<IEnumerable<CategoryModel>> GetCategoryList();
        Task<IEnumerable<CategoryModel>> GetCategoryById(int Id);
        Task<ApiResponseModel> CategoryAddEdit(CategoryInputModel categoryInputModel);
        Task<ApiResponseModel> CategoryDelete(int Id);
        Task<IEnumerable<ProductModel>> GetProductList();
        Task<IEnumerable<ProductModel>> GetProductById(int Id);
        Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId);
        Task<ApiResponseModel> ProductAddEdit(ProductInputModel productInputModel);
        Task<ApiResponseModel> ProductDelete(int Id);
        Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel);
        Task<IEnumerable<CartModel>> GetCartList();
        Task<IEnumerable<SPGetCartDetailsByCustomerId_Result>> GetCartListByCustomerId(int customerId);
        Task<ApiResponseModel> RemoveProductFromCart(int id);
    }
}
