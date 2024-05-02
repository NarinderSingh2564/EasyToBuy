﻿using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Services.Interactions;

namespace EasyToBuy.Repository.Concrete
{
    public class CartRepository : ICartRepository
    {
        public async Task<ApiResponseModel> AddToCart(CartInputModel cartInputModel)
        {
            using (CartService cartService = new CartService())
            {
                return await cartService.AddToCart(cartInputModel);
            }
        }

        public async Task<ApiResponseModel> CheckProductInCart(int ProductId, int CustomerId)
        {
            using (CartService cartService = new CartService())
            {
                return await cartService.CheckProductInCart(ProductId, CustomerId);
            }
        }

        
        public async Task<GetCartDetailsByCustomerId> GetCartDetailsByCustomerId(int customerId)
        {
            using (CartService cartService = new CartService())
            {
                return await cartService.GetCartDetailsByCustomerId(customerId);
            }
        }
        public async Task<ApiResponseModel> RemoveProductFromCart(int id)
        {
            using (CartService cartService = new CartService())
            {
                return await cartService.RemoveProductFromCart(id);
            }
        }
    }
}
