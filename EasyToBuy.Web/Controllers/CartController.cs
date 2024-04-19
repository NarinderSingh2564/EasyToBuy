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
            cartInputModel.RequestFrom = cartUIModel.RequestFrom;

            var response = await _cartRepository.AddToCart(cartInputModel);

            return response;
        }


        [HttpGet("CheckProductInCart")]
        public async Task<ApiResponseModel> CheckProductInCart(int ProductId, int CustomerId)
        {
            return await _cartRepository.CheckProductInCart(ProductId, CustomerId);
        }


        [HttpGet("GetCartDetailsByCustomerId")]
        public async Task<GetCartDetailsByCustomerId> GetCartDetailsByCustomerId(int customerId)
            {
            return await _cartRepository.GetCartDetailsByCustomerId(customerId);
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<ApiResponseModel> RemoveProductFromCart(int id)
        {
            var response = await _cartRepository.RemoveProductFromCart(id);

            return response;
        }
    }
}
