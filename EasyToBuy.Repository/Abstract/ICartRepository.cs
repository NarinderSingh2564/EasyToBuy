using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;

namespace EasyToBuy.Repository.Abstract
{
    public interface ICartRepository
    {
        Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel);
        Task<ApiResponseModel> CheckProductInCart(int variationIdId, int customerId);
        Task<GetCartDetailsByCustomerId> GetCartDetailsByCustomerId(int customerId);
        Task<ApiResponseModel> RemoveProductFromCart(int cartId);
    }
}
