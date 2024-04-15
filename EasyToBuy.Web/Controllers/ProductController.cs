using EasyToBuy.Data.DBClasses;
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

        [HttpGet("GetProductList")]
        public async Task<IEnumerable<ProductModel>> GetProductList()
        {
            var response = await _productRepository.GetProductList();

            return response;
        }

        [HttpGet("GetProductWeightList")]
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            var response = await _productRepository.GetProductWeightList();

            return response;
        }

        [HttpGet("GetProductDetails")]
        public async Task<IEnumerable<SPGetProductDetails_Result>> GetProductDetails(int categoryId, string? searchText)
        {
            var response = await _productRepository.GetProductDetails(categoryId, searchText);
            return response;
        }

        [HttpGet("GetProductById")]
        public async Task<IEnumerable<ProductModel>> GetProductById(int Id)
        {
            var response = await _productRepository.GetProductById(Id);

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
            productInputModel.ProductDiscount = productUIModel.ProductDiscount;
            productInputModel.ProductDiscountPrice = productUIModel.ProductPrice * Decimal.Divide(productUIModel.ProductDiscount,100);
            productInputModel.ProductPriceAfterDiscount = productUIModel.ProductPriceAfterDiscount;
            productInputModel.ProductShortName = productUIModel.ProductShortName;
            productInputModel.ProductDescription = productUIModel.ProductDescription;
            productInputModel.ProductImageUrl = productUIModel.ProductImageUrl;
            productInputModel.ProductTimeSpan = productUIModel.ProductTimeSpan;
            productInputModel.CategoryId = productUIModel.CategoryId;
            productInputModel.ProductWeightId = productUIModel.ProductWeightId;
            productInputModel.ShowProductWeight = productUIModel.ShowProductWeight;
            productInputModel.CreatedBy = productUIModel.CreatedBy;
            productInputModel.UpdatedBy = productUIModel.UpdatedBy;
            productInputModel.IsActive = productUIModel.IsActive;

            var response = await _productRepository.ProductAddEdit(productInputModel);

            return response;
        }

    }
}
