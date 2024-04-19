using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.SPResults;

namespace EasyToBuy.Repository.Abstract
{
    public interface ICartRepository
    {
        Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel);
        Task<ApiResponseModel> CheckProductInCart(int productId, int customerId);
        Task<GetCartDetailsByCustomerId> GetCartDetailsByCustomerId(int customerId);
        Task<ApiResponseModel> RemoveProductFromCart(int id);
    }
}
