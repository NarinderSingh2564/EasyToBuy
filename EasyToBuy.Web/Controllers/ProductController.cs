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
    public class ProductController : ControllerBase
    {
        #region PRIVATE VARIABLES
        private IProductRepository _productRepository;
        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        #endregion

        [HttpGet("GetCategoryList")]
        public async Task<IEnumerable<CategoryModel>> GetCategoryList()
        {
            var response = await _productRepository.GetCategoryList();

            return response;
        }

        [HttpGet("GetCategoryById")]
        public async Task<IEnumerable<CategoryModel>> GetCategoryById(int Id)
        {
            var response = await _productRepository.GetCategoryById(Id);

            return response;
        }

        [HttpPost("CategoryAddEdit")]
        public async Task<ApiResponseModel> CategoryAddEdit(CategoryUIModel categoryUIModel)
        {
            var categoryInputModel = new CategoryInputModel();

            categoryInputModel.Id = categoryUIModel.Id;
            categoryInputModel.CategoryName = categoryUIModel.CategoryName;
           categoryInputModel.CreatedBy = categoryUIModel.CreatedBy;
           categoryInputModel.UpdatedBy = categoryUIModel.UpdatedBy;
            categoryInputModel.IsActive = categoryUIModel.IsActive;

            var response = await _productRepository.CategoryAddEdit(categoryInputModel);

            return response;
        }

        [HttpPost("CategoryDelete")]
        public async Task<ApiResponseModel> CategoryDelete(int Id)
        {
            var response = await _productRepository.CategoryDelete(Id);

            return response;
        }

        [HttpGet("GetProductList")]
        public async Task<IEnumerable<ProductModel>> GetProductList()
        {

            var response = await _productRepository.GetProductList();

            return response;
        }

        [HttpGet("GetProductById")]
        public async Task<IEnumerable<ProductModel>> GetProductById(int Id)
        {
            var response = await _productRepository.GetProductById(Id);

            return response;
        }

        [HttpGet("GetProductByCategory")]
        public async Task<IEnumerable<ProductModel>> GetProductByCategory(int categoryId)
        {
            var response = await _productRepository.GetProductByCategory(categoryId);

            return response;
        }

        [HttpPost("ProductAddEdit")]
        public async Task<ApiResponseModel> ProductAddEdit(ProductUIModel productUIModel)
        {
            var productInputModel = new ProductInputModel();

            productInputModel.Id = productUIModel.Id;
            productInputModel.ProductSku = productUIModel.ProductSku;
            productInputModel.ProductName = productUIModel.ProductName;
            productInputModel.ProductPrice = productUIModel.ProductPrice;
            productInputModel.ProductShortName = productUIModel.ProductShortName;
            productInputModel.ProductDescription = productUIModel.ProductDescription;
            productInputModel.ProductImageUrl = productUIModel.ProductImageUrl;
            productInputModel.ProductTimeSpan = productUIModel.ProductTimeSpan;
            productInputModel.CategoryId = productUIModel.CategoryId;
            productInputModel.CreatedBy = productUIModel.CreatedBy;
            productInputModel.UpdatedBy = productUIModel.UpdatedBy;
            productInputModel.IsActive = productUIModel.IsActive;

            var response = await _productRepository.ProductAddEdit(productInputModel);

            return response;
        }

        [HttpPost("ProductDelete")]
        public async Task<ApiResponseModel> ProductDelete(int Id)
        {
            var response = await _productRepository.ProductDelete(Id);

            return response;
        }

        [HttpPost("AddToCart")]
        public async Task<ApiResponseModel> AddToCart(CartUIModel cartUIModel)
        {
            var cartInputModel = new CartInputModel();

            cartInputModel.Id = cartUIModel.Id;
            cartInputModel.ProductId = cartUIModel.ProductId;
            cartInputModel.CustomerId = cartUIModel.CustomerId;
            cartInputModel.Quantity = cartUIModel.Quantity;
          
            var response = await _productRepository.AddToCart(cartInputModel);

            return response;
        }

        [HttpGet("GetCartList")]
        public async Task<IEnumerable<CartModel>> GetCartList()
        {
            var response = await _productRepository.GetCartList();

            return response;
        }

        [HttpGet("GetCartListByCustomerId")]
        public async Task<IEnumerable<SPGetCartDetailsByCustomerId_Result>> GetCartListByCustomerId(int customerId)
        {
            var response = await _productRepository.GetCartListByCustomerId(customerId);

            return response;
        }

        [HttpPost("RemoveProductFromCart")]
        public async Task<ApiResponseModel> RemoveProductFromCart(int id)
        {
            var response = await _productRepository.RemoveProductFromCart(id);

            return response;
        }
    }
}
