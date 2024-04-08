using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.SPResults;

namespace EasyToBuy.Repository.Abstract
{
    public interface ICartRepository
    {
        Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel);
        Task<IEnumerable<SPGetCartDetailsByCustomerId_Result>> GetCartListByCustomerId(int customerId);
        Task<ApiResponseModel> RemoveProductFromCart(int id);
    }
}
