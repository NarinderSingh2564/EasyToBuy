using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.SPResults;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Repository.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EasyToBuy.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private ICartRepository _cartRepository;
        public CartController(ICartRepository cartRepository)
        {
            _cartRepository = cartRepository;
        }
        #endregion

        [HttpPost("AddToCart")]
        public async Task<ApiResponseModel> AddToCart(CartUIModel cartUIModel)
        {
            var cartInputModel = new CartInputModel();

            cartInputModel.Id = cartUIModel.Id;
            cartInputModel.ProductId = cartUIModel.ProductId;
            cartInputModel.CustomerId = cartUIModel.CustomerId;
            cartInputModel.Quantity = cartUIModel.Quantity;

            var response = await _cartRepository.AddToCart(cartInputModel);

            return response;
        }

        [HttpGet("GetCartListByCustomerId")]
        public async Task<IEnumerable<SPGetCartDetailsByCustomerId_Result>> GetCartListByCustomerId(int customerId)
        {
            var response = await _cartRepository.GetCartListByCustomerId(customerId);
            return response;
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<ApiResponseModel> RemoveProductFromCart(int id)
        {
            var response = await _cartRepository.RemoveProductFromCart(id);

            return response;
        }
    }
}
