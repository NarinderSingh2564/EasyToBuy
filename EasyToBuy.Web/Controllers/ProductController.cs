﻿using EasyToBuy.Data.DBClasses;
using EasyToBuy.Data.SPClasses;
using EasyToBuy.Models.CommonModel;
using EasyToBuy.Models.InputModels;
using EasyToBuy.Models.Models;
using EasyToBuy.Models.UIModels;
using EasyToBuy.Repository.Abstract;
using EasyToBuy.Repository.Concrete;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Net.Http.Headers;
using static System.Net.Mime.MediaTypeNames;

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
        public async Task<IEnumerable<SPGetProductList_Result>> GetProductList(int categoryId, string? searchText, int vendorId, string role)
        {
            var response = await _productRepository.GetProductList(categoryId, searchText, vendorId, role);

            return response;
        }

        [HttpPost("ProductAddEdit")]
        public async Task<ApiResponseModel> ProductAddEdit([FromForm] ProductUIModel productUIModel)
        {
            var returnResponse = new ApiResponseModel();

            var productInputModel = new ProductInputModel();

            if (productUIModel.ProductImage != null)
            {
                UploadProductImage(productUIModel);
            }

            productInputModel.Id = productUIModel.Id;
            productInputModel.VendorId = productUIModel.VendorId;
            productInputModel.ProductName = productUIModel.ProductName;
            productInputModel.ProductDescription = productUIModel.ProductDescription;
            productInputModel.ProductImage = productUIModel.ProductImageName;
            productInputModel.CategoryId = productUIModel.CategoryId;
            productInputModel.CreatedBy = productUIModel.CreatedBy;
            productInputModel.UpdatedBy = productUIModel.UpdatedBy;
            productInputModel.IsActive = productUIModel.IsActive;

            returnResponse = await _productRepository.ProductAddEdit(productInputModel);

            return returnResponse;
        }
        bool UploadProductImage(ProductUIModel productUIModel)
        {
            var fileUploadStatus = false;

            var imageRoutePath = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Products");

            if (!System.IO.Directory.Exists(imageRoutePath))
            {
                System.IO.Directory.CreateDirectory(imageRoutePath);
            }

            var ImageName = new Random().Next().ToString() + productUIModel.ProductImage.FileName.Trim('"').Trim('%').Replace("'", "").Replace(" ", "");

            using (var stream = new FileStream(Path.Combine(imageRoutePath, ImageName), FileMode.Create))
            {
                productUIModel.ProductImage.CopyTo(stream);
            }

            var oldimage = Path.Combine(Directory.GetCurrentDirectory(), "Images", "Products", productUIModel.ProductImageName);

            if (System.IO.File.Exists(oldimage))
            {
                System.IO.File.Delete(oldimage);
            }

            productUIModel.ProductImageName = ImageName;
            return fileUploadStatus;
        }

        [HttpPost("ProductVariationAndRateAddEdit")]
        public async Task<ApiResponseModel> ProductVariationAndRateAddEdit(ProductVariationAndRateUIModel productVariationAndRateUIModel)
        {
            var productVariationAndRateInputModel = new ProductVariationAndRateInputModel();

            productVariationAndRateInputModel.Id = productVariationAndRateUIModel.Id;
            productVariationAndRateInputModel.ProductId = productVariationAndRateUIModel.ProductId;
            productVariationAndRateInputModel.ProductPackingId = productVariationAndRateUIModel.ProductPackingId;
            productVariationAndRateInputModel.Quantity = productVariationAndRateUIModel.Quantity;
            productVariationAndRateInputModel.ProductWeightId = productVariationAndRateUIModel.ProductWeightId;
            productVariationAndRateInputModel.MRP = productVariationAndRateUIModel.MRP;
            productVariationAndRateInputModel.Discount = productVariationAndRateUIModel.Discount;
            productVariationAndRateInputModel.DiscountPrice = productVariationAndRateUIModel.DiscountPrice;
            productVariationAndRateInputModel.PriceAfterDiscount = productVariationAndRateUIModel.PriceAfterDiscount;
            productVariationAndRateInputModel.StockQuantity = productVariationAndRateUIModel.StockQuantity;
            productVariationAndRateInputModel.ShowProductWeight = productVariationAndRateUIModel.ShowProductWeight;
            productVariationAndRateInputModel.CreatedBy = productVariationAndRateUIModel.CreatedBy;
            productVariationAndRateInputModel.UpdatedBy = productVariationAndRateUIModel.UpdatedBy;
            productVariationAndRateInputModel.IsActive = productVariationAndRateUIModel.IsActive;

            var response = await _productRepository.ProductVariationAndRateAddEdit(productVariationAndRateInputModel);

            return response;
        }

        [HttpGet("GetProductWeightList")]
        public async Task<IEnumerable<ProductWeightModel>> GetProductWeightList()
        {
            var response = await _productRepository.GetProductWeightList();

            return response;
        }

        [HttpGet("GetProductPackingList")]
        public async Task<IEnumerable<ProductPackingModel>> GetProductPackingList()
        {
            var response = await _productRepository.GetProductPackingList();

            return response;
        }

        [HttpGet("GetProductDescriptionById")]
        public async Task<SPGetProductDescriptionById_Result> GetProductDescriptionById(int productId)
        {
            return await _productRepository.GetProductDescriptionById(productId);
        }

        [HttpGet("GetProductSpecificationById")]
        public async Task<SPGetProductSpecificationById_Result> GetProductSpecificationById(int productId)
        {
            return await _productRepository.GetProductSpecificationById(productId);
        }

        [HttpGet("GetProductVariationListById")]
        public async Task<IEnumerable<SPGetProductVariationListById_Result>> GetProductVariationListById(int productId)
        {
            var response = await _productRepository.GetProductVariationListById(productId);

            return response;
        }

        [HttpGet("GetProductVariationImageById")]
        public async Task<IEnumerable<SPGetProductVariationImageById_Result>> GetProductVariationImageById(int variationId)
        {
            var response = await _productRepository.GetProductVariationImageById(variationId);

            return response;
        }

        [HttpPost("GetDefaultVariation")]
        public async Task<ApiResponseModel> GetDefaultVariation(int productId, int variationId)
        {
            var response = await _productRepository.GetDefaultVariation(productId, variationId);

            return response;
        }

    }
}