using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
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
        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText,int vendorId, string? role)
        {
            var response = await _productRepository.GetProductList(categoryId,searchText,vendorId, role);

            return response;
        }

        [HttpPost("ProductAddEdit")]
        public async Task<ApiResponseModel> ProductAddEdit(ProductUIModel productUIModel)
        {
            var productInputModel = new ProductInputModel();

            productInputModel.Id = productUIModel.Id;
            productInputModel.VendorId = productUIModel.VendorId;
            productInputModel.ProductName = productUIModel.ProductName;
            productInputModel.ProductPrice = productUIModel.ProductPrice;
            productInputModel.ProductDiscount = productUIModel.ProductDiscount;
            productInputModel.ProductDiscountPrice = productUIModel.ProductPrice * Decimal.Divide(productUIModel.ProductDiscount,100);
            productInputModel.ProductPriceAfterDiscount = productUIModel.ProductPriceAfterDiscount;
            productInputModel.ProductDescription = productUIModel.ProductDescription;
            productInputModel.ProductImage = productUIModel.ProductImage;
            productInputModel.CategoryId = productUIModel.CategoryId;
            productInputModel.ProductWeightId = productUIModel.ProductWeightId;
            productInputModel.ShowProductWeight = productUIModel.ShowProductWeight;
            productInputModel.CreatedBy = productUIModel.CreatedBy;
            productInputModel.UpdatedBy = productUIModel.UpdatedBy;
            productInputModel.IsActive = productUIModel.IsActive;

            var response = await _productRepository.ProductAddEdit(productInputModel);

            return response;
        }

        [HttpGet("GetProductDetailsById")]
        public async Task<IEnumerable<SPGetProductDetailsById_Result>> GetProductDetailsById(int productId)
      {
            var response = await _productRepository.GetProductDetailsById(productId);

            return response;
        }

        [HttpGet("GetProductWeightList")]
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            var response = await _productRepository.GetProductWeightList();

            return response;
        }
 
    }
}